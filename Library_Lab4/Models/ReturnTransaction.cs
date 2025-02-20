namespace Library_Lab4.Models
{
    public class ReturnTransaction : Transaction
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public override void Execute()
        {
            Book.Quantity += 1;
        }
    }
}
