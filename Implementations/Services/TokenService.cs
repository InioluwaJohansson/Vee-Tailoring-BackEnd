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
            var generateToken = Guid.NewGuid().ToString().Substring(0, 10);
            while (BCrypt.Net.BCrypt.Verify(generateToken, (await _repository.Get(x => x.TokenNo == generateToken)).TokenNo) == true)
            {
                generateToken = Guid.NewGuid().ToString().Substring(0, 10);
            }
            var token = new Token()
            {
                TokenNo = BCrypt.Net.BCrypt.HashPassword(generateToken),
                TokenType = tokenType,
                TokenStartTime = DateTime.Now,
                TokenEndTime = DateTime.Now.AddMinutes(3.0),
            };
            await _repository.Create(token);
            var email = new CreateEmailDto()
            {
                Subject = "Payment Token",
                ReceiverName = $"{user.Customer.UserDetails.LastName} {user.Customer.UserDetails.FirstName}",
                ReceiverEmail = user.Email,
                Message = $"Payment Token Generated! /n" +
                $"Use the token below to initiate your recent payment. /n" +
                $"{generateToken} /n" + "This token expires in 3 minutes. /n" + "Vee Tailoring"
            };
            await _email.SendEmail(email);
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
}
