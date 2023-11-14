using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interfaces.Services;

public interface ITokenService
{
    Task<bool> GenerateToken(int id, TokenType tokenType);
    Task<bool> CheckToken(int id, TokenType tokenType, string TokenNo);
    Task<int> RefreshToken();
}