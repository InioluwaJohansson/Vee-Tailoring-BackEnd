using System.Security.Claims;
using System.Text;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Authentication
{
    public interface IJWTAuthentication
    {
        string GenerateToken(GetUserDto getUserDto);
    }
}
