using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Emails;

public interface IEmailSend
{
    Task<bool> SendMail(CreateEmailDto createEmailDto);
}