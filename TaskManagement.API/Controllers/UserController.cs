using TaskManagement.DAL;
using TaskManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Validators;
using System;
using System.Threading.Tasks;
using TaskManagement.Application.Queries;

namespace TaskManagement.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new UsersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { UserId = result });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;
        return await _mediator.Send(command) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
        => await _mediator.Send(new DeleteUserCommand { Id = id }) ? Ok() : NotFound();
}
