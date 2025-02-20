namespace Library_Lab4.Models
{
    
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
    }
}
