namespace PersonelYonetim.WebAPI.DTOs;

public sealed record UpdateEmployeeDto(
    Ulid Id,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    DateOnly StartingDate,
    decimal Salary);