using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRaoVat.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        
        public int PostId { get; set; }
        [StringLength(64)]
        public string Messages { get; set; } = string.Empty;
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
        public virtual Account Account { get; set; }
    }
}
