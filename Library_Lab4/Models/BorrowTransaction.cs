namespace Library_Lab4.Models
{
    public class BorrowTransaction : Transaction
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public override void Execute()
        {
            if (Book.Quantity > 0)
            {
                Book.Quantity -= 1;
            }
        }
    }
}
