namespace Todo.WebAPI.Models;

public class Todo
{
    public Todo()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Work { get; set; } = default!;
    public DateOnly DeadLine { get; set; } //sadece tarih alır // 2024-08-10
    //public DateTime DateTime { get; set; } //tarih + saat alır // 2024-08-10 15:33:15.000
    //public TimeOnly TimeOnly { get; set; } //sadece saat alır //15:33:15.000
    //public DateTimeOffset DateTimeOffset { get; set; } //UTC formatlarını alır 2024-08-10 12:33:15.000
}