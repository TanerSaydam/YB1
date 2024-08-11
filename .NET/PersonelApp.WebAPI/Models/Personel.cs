namespace PersonelApp.WebAPI.Models;

public sealed class Personel
{
    public Personel()
    {
        Id = Ulid.NewUlid().ToString();
    }
    public string Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName}";
    public string StringSalary => "₺" + Salary.ToString("n2");
    public string StringDateOfBirth => DateOfBirth.ToString("dd.MM.yyyy");
    public DateOnly DateOfBirth { get; set; }
    public DateOnly StartingDate { get; set; }
    public decimal Salary { get; set; }
}