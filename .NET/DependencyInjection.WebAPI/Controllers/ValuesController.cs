using DependencyInjection.WebAPI.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WebAPI.Controllers;
[Route("/api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpPost]
    [MyAtt]//aop
    public IActionResult Create(Todo todo)
    {
        Console.WriteLine(todo.Work);
        return NoContent();
    }
}

public class Todo
{
    public string Work { get; set; } = default!;
}
