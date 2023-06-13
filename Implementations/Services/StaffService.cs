using Vee_Tailoring.Emails;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;

public class StaffService : IStaffService
{
    IStaffRepo _repository;
    IUserRepo _userrepository;
    IRoleRepo _rolerepository;
    IOrderRepo _orderRepo;
    IEmailSend _emailSend;
    public StaffService(IStaffRepo repository, IUserRepo userrepository, IRoleRepo rolerepository, IOrderRepo orderRepo, IEmailSend emailSend)
    {
        _repository = repository;
        _userrepository = userrepository;
        _rolerepository = rolerepository;
        _orderRepo = orderRepo;
        _emailSend = emailSend;
    }
    public async Task<BaseResponse> Create(CreateStaffDto createStaffDto)
    {
        var checkstaff = await _repository.Get(c => c.User.Email == createStaffDto.Email);
        if (checkstaff == null)
        {
            var newUser = new User()
            {
                UserName = $"{createStaffDto.LastName} {createStaffDto.FirstName}",
                Email = createStaffDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createStaffDto.Password),
            };
            var user = await _userrepository.Create(newUser);
            var role = await _rolerepository.Get(c => c.Id == createStaffDto.RoleId);
            if (role == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Attach Role Suucessfully",
                    Status = false
                };
            }
            var userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            newUser.UserRoles.Add(userRole);
            await _userrepository.Update(newUser);

            var staff = new Staff()
            {
                UserId = user.Id,
                StaffNo = $"STAFF{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
                UserDetails = new UserDetails()
                {
                    FirstName = createStaffDto.FirstName,
                    LastName = createStaffDto.LastName,
                    PhoneNumber = "",
                    ImageUrl = "",
                    Gender = Gender.RatherNotSay,
                    Address = new Address()
                    {
                        NumberLine = "0",
                        Street = "",
                        City = "",
                        Region = "",
                        State = "",
                        Country = "",
                        PostalCode = "",
                        IsDeleted = false
                    },
                    IsDeleted = false
                },
                IsDeleted = false
            };
            await _repository.Create(staff);
            var email = new CreateEmailDto()
            {
                Subject = "V Tailoring Staff Account Registered Successfully",
                ReceiverName = $"{createStaffDto.LastName} {createStaffDto.FirstName}",
                ReceiverEmail = createStaffDto.Email,
                Message = $"Hi {createStaffDto.FirstName}, /n" +
                $"Thanks for joing us. We hope you gain valueable experience with us to help you acheve your full potential. /n" +
                $"You've been assigned as a {role.Name}. /n" +
                $"Signed: Vee Management" +
                $"Login to finish setting up your profile."
            };
            var response = await _emailSend.SendEmail(email);
            return new BaseResponse()
            {
                Message = "Staff Registered Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Failed To Register Staff Successfully",
            Status = false
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateStaffDto updateStaffDto)
    {
        {
            var staff = await _repository.GetById(id);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Staff");
            if (!System.IO.Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var imagePath = "";
            if (updateStaffDto.UpdateUserDetailsDto.ImageUrl != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateStaffDto.UpdateUserDetailsDto.ImageUrl.FileName);
                var filePath = Path.Combine(folderPath, updateStaffDto.UpdateUserDetailsDto.ImageUrl.FileName);
                var extension = Path.GetExtension(updateStaffDto.UpdateUserDetailsDto.ImageUrl.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateStaffDto.UpdateUserDetailsDto.ImageUrl.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            if (staff != null)
            {
                staff.User.Email = updateStaffDto.Email;
                staff.User.UserName = $"{updateStaffDto.UpdateUserDetailsDto.LastName} {updateStaffDto.UpdateUserDetailsDto.FirstName}" ?? staff.User.UserName;
                staff.UserDetails.FirstName = updateStaffDto.UpdateUserDetailsDto.FirstName ?? staff.UserDetails.FirstName;
                staff.UserDetails.LastName = updateStaffDto.UpdateUserDetailsDto.LastName ?? staff.UserDetails.LastName;
                staff.UserDetails.Gender = updateStaffDto.UpdateUserDetailsDto.Gender;
                staff.UserDetails.ImageUrl = imagePath ?? staff.UserDetails.ImageUrl;
                staff.UserDetails.PhoneNumber = updateStaffDto.UpdateUserDetailsDto.PhoneNumber ?? staff.UserDetails.PhoneNumber;
                staff.UserDetails.Address.NumberLine = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.NumberLine;
                staff.UserDetails.Address.Street = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.Street ?? staff.UserDetails.Address.Street;
                staff.UserDetails.Address.City = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.City ?? staff.UserDetails.Address.City;
                staff.UserDetails.Address.Region = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.Region ?? staff.UserDetails.Address.Region;
                staff.UserDetails.Address.State = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.State ?? staff.UserDetails.Address.State;
                staff.UserDetails.Address.Country = updateStaffDto.UpdateUserDetailsDto.UpdateAddressDto.Country ?? staff.UserDetails.Address.Country;
                staff.LastModifiedOn = DateTime.Now;
                await _repository.Update(staff);
                return new BaseResponse()
                {
                    Message = "Profile Updated Successfully",
                    Status = true,
                };
            }
            return new BaseResponse()
            {
                Message = "Unable To Update Profile Successfully",
                Status = false,
            };
        }
    }
    public async Task<StaffResponseModel> GetById(int id)
    {
        var staff = await _repository.GetById(id);
        if (staff != null)
        {
            return new StaffResponseModel()
            {
                Data = await GetDetails(staff),
                Message = "Staff Retrieved Successfully",
                Status = true,
            };
        }
        return new StaffResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Staff Successfully",
            Status = false,
        };
    }
    public async Task<StaffResponseModel> GetByUserId(int id)
    {
        var staff = await _repository.GetByUserId(id);
        if (staff != null)
        {
            return new StaffResponseModel()
            {
                Data = await GetDetails(staff),
                Message = "Staff Retrieved Successfully",
                Status = true,
            };
        }
        return new StaffResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Staff Successfully",
            Status = false,
        };
    }
    public async Task<StaffsResponseModel> GetByStaffEmail(string Email)
    {
        var staffs = await _repository.GetbyEmail(Email);
        if (staffs != null)
        {
            return new StaffsResponseModel()
            {
                Data = (IList<GetStaffDto>)staffs.Select(async staff => (await GetDetails(staff))).ToList(),
                Message = "Staff Retrieved Successfully",
                Status = true,
            };
        }
        return new StaffsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Staff Successfully",
            Status = false,
        };
    }
    public async Task<StaffsResponseModel> GetAllStaffs()
    {
        var staffs = await _repository.List();
        if (staffs != null)
        {
            return new StaffsResponseModel()
            {
                Data = (IList<GetStaffDto>)staffs.Select(async staff => (await GetDetails(staff))).ToList(),
                Message = "Staffs List Retrieved Successfully",
                Status = true,
            };
        }
        return new StaffsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Staffs List Successfully",
            Status = false,
        };
    }
    public async Task<GetStaffDto> GetDetails(Staff staff)
    {
        var roles = await _rolerepository.GetRoleByUserId(staff.User.Id);
        return new GetStaffDto()
        {
            Id = staff.Id,
            StaffNo = staff.StaffNo,
            Email = staff.User.Email,
            GetUserDetailsDto = new GetUserDetailsDto()
            {
                FirstName = staff.UserDetails.FirstName,
                LastName = staff.UserDetails.LastName,
                ImageUrl = staff.UserDetails.ImageUrl,
                Gender = staff.UserDetails.Gender,
                PhoneNumber = staff.UserDetails.PhoneNumber,
                GetAddressDto = new GetAddressDto()
                {
                    NumberLine = staff.UserDetails.Address.NumberLine,
                    Street = staff.UserDetails.Address.Street,
                    City = staff.UserDetails.Address.City,
                    Region = staff.UserDetails.Address.Region,
                    State = staff.UserDetails.Address.State,
                    Country = staff.UserDetails.Address.Country,
                }
            },
            GetRoleDto = roles.Select(
                role => new GetRoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
            }).ToList(),
        };
    }
    public async Task<DashBoardResponse> StaffsDashboard()
    {
        int total = (await _repository.GetAll()).Count;
        int active = (await _repository.GetByExpression(x => x.IsDeleted == false)).Count;
        int inActive = (await _repository.GetByExpression(x => x.IsDeleted == true)).Count;
        if (total != 0)
        {
            return new DashBoardResponse
            {
                Total = total,
                Active = active,
                InActive = inActive,
                Status = true,
            };
        }
        return new DashBoardResponse
        {
            Message = "No Available Staffs!",
            Status = false,
        };
    }
    public async Task<StaffUserDashboard> UserDashboard(int UserId)
    {
        var staff = await _repository.GetByUserId(UserId);
        int Total = (await _orderRepo.GetByExpression(x => x.StaffId == staff.Id)).Count;
        int Completed = (await _orderRepo.GetByExpression(x => x.StaffId == staff.Id && x.IsCompleted == IsCompleted.Completed)).Count;
        int UnCompleted = (await _orderRepo.GetByExpression(x => x.StaffId == staff.Id && x.IsCompleted == IsCompleted.Pending)).Count;
        int Assigned = (await _orderRepo.GetByExpression(x => x.StaffId == staff.Id && x.IsAssigned == true)).Count;
        int UnAssigned = (await _orderRepo.GetByExpression(x => x.StaffId == staff.Id && x.IsAssigned == false)).Count;
        if (staff != null && Total != 0)
        {
            return new StaffUserDashboard
            {
                Total = Total,
                Assigned = Assigned,
                UnAssigned = UnAssigned,
                Completed = Completed,
                UnCompleted = UnCompleted,
                Status = true,
            };
        }
        return new StaffUserDashboard
        {
            Message = "You have'nt attented to any order yet!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateStaff(int id)
    {
        var staff = await _repository.GetById(id);
        if (staff != null)
        {
            staff.IsDeleted = true;
            await _repository.Update(staff);
            return new BaseResponse()
            {
                Message = "Staff Deleted Successfully",
                Status = true,
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Delete Staff Successfully",
            Status = false,
        };
    }
}
