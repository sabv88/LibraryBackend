using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.DTOs.Book.Request
{
    public class CreateBookDto
    {
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? ImagePath { get; set; }
        public List<AuthorForCreateOrUpdatBookDto>? Authors { get; set; } = new();
    }
}
