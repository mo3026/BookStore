namespace BookStore.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int PublisherID { get; set; }
    }
}
