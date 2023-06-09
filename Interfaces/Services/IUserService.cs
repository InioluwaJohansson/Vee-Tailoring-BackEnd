using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface IUserService
{
    Task<UserLoginResponse> Login(string email, string password);
    Task<BaseResponse> SendPasswordResetEmail(string email);
    Task<BaseResponse> ChangePassword(UpdateUserPasswordDto updateUserPasswordDto);
    Task<BaseResponse> GeneratePasswordResetToken(int id);
    Task<BaseResponse> CheckPasswordResetToken(int id, string TokenNo);
}
