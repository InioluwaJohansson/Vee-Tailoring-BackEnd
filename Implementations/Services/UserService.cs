using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;
using System;
using V_Tailoring.Emails;

namespace V_Tailoring.Implementations.Services
{
    public class UserService : IUserService
    {
        IUserRepo _repository;
        IRoleRepo _roleRepo;
        IEmailSend _emailSend;
        public UserService(IUserRepo repository, IRoleRepo roleRepo, IEmailSend emailSend)
        {
            _repository = repository;
            _roleRepo = roleRepo;
            _emailSend = emailSend;
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
                Message = "Invalid Email Or Password",
                Status = false
            };
        }
        public async Task<BaseResponse> SendPasswordResetEmail(string email)
        {
            var user = await _repository.Get(c => c.Email == email);
            if (user != null)
            {
                string passwordLink = $"http://127.0.0.1:5500/Recovery/PasswordRecovery.html?id={user.Id}";
                var sendEmail = new CreateEmailDto()
                {
                    Subject = "V Tailoring Account Password Recovery",
                    ReceiverName = $"{user.UserName}",
                    ReceiverEmail = user.Email,
                    Message = $"Click the link below to reset your Password. /n" +
                    $"<a href={passwordLink} >Click Here<a>",
                };
                var response = await _emailSend.SendEmail(sendEmail);
                return new BaseResponse()
                {
                    Message = $"A Password Reset Link Has Been Sent To {email}",
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
        public async Task<BaseResponse> GenerateReCAPCHA()
        {
            string Upper = Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 4).ToUpper();
            string Lower = Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 3).ToLower();
            return new BaseResponse
            {
                Message = Upper + Lower,
                Status = true,
            };
        }
    }
}
