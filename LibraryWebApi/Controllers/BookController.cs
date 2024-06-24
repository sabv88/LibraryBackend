using AutoMapper;
using LibraryApplication.Books.Commands.CreateBook;
using LibraryApplication.Books.Commands.DeleteBook;
using LibraryApplication.Books.Commands.UpdateBook;
using LibraryApplication.Books.Queries.GetBookById;
using LibraryApplication.Books.Queries.GetBookList;
using LibraryApplication.Books.Queries.GetBookListPaginated;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryApplication.Books.Queries.GetBookByISBN;
using LibraryApplication.Books.Queries.GetBooksByAuthor;
using LibraryApplication.Books.Queries.GetBooksSearchByName;
using LibraryApplication.Books.Queries.GetBooksByGenre;
using LibraryApplication.DTOs.Book.Responce;
using LibraryApplication.DTOs.Book.Request;

namespace LibraryWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;
        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of books
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book
        /// </remarks>
        /// <returns>Returns BookList</returns>
        /// <response code="200">Success</response>
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK  )]
        public async Task<ActionResult<BookList>> GetAll(CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(new GetBookListQuery(), cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of books with pagination
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /book
        /// {
        ///     PageNumber: 1,
        ///     PageSize: 2,
        /// }
        /// </remarks>
        /// <param name="getPaginatedBookListQuery">GetPaginatedBookListQuery object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns paginated BookList</returns>
        /// <response code="200">Success</response>

        [HttpGet("paged/{getPaginatedBookListQuery}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookPaginatedList>> GetPaginated([FromQuery] GetPaginatedBookListQuery getPaginatedBookListQuery, CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(getPaginatedBookListQuery, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of books of the author
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/author/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="authorId">Author id (guid)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns all Books of the author </returns>
        /// <response code="200">Success</response>

        [HttpGet("author/{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookByAuthorList>> GetBooksByAuthor(Guid authorId, CancellationToken cancellationToken)
        {
            var query = new GetBookByAuthorQuery(authorId);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of books by genre
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/genre/sampleGenre
        /// </remarks>
        /// <param name="genre">Genre(string)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns Books by genre </returns>
        /// <response code="200">Success</response>

        [HttpGet("genre/{genre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookByGenreList>> GetBooksByGenre(string genre, CancellationToken cancellationToken)
        {
            var query = new GetBooksByGenreQuery(genre);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the book by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Book id (guid)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns GetBookByIdDto</returns>
        /// <response code="200">Success</response>
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetBookByIdDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetBookByIdQuery(id);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the book by ISBN
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/978-3-16-148410-0
        /// </remarks>
        /// <param name="isbn">Book isbn (string)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns GetBookByISBNDto</returns>
        /// <response code="200">Success</response>

        [HttpGet("isbn/{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetBookByISBNDto>> GetISBN(string isbn, CancellationToken cancellationToken)
        {
            var query = new GetBookByISBNQuery(isbn);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Search books by title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/search/bookTitle
        /// </remarks>
        /// <param name="title">Book title (string)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns BookBySearchTitleList</returns>
        /// <response code="200">Success</response>

        [HttpGet("search/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookBySearchTitleList>> SearchByTitle(string title, CancellationToken cancellationToken)
        {
            var query = new GetBooksBySearchTitleQuery(title);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /book
        /// {
        ///     ISBN: "978-3-16-148410-0",
        ///     Title: "All quiet on the western front",
        ///     Genre: "Drama",
        ///     Description: "some text",
        ///     Count: 3,
        ///     ImagePath: "/Files/FileName",
        ///     Author: Author,
        ///     TakingTime: 31.05.2024,
        ///     ReturnTime: 10.06.2024
        /// }
        /// </remarks>
        /// <param name="createBookDto">CreateBookDto object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        ///         

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto, CancellationToken cancellationToken)
        {
            var command = new CreateBookCommand(createBookDto);
            var bookId = await Mediator.Send(command, cancellationToken);
            return Ok(bookId);
        }

        /// <summary>
        /// Update the book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /book
        /// {
        ///     Id: "9214415A-594F-43B8-A934-BC43BEE8DEB4"
        ///     ISBN: "978-3-16-148410-0",
        ///     Title: "Updated book",
        ///     Genre: "Updated genre",
        ///     Description: "Updated text",
        ///     Count: 5,
        ///     ImagePath: "/Files/FileName",
        ///     Author: Author,
        ///     TakingTime: 31.05.2024,
        ///     ReturnTime: 10.06.2024
        /// }
        /// </remarks>
        /// <param name="updateBookDto">UpdateBooktDto object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto, CancellationToken cancellationToken)
        {
            var command = new UpdateBookCommand(updateBookDto);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Deletes the book by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /book/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the book (guid)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteBookCommand(id);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
