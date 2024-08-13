using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetim.WebAPI.Context;
using PersonelYonetim.WebAPI.DTOs;
using PersonelYonetim.WebAPI.Models;

namespace PersonelYonetim.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class EmployeesController(
    ApplicationDbContext context) : ControllerBase
{//Ubiquitous Language
    [HttpGet]
    public IActionResult GetAll()
    {
        var personels =
            context.Employees
            .AsNoTracking()
            .OrderBy(p => p.FirstName)
            .ToList();

        return Ok(personels);
    }

    [HttpPost]
    public IActionResult Create([FromForm] CreateEmployeeDto request)
    {
        string fileName = string.Join(".", DateTime.Now.ToFileTime().ToString(), request.Avatar.FileName);
        using (var stream = System.IO.File.Create($"wwwroot/avatars/{fileName}"))
        {
            request.Avatar.CopyTo(stream);
        }

        Employee employee = new()
        {
            AvatarFileName = fileName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            StartingDate = request.StartingDate,
            Salary = request.Salary,
        };

        context.Add(employee);
        context.SaveChanges();

        return Ok(new { Message = employee.Id });
    }

    [HttpDelete]
    public IActionResult DeleteById(string id)
    {
        Employee? employee = context.Employees.Find(id);
        if (employee is null)
        {
            return BadRequest(new { Message = "Employee not found" });
        }

        context.Remove(employee);
        context.SaveChanges();

        return Ok(new { Message = "Employee delete is successful" });
    }

    [HttpPut]
    public IActionResult Update(UpdateEmployeeDto request)
    {
        Employee? employee = context.Employees.Find(request.Id.ToString());
        if (employee is null)
        {
            return BadRequest(new { Message = "Employee not found" });
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.StartingDate = request.StartingDate;
        employee.Salary = request.Salary;

        context.SaveChanges();
        return Ok(new { Message = "Update is successful" });
    }

    [HttpGet]
    public IActionResult SeedData()
    {
        List<Employee> personels = new();
        for (int i = 0; i < 1000; i++)
        {
            Faker faker = new();
            Employee personel = new()
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                DateOfBirth = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                StartingDate = new DateOnly(2024, faker.Random.Int(1, 12), faker.Random.Int(1, 28)),
                Salary = faker.Random.Decimal(17002, 50000)
            };
            personels.Add(personel);
        }

        context.AddRange(personels);
        context.SaveChanges();

        return Ok(new { Message = "Seed data is successful" });
    }
}