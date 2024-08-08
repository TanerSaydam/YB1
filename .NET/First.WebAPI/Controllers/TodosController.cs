using First.WebAPI.ContextModel;
using Microsoft.AspNetCore.Mvc;

namespace First.WebAPI.Controllers;

[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    //primitive tpye => ilkel tipler
    //string, int ,boolean, datetime, decimal, double, float...

    [HttpGet("GetAll/{name}")]
    public IActionResult GetAll(string name, int age)
    {
        new Test().Method();
        Console.WriteLine();
        return Ok();
    }

    [HttpPost("ExampleHttpContext")]
    public IActionResult Example([FromBody] MyHttpContext httpContext)
    {
        //işlemimi yapıyorum


        HttpContextAccessor httpContextAccessor = new();

        httpContext.Response.StatusCode = 200;
        httpContext.Response.Body = new { Message = "Create is sucessfull" };


        httpContextAccessor.HttpContext!.Response.StatusCode = 500;


        return Ok(httpContext);

    }
}


class Test : Test2//Test'im test'2 de public ya da protected olarak verilen her şeye sahip
{
    public override void Method()
    {
        //base.Method();
        Console.WriteLine("bu artık test clasında da çalışıyor");
    }
}

class Test2
{
    public int Id { get; set; }
    private string name { get; set; }
    protected string age { get; set; }

    public virtual void Method()
    {
        Console.WriteLine("Ben test2 de çalışan bir metodun");

        //buraya eklensin
    }
}

interface ITest
{
    int Id { get; set; }
    string name { get; set; }
    string age { get; set; }
}
