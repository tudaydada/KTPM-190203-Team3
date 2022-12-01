using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public int PostId { get; set; }

        [StringLength(64)]
        public string Messages { get; set; } = string.Empty;
        
    }
}
