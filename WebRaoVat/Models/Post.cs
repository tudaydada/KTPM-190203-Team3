using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(256)]
        public string Title { get; set; } = string.Empty;
        [StringLength(1024)]
        public string Description { get; set; } = String.Empty;
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public int CityId { get; set; }
        public virtual Category Category { get; set; }
        [StringLength(1024)]
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; } = DateTime.Now;
        public int ViewCount { get; set; } = 0;
        public bool Status { get; set; } = false;
        public virtual List<Comment> Comments { get; set; }
        public virtual Account Account { get; set; }
        public virtual City City { get; set; }
    }
}
