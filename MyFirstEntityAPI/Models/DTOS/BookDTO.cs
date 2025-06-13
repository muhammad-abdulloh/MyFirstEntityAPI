namespace MyFirstEntityAPI.Models.DTOS
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
    }
}
