using System.ComponentModel.DataAnnotations;

namespace OppositeEnds.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Required]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// This bool verified is for email verification.
        /// </summary>
        public bool verified { get; set; }
        
    }
}