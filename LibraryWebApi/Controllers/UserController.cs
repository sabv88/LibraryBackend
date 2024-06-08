using LibraryApplication.Books.Queries.GetBookList;
using LibraryApplication.Users.Queries;
using LibraryApplication.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LibraryWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Gets the borrows by UserId
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /user
        /// </remarks>
        /// <returns>Returns GetUserByIdDto</returns>
        /// <response code="200">Success</response>
        
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<GetUserByIdDto>> Get()
        {
            var query = new GetUserByIdQuery
            { 
                Id = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
