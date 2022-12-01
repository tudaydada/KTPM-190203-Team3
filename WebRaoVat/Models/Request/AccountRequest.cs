using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.Models.Request
{
    public class AccountRequest
    {
        [Key]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]

        public string Password { get; set; }

        //[NotMapped]
        //[Required]
        //[System.ComponentModel.DataAnnotations.Compare("Password")]
        //public string ConfirmPassword { get; set; }
    }
}
