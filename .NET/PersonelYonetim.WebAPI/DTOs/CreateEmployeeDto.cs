namespace PersonelYonetim.WebAPI.DTOs;

public sealed record CreateEmployeeDto(
    IFormFile Avatar,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    DateOnly StartingDate,
    decimal Salary);
