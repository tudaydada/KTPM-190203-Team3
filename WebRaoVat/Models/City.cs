namespace WebRaoVat.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
}
