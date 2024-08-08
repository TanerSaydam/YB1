namespace Todo.WebAPI.Models;

public class Todo
{
    public Todo()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Work { get; set; } = default!;
}

//string = null
//int = 0
//boolean = false (0)
//datetime = 01.01.0001 00:00:00
//guid 0000-0000-0000-0000