using Exception.WebAPI.Middlewares;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

var app = builder.Build();

app.MapGet("/", () =>
{
    int a = 5;
    int b = 0;

    //if (b == 0)
    //{
    //    Result result = new()
    //    {
    //        ErrorMessage = "B cannot be zero!",
    //        IsSuccessful = false
    //    };

    //    return Results.BadRequest(result);
    //    //throw new CannotBeZeroException();
    //    //throw new ArgumentException("B cannot be zero!");
    //}

    int c = a / b;

    Result<int> result1 = Result<int>.Succeed(c);

    return Results.Ok(result1);
});

app.MapGet("/test", () => Result<string>.Succeed("hello world!"));

app.UseExceptionHandler();
//app.UseMyMiddleware();

//app.UseMiddleware<ExceptionMiddleware>();

//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (Exception ex)
//    {
//        context.Response.StatusCode = 409;
//        context.Response.ContentType = "application/json";// MediaTypeNames.Application.Json;


//        ErrorResponse error = new(ex.Message);


//        await context.Response.WriteAsync(error.ToString());
//    }
//});

app.Run();

record ErrorResponse(string Message)
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}



class Result<T>
{
    private Result(T data)
    {
        Data = data;
        IsSuccessful = true;
        StatusCode = 200;
    }

    private Result(string message, int statusCode = 400)
    {
        ErrorMessage = message;
        IsSuccessful = false;
        StatusCode = statusCode;
    }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccessful { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Result<T> Succeed(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(message, 500);
    }
}

class CannotBeZeroException : System.Exception
{
    public CannotBeZeroException() : base("B cannot be zero!")
    {

    }
}