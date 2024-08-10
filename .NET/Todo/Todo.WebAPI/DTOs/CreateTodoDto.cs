namespace Todo.WebAPI.DTOs;

public class CreateTodoDto
{
    public string Work { get; set; } = default!;
    public DateOnly DeadLine { get; set; }
}
