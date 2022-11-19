using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1024)]
        public string Description { get; set; } = String.Empty;
        public string CategoryName { get; set; }
        public string AccountName { get; set; }
        public int CityName { get; set; }

        [StringLength(1024)]
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; } = DateTime.Now;
        public int ViewCount { get; set; } = 0;
    }
}
