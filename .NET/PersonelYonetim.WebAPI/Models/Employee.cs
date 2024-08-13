namespace PersonelYonetim.WebAPI.Models;

public sealed class Employee
{
    public Employee()
    {
        Id = Ulid.NewUlid().ToString();
    }
    public string Id { get; set; }
    public string AvatarFileName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly DateOfBirth { get; set; }
    public DateOnly StartingDate { get; set; }
    public decimal Salary { get; set; }
}