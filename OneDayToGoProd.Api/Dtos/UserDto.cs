using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserProfile profile { get; set; }
    }
}
