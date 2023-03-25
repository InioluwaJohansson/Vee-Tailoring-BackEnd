namespace V_Tailoring.Models.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public ICollection<GetRoleDto> Role { get; set; } = new HashSet<GetRoleDto>();
    }
    public class UpdateUserDto
    {
        public string Email { get; set; }
    }
    public class UpdateUserPasswordDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class UserLoginResponse : BaseResponse
    {
        public GetUserDto Data { get; set; }
        public string Token { get; set; }
    }
}
