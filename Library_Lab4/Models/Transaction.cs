namespace Library_Lab4.Models
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime TransactionDate { get; set; }
        public abstract void Execute();

    }
}
