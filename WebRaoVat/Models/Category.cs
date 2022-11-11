using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace WebRaoVat.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; } = string.Empty;
        [StringLength(1024)]
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;

        public virtual List<Post> Posts { get; set; }
    }
}
