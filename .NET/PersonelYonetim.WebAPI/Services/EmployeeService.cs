using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetim.WebAPI.Context;
using PersonelYonetim.WebAPI.DTOs;
using PersonelYonetim.WebAPI.Models;

namespace PersonelYonetim.WebAPI.Services;

public sealed class EmployeeService(
    ApplicationDbContext context)
{
    public string Create([FromForm] CreateEmployeeDto request)
    {
        if (request.Avatar.Length <= 0 || request.Avatar.Length >= 1000000)
        {
            throw new ArgumentException("You need to upload files smaller than 1mb");
        }
        request.Avatar.IsItAnImageFileType();

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

        return employee.Id;
    }

    public List<Employee> GetAll()
    {
        var employees = context.Employees
            .AsNoTracking()
            .OrderBy(p => p.FirstName)
            .ToList();

        return employees;
    }

    public void DeleteById(string id)
    {
        Employee? employee = context.Employees.Find(id);
        if (employee is null)
        {
            throw new ArgumentException("Employee not found");
        }

        context.Remove(employee);
        context.SaveChanges();
    }

    public void Update(UpdateEmployeeDto request)
    {
        Employee? employee = context.Employees.Find(request.Id.ToString());
        if (employee is null)
        {
            throw new ArgumentException("Employee not found");
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.StartingDate = request.StartingDate;
        employee.Salary = request.Salary;

        context.SaveChanges();
    }
}
