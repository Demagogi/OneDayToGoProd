using System.ComponentModel.DataAnnotations.Schema;

namespace OneDayToGoProd.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserProfile profile { get; set; }
    }
}
