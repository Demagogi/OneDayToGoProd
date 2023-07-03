using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneDayToGoProd.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(11,MinimumLength = 11)]
        public string PersonalNumber { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
        public User user { get; set; }
    }
}
