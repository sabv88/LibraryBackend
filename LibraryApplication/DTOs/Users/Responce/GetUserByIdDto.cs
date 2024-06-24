using AutoMapper;
using LibraryDomain.Entities;

namespace LibraryApplication.DTOs.Users.Request
{
    public class GetUserByIdDto
    {
        public List<Borrow>? Borrows { get; set; }
    }
}
