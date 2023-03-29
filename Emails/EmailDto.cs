namespace Vee_Tailoring.Emails;

public class CreateEmailDto
{
    public string ReceiverName{get; set;}
    public string ReceiverEmail{get; set;}
    public string Message{get; set;}
    public string Subject{get; set;}
} 
public class EmailResponseModel
{
    public string Message{get; set;}
} 