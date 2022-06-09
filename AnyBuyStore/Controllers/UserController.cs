﻿

using AnyBuyStore.Core.Handlers.UserHandler.Commands.AddUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.DeleteUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.UpdateUser;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    
    public class UserController : BaseApiController
    {
        public UserController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand { Id = id }, cancellationToken));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }


    }

}


