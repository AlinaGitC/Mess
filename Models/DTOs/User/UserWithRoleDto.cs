namespace AppClient.Models.DTOs.User
{
    public class UserWithRoleDto : UserDto
    {
        public string ChatRole { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
