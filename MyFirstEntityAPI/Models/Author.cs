namespace MyFirstEntityAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // one to many ulandi
        public ICollection<Book> Books { get; set; }
    }
}
