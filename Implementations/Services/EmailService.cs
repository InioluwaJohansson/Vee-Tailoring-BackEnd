using System.Runtime.ConstrainedExecution;
using Vee_Tailoring.Emails;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;
public class EmailService : IEmailService
{
    IEmailRepo _repository;
    IRoleRepo _rolerepository;
    IStaffRepo _staffRepo;
    ICustomerRepo _customerRepo;
    IEmailSend _emailSend;
    public EmailService(IEmailRepo repository, IRoleRepo rolerepository, IStaffRepo staffRepo, ICustomerRepo customerRepo, IEmailSend emailSend)
    {
        _repository = repository;
        _rolerepository = rolerepository;
        _staffRepo = staffRepo;
        _customerRepo = customerRepo;
        _emailSend = emailSend;
    }

    public async Task<BaseResponse> Create(CreateEmailDto createEmailDto)
    {
        var imagePath = "";
        if(createEmailDto.Attachment != null){
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Email Attachments\\");
            if (!System.IO.Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (createEmailDto.Attachment != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createEmailDto.Attachment.FileName);
                var filePath = Path.Combine(folderPath, createEmailDto.Attachment.FileName);
                var extension = Path.GetExtension(createEmailDto.Attachment.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createEmailDto.Attachment.CopyToAsync(stream);
                    }
                    imagePath = filePath;
                }
            }
            createEmailDto.AttachmentUrl = imagePath;
        }
        var email = new Email()
        {
            Subject = createEmailDto.Subject,
            Message = createEmailDto.Message,
            StaffId = createEmailDto.StaffId,
            EmailType = createEmailDto.emailType,
            AttachmentUrl = "" ?? imagePath
        };
        if(createEmailDto.emailType == EmailType.Single)
        {
            createEmailDto.ReceiverEmail = createEmailDto.ReceiverEmail;
            createEmailDto.ReceiverName = createEmailDto.ReceiverName;
            var customer = (await _customerRepo.GetbyEmail(createEmailDto.ReceiverEmail)).FirstOrDefault();
            if (customer != null)
            {
                createEmailDto.ReceiverEmail = customer.User.Email;
                createEmailDto.ReceiverName = $"{customer.UserDetails.FirstName} {customer.UserDetails.LastName}";
                email.ReceiverEmail = customer.User.Email;
                email.ReceiverName = $"{customer.UserDetails.FirstName} {customer.UserDetails.LastName}";
                await _emailSend.SendMail(createEmailDto);
            }

        }
        else if(createEmailDto.emailType == EmailType.AllCustomers)
        {
            var customers = await _customerRepo.List();
            if (customers != null)
            {
                foreach (var customer in customers) {
                    createEmailDto.ReceiverEmail = customer.User.Email;
                    createEmailDto.ReceiverName = $"{customer.UserDetails.FirstName} {customer.UserDetails.LastName}";
                    email.ReceiverEmail = customer.User.Email;
                    email.ReceiverName = $"{customer.UserDetails.FirstName} {customer.UserDetails.LastName}";
                    await _emailSend.SendMail(createEmailDto);
                }
            }
        }
        else if (createEmailDto.emailType == EmailType.AllStaffs)
        {
            var staffs = await _staffRepo.List();
            if (staffs != null)
            {
                foreach (var staff in staffs)
                {
                    createEmailDto.ReceiverEmail = staff.User.Email;
                    createEmailDto.ReceiverName = $"{staff.UserDetails.FirstName} {staff.UserDetails.LastName}";
                    email.ReceiverEmail = EmailType.AllStaffs.ToString();
                    email.ReceiverName = EmailType.AllStaffs.ToString();
                    await _emailSend.SendMail(createEmailDto);
                }
            }
        }
        else if (createEmailDto.emailType == EmailType.Everyone)
        {
            var customers = await _customerRepo.List();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    createEmailDto.ReceiverEmail = customer.User.Email;
                    createEmailDto.ReceiverName = $"{customer.UserDetails.FirstName} {customer.UserDetails.LastName}";
                    await _emailSend.SendMail(createEmailDto);
                }
            }
            var staffs = await _staffRepo.List();
            if (staffs != null)
            {
                foreach (var staff in staffs)
                {
                    createEmailDto.ReceiverEmail = staff.User.Email;
                    createEmailDto.ReceiverName = $"{staff.UserDetails.FirstName} {staff.UserDetails.LastName}";
                    await _emailSend.SendMail(createEmailDto);
                }
            }
            email.ReceiverEmail = EmailType.Everyone.ToString();
            email.ReceiverName = EmailType.Everyone.ToString();
        }
        await _repository.Create(email);
        return new BaseResponse()
        {
            Message = "Email Sent Successfully!",
            Status = true,
        };
    }

    public async Task<EmailResponseModel> GetById(int id)
    {
        var email = await _repository.GetById(id);
        if (email != null)
        {
            return new EmailResponseModel{
                Data = await GetDetails(email),
                Message = "Email Retrieved Successfully",
                Status = true,
            };
        }
        return new EmailResponseModel
        {
            Data = null,
            Message = "Unable To Retrieve Email Successfully",
            Status = true,
        };
    }

    public async Task<EmailsResponseModel> GetByEmailType(EmailType emailType)
    {
        var emails = await _repository.GetByEmailType(emailType);
        if (emails != null)
        {
            List<GetEmailDto> getEmails = new List<GetEmailDto>();
            foreach (var email in emails) getEmails.Add(await GetDetails(email));
            return new EmailsResponseModel()
            {
                Data = getEmails,
                Message = "Emails Successfully Retrieved",
                Status = true
            };
        }
        return new EmailsResponseModel()
        {
            Data = null,
            Message = "No Emails Sent Yet!",
            Status = false
        };
    }
    public async Task<EmailsResponseModel> GetByStaffId(int staffId)
    {
        var emails = await _repository.GetByStaffId(staffId);
        if (emails != null)
        {
            List<GetEmailDto> getEmails = new List<GetEmailDto>();
            foreach (var email in emails) getEmails.Add(await GetDetails(email));
            return new EmailsResponseModel()
            {
                Data = getEmails,
                Message = "Emails Successfully Retrieved",
                Status = true
            };
        }
        return new EmailsResponseModel()
        {
            Data = null,
            Message = "No Emails Sent Yet!",
            Status = false
        };
    }
    
    public async Task<EmailsResponseModel> GetByStaffIdEmailType(int staffId, EmailType emailType)
    {
        var emails = await _repository.GetByStaffIdEmailType(staffId, emailType);
        if (emails != null)
        {
            List<GetEmailDto> getEmails = new List<GetEmailDto>();
            foreach (var email in emails) getEmails.Add(await GetDetails(email));
            return new EmailsResponseModel()
            {
                Data = getEmails,
                Message = "Emails Successfully Retrieved",
                Status = true
            };
        }
        return new EmailsResponseModel()
        {
            Data = null,
            Message = "No Emails Sent Yet!",
            Status = false
        };
    }

    public async Task<EmailsResponseModel> GetAllEmails()
    {
        var emails = await _repository.List();
        if (emails != null)
        {
            List<GetEmailDto> getEmails = new List<GetEmailDto>();
            foreach (var email in emails) getEmails.Add( await GetDetails(email));
            return new EmailsResponseModel()
            {
                Data = getEmails,
                Message = "Emails Successfully Retrieved",
                Status = true
            };
        }
        return new EmailsResponseModel()
        {
            Data = null,
            Message = "No Emails Sent Yet!",
            Status = false
        };
    }

    public async Task<GetEmailDto> GetDetails(Email email)
    {
        var roles = await _rolerepository.GetRoleByUserId(email.Staff.User.Id);
        return new GetEmailDto()
        {
            Message = email.Message,
            AttachmentUrl = email.AttachmentUrl,
            ReceiverEmail = email.ReceiverEmail,
            Subject = email.Subject,
            ReceiverName = email.ReceiverName,
            GetStaffDto =  new GetStaffDto()
            {
                Id = email.Staff.Id,
                StaffNo = email.Staff.StaffNo,
                Email = email.Staff.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = email.Staff.UserDetails.FirstName,
                    LastName = email.Staff.UserDetails.LastName,
                    ImageUrl = email.Staff.UserDetails.ImageUrl,
                    Gender = email.Staff.UserDetails.Gender,
                    PhoneNumber = email.Staff.UserDetails.PhoneNumber,
                    GetAddressDto = new GetAddressDto()
                    {
                        NumberLine = email.Staff.UserDetails.Address.NumberLine,
                        Street = email.Staff.UserDetails.Address.Street,
                        City = email.Staff.UserDetails.Address.City,
                        Region = email.Staff.UserDetails.Address.Region,
                        State = email.Staff.UserDetails.Address.State,
                        Country = email.Staff.UserDetails.Address.Country,
                    }
                },
                GetRoleDto = roles.Select(
                role => new GetRoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                }).ToList(),
            }
        };
    }
}
