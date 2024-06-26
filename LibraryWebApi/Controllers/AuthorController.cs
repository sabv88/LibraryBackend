﻿using AutoMapper;
using LibraryApplication.Authors.Commands.CreateAuthor;
using LibraryApplication.Authors.Commands.DeleteAuthor;
using LibraryApplication.Authors.Commands.UpdateAuthor;
using LibraryApplication.Authors.Queries.GetAuthorById;
using LibraryApplication.Authors.Queries.GetAuthorList;
using LibraryApplication.Authors.Queries.GetAuthorListPaginated;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryApplication.DTOs.Authors.Request;

namespace LibraryWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;
        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of authors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /author
        /// </remarks>
        /// <returns>Returns AuthorsList</returns>
        /// <response code="200">Success</response>
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthorList>> GetAll(CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(new GetAuthorListQuery(), cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of authors with pagination
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /author
        /// {
        ///     PageNumber: 1,
        ///     PageSize: 2,
        /// }
        /// </remarks>
        /// <param name="getPaginatedAuthorListQuery">GetPaginatedAuthorListQuery object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns paginated AuthorList</returns>
        /// <response code="200">Success</response>

        [HttpGet]
        [Route("paged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthorPaginatedList>> GetPaginated([FromQuery] GetPaginatedAuthorListQuery getPaginatedAuthorListQuery, CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(getPaginatedAuthorListQuery, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the author by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /author/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Author id (guid)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns GetAuthorByIdDto</returns>
        /// <response code="200">Success</response>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAuthorByIdDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetAuthorByIdQuery(id);
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the author
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /author
        /// {
        ///     Name: "Test name",
        ///     Surname: "Test surname",
        ///     DateOfBirth: 31.05.2000,
        ///     Country: "Test country",
        /// }
        /// </remarks>
        /// <param name="createAuthorDto">CreateBookDto object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        ///         

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto, CancellationToken cancellationToken)
        {
            var command = new CreateAuthorCommand(createAuthorDto);
            var authorId = await Mediator.Send(command, cancellationToken);
            return Ok(authorId);
        }

        /// <summary>
        /// Update the author
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /author
        /// {
        ///     Name: "Updated name",
        ///     Surname: "Updated surname",
        ///     DateOfBirth: 31.05.2002,
        ///     Country: "Updated country",
        /// }
        /// </remarks>
        /// <param name="updateAuthorDto">UpdateBooktDto object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>


        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto, CancellationToken cancellationToken)
        {
            var command = new UpdateAuthorCommand(updateAuthorDto);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Deletes the author by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /author/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the author (guid)</param>
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
            var command = new DeleteAuthorCommand(id);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
