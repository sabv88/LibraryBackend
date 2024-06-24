using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTOs.Authors.Request
{
    public class CreateAuthorDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<BookForCreateOrUpdateAuthorDto>? Books { get; set; } = new();
    }
}
