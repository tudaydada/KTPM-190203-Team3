using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]


        public int RoleId { get; set; }
        public int CityName { get; set; }

        public int commentId { get; set; }
        public string commentMessage { get; set; }

    }
}
