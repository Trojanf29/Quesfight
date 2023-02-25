using System.ComponentModel.DataAnnotations;

namespace QuesFight.Models.UserDTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
        [RegularExpression(@"(?=.*[A-Z].*)(?=.*[a-z].*)(.*[0-9].*)", ErrorMessage = "Password must contain Uppercase, Lowercase and Number")]
        public string Password { get; set; } = null!;
    }
}
