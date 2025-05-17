using MediatR;
using TaskManagement.DAL;

namespace TaskManagement.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands;



[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskDbContext _context;

    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { TaskId = id });
    }

}
