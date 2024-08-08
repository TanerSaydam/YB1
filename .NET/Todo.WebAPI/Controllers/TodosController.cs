using Microsoft.AspNetCore.Mvc;
using Todo.WebAPI.Context;
using TodoModel = Todo.WebAPI.Models.Todo;

namespace Todo.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TodosController : ControllerBase
{

    [HttpGet]//API method type
    public IActionResult GetAll()
    {
        ApplicationDbContext context = new();

        List<Models.Todo> todos = context.Todos.ToList();

        return Ok(todos);
    }

    [HttpGet]
    public IActionResult Create(string work)//query params
    {
        ApplicationDbContext context = new();
        bool isWorkExists = context.Todos.Any(val => val.Work.ToLower() == work.ToLower());
        if (isWorkExists)
        {
            return StatusCode(400, "Work already exists");
        }

        TodoModel todo = new();
        todo.Work = work;

        context.Todos.Add(todo);
        context.SaveChanges();

        return Ok("Todo create is successfull");
    }
}