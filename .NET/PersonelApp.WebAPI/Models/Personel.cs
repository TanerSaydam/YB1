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
    public DateOnly DateOfBirth { get; set; }
    public DateOnly StartingDate { get; set; }
    public decimal Salary { get; set; }
}