using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.WebAPI.Context;
using Todo.WebAPI.DTOs;
using TodoModel = Todo.WebAPI.Models.Todo;

namespace Todo.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ApplicationDbContext context;
    public TodosController()
    {
        context = new();
    }

    [HttpGet]//API method type
    public IActionResult GetAll()
    {
        List<Models.Todo> todos = context.Todos.AsNoTracking().ToList();

        return Ok(todos);
    }

    [HttpPost]
    public IActionResult Create(CreateTodoDto request)
    {
        bool isWorkExists = context.Todos.Any(val => val.Work.ToLower() == request.Work.ToLower());
        if (isWorkExists)
        {
            return StatusCode(400, new { Message = "Work already exists" });
        }

        TodoModel todo = new();
        todo.Work = request.Work;
        todo.DeadLine = request.DeadLine;

        context.Todos.Add(todo);
        context.SaveChanges();

        return Ok(new { Message = "Todo create is successfull" });
    }

    [HttpDelete]
    public IActionResult DeleteById(Guid id)
    {
        TodoModel? todo = context.Todos.Find(id);

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo not found" });
        }

        //context.Todos.Remove(todo);

        todo.IsDeleted = true;
        context.SaveChanges();

        return Ok(new { Message = "Delete was successful" });
    }

    [HttpPut]
    public IActionResult Update(UpdateTodoDto request)
    {
        TodoModel? todo = context.Todos.Find(request.Id);//tracking mekanızmasını kapatmadıysak

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo not found" });
        }


        todo.Work = request.Work;
        todo.DeadLine = request.DeadLine;

        //context.Update(todo);//şunu illa yazmamıza gerek yok// tracking mekanızması açıksa buna ihtiyacımız yok
        context.SaveChanges();

        return Ok(new { Message = "Todo update was successful" });
    }
}
