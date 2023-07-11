using Newtonsoft.Json.Linq;
using Vee_Tailoring.Emails;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;
public class TokenService : ITokenService
{
    ITokenRepo _repository;
    IUserRepo _userRepo;
    IEmailSend _email;
    public TokenService(ITokenRepo repository, IUserRepo userRepo, IEmailSend email)
    {
        _repository = repository;
        _userRepo = userRepo;
        _email = email;
    }
    public async Task<bool> GenerateToken(int id, TokenType tokenType)
    {
        var user = await _userRepo.Get(x => x.Id == id);
        if (user != null)
        {
            var getToken = await _repository.Get(x => x.UserId == id && x.TokenType == tokenType && x.IsDeleted == false);
            if (getToken != null)
            {
                getToken.IsDeleted = true;
                await _repository.Update(getToken);
            }
            var generateToken = Guid.NewGuid().GetHashCode().ToString().Substring(0, 6);
            var tokenNo = await CheckTokenStatus(generateToken, tokenType);
            var token = new Token()
            {
                TokenNo = BCrypt.Net.BCrypt.HashPassword(tokenNo),
                TokenType = tokenType,
                TokenStartTime = DateTime.Now,
                TokenEndTime = DateTime.Now.AddMinutes(3.0),
                UserId = id,
            };
            await _repository.Create(token);
            var sendEmail = new CreateEmailDto()
            {
                Subject = $"V Tailoring: {tokenType.ToString()} Token",
                ReceiverName = $"{user.UserName}",
                ReceiverEmail = user.Email,
                Message = $"{tokenType.ToString()} Token Generated! /n" +
                $"Use the token below to initiate your recent {tokenType.ToString()}. /n" +
                $"Token: {generateToken} /n" + "This token expires in 3 minutes. /n" + "Vee Tailoring"
            };
            await _email.SendMail(sendEmail);
            return true;
        }
        return false;
    }
    public async Task<bool> CheckToken(int id, TokenType tokenType, string TokenNo)
    {
        var token = await _repository.Get(x => x.UserId == id && x.IsDeleted == false);
        if (token != null && BCrypt.Net.BCrypt.Verify(TokenNo, token.TokenNo) && token.TokenType == tokenType && token.TokenStartTime < DateTime.Now && DateTime.Now <= token.TokenEndTime)
        {
            token.IsDeleted = true;
            await _repository.Update(token);
            return true;
        }
        return false;
    }
    public async Task<string> CheckTokenStatus(string TokenNo, TokenType tokenType)
    {
        var tokens = await _repository.GetByExpression(x => x.IsDeleted == false && x.TokenType ==tokenType);
        var status = false;
        if(tokens != null)
        {
            foreach(var token in tokens)
            {
                var check =  BCrypt.Net.BCrypt.Verify(TokenNo, token.TokenNo);
                if (check && token.TokenType == tokenType)
                {
                    status = true;
                    break;
                }
            }
            if (status)
            {
                var generateToken = Guid.NewGuid().GetHashCode().ToString().Substring(0, 6);
                await CheckTokenStatus(generateToken, tokenType);
            }
            else
            {
                return TokenNo;
            }
        }
        else if(tokens == null)
        {   
            return TokenNo;
        }
        return null;
    }
}
