using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelApp.WebAPI.Context;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class PersonelsController(
    ApplicationDbContext _context) : ControllerBase
{
    //private readonly ApplicationDbContext _context;
    //public PersonelsController(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    [HttpGet]
    public IActionResult GetAll()
    {
        var personels =
            _context.Personels
            .AsNoTracking()
            .OrderBy(p => p.FirstName)
            //.Select(s => new
            //{
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    FullName = s.FirstName + " " + s.LastName,
            //    DateOfBirth = s.DateOfBirth
            //})
            .ToList();

        return Ok(personels);
    }

    [HttpGet]
    public IActionResult SeedData()
    {
        List<Personel> personels = new();
        for (int i = 0; i < 1000; i++)
        {
            Faker faker = new();
            Personel personel = new()
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                DateOfBirth = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                StartingDate = new DateOnly(2024, faker.Random.Int(1, 12), faker.Random.Int(1, 28)),
                Salary = faker.Random.Decimal(17002, 50000)
            };
            personels.Add(personel);
        }

        _context.AddRange(personels);
        _context.SaveChanges();

        return Ok(new { Message = "Seed data is successful" });
    }
}