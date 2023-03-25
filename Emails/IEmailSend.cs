namespace V_Tailoring.Emails
{
    public interface IEmailSend
    {
        Task<bool> SendEmail(CreateEmailDto createEmailDto);
    }
}