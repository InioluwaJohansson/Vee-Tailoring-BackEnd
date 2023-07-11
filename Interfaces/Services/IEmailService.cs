using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interfaces.Services;
public interface IEmailService
{
    Task<BaseResponse> Create(CreateEmailDto createEmailDto);
    Task<EmailResponseModel> GetById(int id);
    Task<EmailsResponseModel> GetByEmailType(EmailType emailType);
    Task<EmailsResponseModel> GetByStaffId(int staffId);
    Task<EmailsResponseModel> GetByStaffIdEmailType(int staffId, EmailType emailType);
    Task<EmailsResponseModel> GetAllEmails();
}
