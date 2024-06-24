using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookByISBN
{
    public record GetBookByISBNQuery(string ISBN) : IRequest<GetBookByISBNDto>;
}