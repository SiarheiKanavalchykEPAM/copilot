using System.ComponentModel.DataAnnotations;

namespace bookDestributedLibrary.Application.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters long")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain letters and numbers")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 characters long")]
        [RegularExpression(@"^[a-zA-Z0-9@.]+$", ErrorMessage = "Email can only contain letters, numbers, @ and .")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters long")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password can only contain letters and numbers")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters long")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password can only contain letters and numbers")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}