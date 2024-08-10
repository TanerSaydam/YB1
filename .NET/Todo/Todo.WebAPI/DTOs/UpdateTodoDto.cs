namespace Todo.WebAPI.DTOs;

public class UpdateTodoDto
{
    public Guid Id { get; set; }
    public string Work { get; set; } = default!;
    public DateOnly DeadLine { get; set; }
}