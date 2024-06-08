﻿using AutoMapper;
using LibraryApplication.Borrows.Commands.CreateBorrow;
using LibraryWebApi.Models.Borrows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BorrowController : BaseController
    {
        private readonly IMapper _mapper;
        public BorrowController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the borrow of the book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /borrow
        /// {
        ///     BookId: "{9214415A-594F-43B8-A934-BC43BEE8DEB4}",
        ///     ReturnTime: 10.06.2024
        /// }
        /// </remarks>
        /// <param name="createBorrowDto">CreateBookDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        ///         

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CreateBorrowDto createBorrowDto)
        {

            var command = new CreateBorrowCommand
            {
                UserId = UserId,
                BookId = createBorrowDto.BookId,
                TakingTime = DateTime.UtcNow,
                ReturnTime = createBorrowDto.ReturnTime,
            };
            var borrowId = await Mediator.Send(command);
            return Ok(borrowId);
        }
    }
}
