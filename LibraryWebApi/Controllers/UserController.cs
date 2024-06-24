using LibraryApplication.DTOs.Users.Request;
using LibraryApplication.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        /// <response code="201">Success</response>
        
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserByIdDto>> Get(CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery
            { 
                Id = UserId
            };
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }
    }
}
