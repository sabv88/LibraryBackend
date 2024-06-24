using LibraryDomain.Entities;

namespace LibraryApplication.DTOs.Authors.Responce
{
    public class AuthorLookupDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<LibraryDomain.Entities.Book>? Books { get; set; }
    }
}
