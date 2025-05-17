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
    private readonly TaskDbContext _context;

    private readonly IMediator _mediator;

    public UserController(TaskDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { UserId = result });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new UsersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
