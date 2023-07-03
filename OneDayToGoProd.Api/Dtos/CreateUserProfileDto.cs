using System.ComponentModel.DataAnnotations;

namespace OneDayToGoProd.Api.Dtos
{
    public class CreateUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string PersonalNumber { get; set; }

    }
}
