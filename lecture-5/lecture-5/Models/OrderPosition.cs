namespace lecture_5.Models
{
    public class OrderPosition
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}