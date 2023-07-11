using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Models.Enums;
using Vee_Tailoring.Emails;

namespace Vee_Tailoring.Implementations.Services;

public class CustomerService : ICustomerService
{
    ICustomerRepo _repository;
    IUserRepo _userrepository;
    IRoleRepo _rolerepository;
    IOrderRepo _orderRepo;
    IEmailSend _emailSend;
    public CustomerService(ICustomerRepo repository, IUserRepo userrepository, IRoleRepo rolerepository, IOrderRepo orderRepo, IEmailSend emailSend)
    {
        _repository = repository;
        _userrepository = userrepository;
        _rolerepository = rolerepository;
        _orderRepo = orderRepo;
        _emailSend = emailSend;
    }
    public async Task<BaseResponse> Create(CreateCustomerDto createCustomerDto)
    {
        var checkcustomer = await _repository.Get(c => c.User.Email == createCustomerDto.Email);
        if (checkcustomer == null)
        {
            var newUser = new User()
            {
                UserName = $"{createCustomerDto.LastName} {createCustomerDto.FirstName}",
                Email = createCustomerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createCustomerDto.Password),
            };
            var user = await _userrepository.Create(newUser);
            var role = await _rolerepository.Get(c => c.Name == "Customer");
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
            var customer = new Customer()
            {
                UserId = user.Id,
                CustomerNo = $"CUSTOMER{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
                UserDetails = new UserDetails()
                {
                    FirstName = createCustomerDto.FirstName,
                    LastName = createCustomerDto.LastName,
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
                Measurements = new Measurement()
                {
                    AnkleSize = "0.00",
                    ArmLength = "0.00",
                    ArmSize = "0.00",
                    BackWaist = "0.00",
                    BodyHeight = "0.00",
                    BurstGirth = "0.00",
                    FrontWaist = "0.00",
                    Head = "0.00",
                    HighHips = "0.00",
                    HipSize = "0.00",
                    LegLength = "0.00",
                    NeckSize = "0.00",
                    ShoulderWidth = "0.00",
                    ThirdQuarterLegLength = "0.00",
                    WaistSize = "0.00",
                    WristCircumfrence = "0.00",
                    IsDeleted = false,
                },
                IsDeleted = false
            };
            await _repository.Create(customer);
            var email = new CreateEmailDto()
            {
                Subject = "V Tailoring Account Registered Successfully",
                ReceiverName = $"{createCustomerDto.LastName} {createCustomerDto.FirstName}",
                ReceiverEmail = createCustomerDto.Email,
                Message = $"Hi {createCustomerDto.FirstName}, /n" +
                $"Thanks for registering an account with us. /n" +
                $"Login to finish setting up your profile."
            };
            var response = await _emailSend.SendMail(email);
            return new BaseResponse()
            {
                Message = "Account Created Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Failed To Create An Account Successfully",
            Status = false
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateCustomerDto updateCustomerDto)
    {
        var customer = await _repository.GetByUserId(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Customer");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updateCustomerDto.UpdateUserDetailsDto.ImageUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updateCustomerDto.UpdateUserDetailsDto.ImageUrl.FileName);
            var filePath = Path.Combine(folderPath, updateCustomerDto.UpdateUserDetailsDto.ImageUrl.FileName);
            var extension = Path.GetExtension(updateCustomerDto.UpdateUserDetailsDto.ImageUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateCustomerDto.UpdateUserDetailsDto.ImageUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (customer != null)
        {
            customer.User.Email = updateCustomerDto.Email;
            customer.User.UserName = $"{updateCustomerDto.UpdateUserDetailsDto.LastName} {updateCustomerDto.UpdateUserDetailsDto.FirstName}" ?? customer.User.UserName;
            customer.UserDetails.FirstName = updateCustomerDto.UpdateUserDetailsDto.FirstName ?? customer.UserDetails.FirstName;
            customer.UserDetails.LastName = updateCustomerDto.UpdateUserDetailsDto.LastName ?? customer.UserDetails.LastName;
            customer.UserDetails.Gender = updateCustomerDto.UpdateUserDetailsDto.Gender;
            customer.UserDetails.ImageUrl = imagePath ?? customer.UserDetails.ImageUrl;
            customer.UserDetails.PhoneNumber = updateCustomerDto.UpdateUserDetailsDto.PhoneNumber ?? customer.UserDetails.PhoneNumber;
            customer.UserDetails.Address.NumberLine = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.NumberLine;
            customer.UserDetails.Address.Street = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.Street ?? customer.UserDetails.Address.Street;
            customer.UserDetails.Address.City = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.City ?? customer.UserDetails.Address.City;
            customer.UserDetails.Address.Region = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.Region ?? customer.UserDetails.Address.Region;
            customer.UserDetails.Address.State = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.State ?? customer.UserDetails.Address.State;
            customer.UserDetails.Address.Country = updateCustomerDto.UpdateUserDetailsDto.UpdateAddressDto.Country ?? customer.UserDetails.Address.Country;
            customer.Measurements.AnkleSize = $"{updateCustomerDto.UpdateMeasurementDto.AnkleSize}" ?? customer.Measurements.AnkleSize;
            customer.Measurements.ArmLength = $"{updateCustomerDto.UpdateMeasurementDto.ArmLength}" ?? customer.Measurements.ArmLength;
            customer.Measurements.ArmSize = $"{updateCustomerDto.UpdateMeasurementDto.ArmSize}" ?? customer.Measurements.ArmSize;
            customer.Measurements.BackWaist = $"{updateCustomerDto.UpdateMeasurementDto.BackWaist}" ?? customer.Measurements.BackWaist;
            customer.Measurements.BodyHeight = $"{updateCustomerDto.UpdateMeasurementDto.BodyHeight}" ?? customer.Measurements.BodyHeight;
            customer.Measurements.BurstGirth = $"{updateCustomerDto.UpdateMeasurementDto.BurstGirth}" ?? customer.Measurements.BurstGirth;
            customer.Measurements.FrontWaist = $"{updateCustomerDto.UpdateMeasurementDto.FrontWaist}" ?? customer.Measurements.FrontWaist;
            customer.Measurements.Head = $"{updateCustomerDto.UpdateMeasurementDto.Head}" ?? customer.Measurements.Head;
            customer.Measurements.HighHips = $"{updateCustomerDto.UpdateMeasurementDto.HighHips}" ?? customer.Measurements.HighHips;
            customer.Measurements.HipSize = $"{updateCustomerDto.UpdateMeasurementDto.HipSize}" ?? customer.Measurements.HipSize;
            customer.Measurements.LegLength = $"{updateCustomerDto.UpdateMeasurementDto.LegLength}" ?? customer.Measurements.LegLength;
            customer.Measurements.NeckSize = $"{updateCustomerDto.UpdateMeasurementDto.NeckSize}" ?? customer.Measurements.NeckSize;
            customer.Measurements.ShoulderWidth = $"{updateCustomerDto.UpdateMeasurementDto.ShoulderWidth}" ?? customer.Measurements.ShoulderWidth;
            customer.Measurements.ThirdQuarterLegLength = $"{updateCustomerDto.UpdateMeasurementDto.ThirdQuarterLegLength}" ?? customer.Measurements.ThirdQuarterLegLength;
            customer.Measurements.WaistSize = $"{updateCustomerDto.UpdateMeasurementDto.WaistSize}" ?? customer.Measurements.WaistSize;
            customer.Measurements.WristCircumfrence = $"{updateCustomerDto.UpdateMeasurementDto.WristCircumfrence}" ?? customer.Measurements.WristCircumfrence;
            customer.LastModifiedOn = DateTime.Now;
            await _repository.Update(customer);
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
    public async Task<CustomerResponseModel> GetById(int id)
    {
        var customer = await _repository.GetById(id);
        if (customer != null)
        {
            return new CustomerResponseModel()
            {
                Data = GetDetails(customer),
                Message = "Customer Retrieved Successfully",
                Status = true,
            };
        }
        return new CustomerResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Customer Successfully",
            Status = false,
        };
    }
    public async Task<CustomerResponseModel> GetByUserId(int id)
    {
        var customer = await _repository.GetByUserId(id);
        if (customer != null)
        {
            return new CustomerResponseModel()
            {
                Data = GetDetails(customer),
                Message = "Customer Retrieved Successfully",
                Status = true,
            };
        }
        return new CustomerResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Customer Successfully",
            Status = false,
        };
    }
    public async Task<CustomersResponseModel> GetByCustomerEmail(string email)
    {
        var customer = await _repository.GetbyEmail(email);
        if (customer != null)
        {
            return new CustomersResponseModel()
            {
                Data = customer.Select(customer => GetDetails(customer)).ToList(),
                Message = "Customer Retrieved Successfully",
                Status = true,
            };
        }
        return new CustomersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Customer Successfully",
            Status = false,
        };
    }
    public async Task<CustomersResponseModel> GetAllCustomers()
    {
        var customers = await _repository.List();
        if (customers != null)
        {
            return new CustomersResponseModel()
            {
                Data = customers.Select(customer => GetDetails(customer)).ToList(),
                Message = "Customers List Retrieved Successfully",
                Status = true,
            };
        }
        return new CustomersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Customers List Successfully",
            Status = false,
        };
    }
    public GetCustomerDto GetDetails(Customer customer)
    {
        return new GetCustomerDto()
        {
            Id = customer.Id,
            CustomerNo = customer.CustomerNo,
            Email = customer.User.Email,
            GetUserDetailsDto = new GetUserDetailsDto()
            {
                FirstName = customer.UserDetails.FirstName,
                LastName = customer.UserDetails.LastName,
                ImageUrl = customer.UserDetails.ImageUrl,
                Gender = customer.UserDetails.Gender,
                PhoneNumber = customer.UserDetails.PhoneNumber,
                GetAddressDto = new GetAddressDto()
                {
                    NumberLine = customer.UserDetails.Address.NumberLine,
                    Street = customer.UserDetails.Address.Street,
                    City = customer.UserDetails.Address.City,
                    Region = customer.UserDetails.Address.Region,
                    State = customer.UserDetails.Address.State,
                    Country = customer.UserDetails.Address.Country,
                    PostalCode = customer.UserDetails.Address.PostalCode,
                }
            },
            GetMeasurementDto = new GetMeasurementDto()
            {
                AnkleSize = Decimal.Parse(customer.Measurements.AnkleSize),
                ArmLength = Decimal.Parse(customer.Measurements.ArmLength),
                ArmSize = Decimal.Parse(customer.Measurements.ArmSize),
                BackWaist = Decimal.Parse(customer.Measurements.BackWaist),
                BodyHeight = Decimal.Parse(customer.Measurements.BodyHeight),
                BurstGirth = Decimal.Parse(customer.Measurements.BurstGirth),
                FrontWaist = Decimal.Parse(customer.Measurements.FrontWaist),
                Head = Decimal.Parse(customer.Measurements.Head),
                HighHips = Decimal.Parse(customer.Measurements.HighHips),
                HipSize = Decimal.Parse(customer.Measurements.HipSize),
                LegLength = Decimal.Parse(customer.Measurements.LegLength),
                NeckSize = Decimal.Parse(customer.Measurements.NeckSize),
                ShoulderWidth = Decimal.Parse(customer.Measurements.ShoulderWidth),
                ThirdQuarterLegLength = Decimal.Parse(customer.Measurements.ThirdQuarterLegLength),
                WaistSize = Decimal.Parse(customer.Measurements.WaistSize),
                WristCircumfrence = Decimal.Parse(customer.Measurements.WristCircumfrence),
            }
        };
    }
    public async Task<CustomerUserDashboard> UserDashboard(int UserId)
    {
        var customer = await _repository.GetByUserId(UserId);
        int Total = (await _orderRepo.GetByExpression(x => x.CustomerId == customer.Id)).Count;
        int Paid = (await _orderRepo.GetByExpression(x => x.CustomerId == customer.Id && x.IsPaid == IsPaid.Paid)).Count;
        int UnPaid = (await _orderRepo.GetByExpression(x => x.CustomerId == customer.Id && x.IsPaid == IsPaid.Pending || x.IsPaid == IsPaid.NotPaid)).Count;
        if (customer != null && Total != 0)
        {
            return new CustomerUserDashboard
            {
                Total = Total,
                Paid = Paid,
                UnPaid = UnPaid,
                Status = true,
            };
        }
        return new CustomerUserDashboard
        {
            Message = "You have'nt made any order yet!",
            Status = false,
        };
    }
    public async Task<DashBoardResponse> CustomerDashboard()
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
            Message = "No Customers Yes!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateCustomer(int id)
    {
        var customer = await _repository.GetByUserId(id);
        if (customer != null)
        {
            customer.IsDeleted = true;
            await _repository.Update(customer);
            return new BaseResponse()
            {
                Message = "Customer Deleted Successfully",
                Status = true,
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Delete Customer Successfully",
            Status = false,
        };
    }
}
