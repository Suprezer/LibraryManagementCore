namespace LibraryManagement.Application.DTOs
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
    }
}
