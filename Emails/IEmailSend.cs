namespace Vee_Tailoring.Emails;

public interface IEmailSend
{
    Task<bool> SendMail(CreateEmailDto createEmailDto);
    Task<bool> SendEmail(CreateEmailDto createEmailDto);
}