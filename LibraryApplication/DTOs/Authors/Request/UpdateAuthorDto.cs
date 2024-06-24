using LibraryApplication.Authors.Commands.UpdateAuthor;
using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTOs.Authors.Request
{
    public class UpdateAuthorDto
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<BookForCreateOrUpdateAuthorDto>? Books { get; set; } = new();
    }
}
