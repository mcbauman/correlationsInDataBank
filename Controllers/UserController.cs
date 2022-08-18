using DataBaseCorrelations.Data;
using DataBaseCorrelations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Controllers;

// [ApiController]
// [Route("/[Controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("/getUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.User.Include(c => c.Items).ThenInclude(x => x.Item).ToListAsync();
        return Ok(users);
    }

    // [HttpGet("/login")]
    // public async Task<IActionResult> Login([FromBody] UserClass reqBody)
    // {
    //     return Ok(reqBody);
    // }

    [HttpPost("/create")]
    public async Task<IActionResult> SignUp([FromBody] UserClass reqBody)
    {
        _context.User.Add(reqBody);
        await _context.SaveChangesAsync();
        return Ok("New User Created");
    }
}