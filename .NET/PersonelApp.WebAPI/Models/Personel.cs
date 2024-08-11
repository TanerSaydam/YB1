using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelApp.WebAPI.Models;

public sealed class Personel
{
    public Personel()
    {
        Id = Ulid.NewUlid().ToString();
    }
    [Column(TypeName = "varchar(100)")]
    public string Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; } = default!;
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public DateOnly StartingDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Salary { get; set; }
}