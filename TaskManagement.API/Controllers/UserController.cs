using TaskManagement.DAL;
using TaskManagement.Domain;

namespace TaskManagement.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly TaskDbContext _context;

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
}
