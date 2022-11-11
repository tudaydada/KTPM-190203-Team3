namespace WebRaoVat.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> Account { get; set; }
    }
}
