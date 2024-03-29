﻿using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Emails;
using sib_api_v3_sdk.Model;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;

public class UserService : IUserService
{
    IUserRepo _repository;
    IRoleRepo _roleRepo;
    IEmailSend _emailSend;
    ITokenService _tokenService;
    IConfiguration _configuration;
    public UserService(IUserRepo repository, IRoleRepo roleRepo, IEmailSend emailSend, ITokenService tokenService, IConfiguration configuration)
    {
        _repository = repository;
        _roleRepo = roleRepo;
        _emailSend = emailSend;
        _tokenService = tokenService;
        _configuration = configuration;
    }
    public async Task<UserLoginResponse> Login(string email, string password)
    {
        var user = await _repository.Get(c => c.Email == email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            var roles = await _roleRepo.GetRoleByUserId(user.Id);
            return new UserLoginResponse()
            {
                Data = new GetUserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = roles.Select(role => new GetRoleDto()
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description,
                    }).ToList(),
                },
                Message = "Login Successful",
                Status = true,
            };
        }
        return new UserLoginResponse()
        {
            Data = null,
            Message = "Invalid Email Or Password!",
            Status = false
        };
    }
    public async Task<BaseResponse> SendPasswordResetEmail(string email)
    {
        var user = await _repository.Get(c => c.Email == email);
        if (user != null)
        {
            DateTime resetDate = DateTime.Now.AddMinutes(5);
            string token = Guid.NewGuid().ToString().Substring(0, 32);
            string token2 = Guid.NewGuid().ToString().Substring(0, 32);
            string passwordLink = $"http://127.0.0.1:5500/Recovery/PasswordAuth.html?{token}{token2}?{resetDate}?{user.Id}?{token}{token2}";
            var sendEmail = new CreateEmailDto()
            {
                Subject = $"{_configuration["ApplicationDetails:AppName"]} Account Password Recovery",
                ReceiverName = $"{user.UserName}",
                ReceiverEmail = user.Email,
                Message = $"Click the link below to reset your Password. /n" +
                $"<a href={passwordLink} >Click Here<a>" + 
                $"/n This link expires in 3 minutes. /n {_configuration["ApplicationDetails:AppName"]} Management",
            };
            await _emailSend.SendMail(sendEmail);
            return new BaseResponse()
            {
                Message = $"A Password Reset Link Has Been Sent To {email}, {passwordLink}",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Find Email",
            Status = false
        };
    }
    public async Task<BaseResponse> ChangePassword(UpdateUserPasswordDto updateUserPasswordDto)
    {
        var user = await _repository.Get(c => c.Id == updateUserPasswordDto.Id);
        if (user != null && updateUserPasswordDto.Password == updateUserPasswordDto.RePassword)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserPasswordDto.Password);
            await _repository.Update(user);
            return new BaseResponse()
            {
                Message = "Password Changed Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Non Matching Passwords",
            Status = false
        };
    }
    public async Task<BaseResponse> GeneratePasswordResetToken(int id)
    {
        var status = await _tokenService.GenerateToken(id, TokenType.ResetPassword);
        if (status == true)
        {
            return new BaseResponse()
            {
                Message = "Token Generated Successfully!",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Generate Token!",
            Status = false
        };
    }
    public async Task<BaseResponse> CheckPasswordResetToken(int id, string TokenNo)
    {
        var status = await _tokenService.CheckToken(id, TokenType.ResetPassword, TokenNo);
        if (status == true)
        {
            return new BaseResponse()
            {
                Message = "Token Verified Successfully!",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Verify Token Successfully!",
            Status = false
        };
    }
}
