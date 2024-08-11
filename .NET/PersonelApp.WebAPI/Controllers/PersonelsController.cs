using Microsoft.AspNetCore.Mvc;
using PersonelApp.WebAPI.Context;

namespace PersonelApp.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PersonelsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var personels = _context.Personels.ToList();
        return Ok(personels);
    }
}