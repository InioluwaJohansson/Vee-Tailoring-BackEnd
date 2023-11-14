using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Vee_Tailoring.Models.DTOs;
using System.Text;

namespace Vee_Tailoring.Emails;

public class EmailSender : IEmailSend
{ 
    IConfiguration _configuration;
    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> SendMail(CreateEmailDto email)
    {
        Configuration.Default.ApiKey.Add("api-key", _configuration["EmailSettings:SendInBlueKey"]);
        var apiInstance = new TransactionalEmailsApi();
        string SenderName = $"{_configuration["ApplicationDetails:AppName"]}";
        string SenderEmail = "inioluwa.makinde10@gmail.com";
        SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
        string ToEmail = email.ReceiverEmail;
        string ToName = email.ReceiverName;
        SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);    
        List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
        To.Add(smtpEmailTo);
        string BccName = "Janice Doe";
        string BccEmail = "example2@example2.com";
        SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
        List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
        Bcc.Add(BccData);
        string CcName = "John Doe";
        string CcEmail = "example3@example2.com";
        SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
        List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
        Cc.Add(CcData);
        string HtmlContent = email.Message;
        string TextContent = null;
        string Subject = email.Subject;
        string ReplyToName = $"{_configuration["ApplicationDetails:AppName"]}";
        string ReplyToEmail = "inioluwa.makinde10@gmail.com";
        SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
        string AttachmentUrl = email.AttachmentUrl;
        string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
        byte[] Content = ReturnImageByteData(email.AttachmentUrl);
        string AttachmentName = email.Attachment.Name;
        SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
        List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
        Attachment.Add(AttachmentContent);
        JObject Headers = new JObject();
        Headers.Add($"{_configuration["ApplicationDetails:AppName"]}", "unique-id-1234");
        long? TemplateId = null;
        JObject Params = new JObject();
        Params.Add("parameter", "My param value");
        Params.Add("subject", email.Subject);
        List<string> Tags = new List<string>();
        Tags.Add("mytag");
        SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
        List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
        To1.Add(smtpEmailTo1);
        var g = Guid.NewGuid().ToString();
        Dictionary<string, object> _parmas = new Dictionary<string, object>();
        _parmas.Add(g, Params);
        SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
        SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
        List<SendSmtpEmailMessageVersions> messageVersions = new List<SendSmtpEmailMessageVersions>();
        messageVersions.Add(messageVersion);            
        var sendSmtpEmail = new SendSmtpEmail(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersions, Tags);
        try{
            apiInstance.SendTransacEmail(sendSmtpEmail);
            Configuration.Default.ApiKey.Clear();
            return true;
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        await SendMail(email);
        return true;
    }
    public byte [] ReturnImageByteData(string AttachmentUrl){
        if (System.IO.Directory.Exists(AttachmentUrl))
        {
            return File.ReadAllBytes(AttachmentUrl);
        }
        return null;
    }
} 