using System.Security.Claims;
using System.Text;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Authentication;

public interface IJWTAuthentication
{
    string GenerateToken(GetUserDto getUserDto);
}
