using Microsoft.AspNetCore.Mvc;
using PersonelYonetim.WebAPI.DTOs;
using PersonelYonetim.WebAPI.Models;
using PersonelYonetim.WebAPI.Repositories;

namespace PersonelYonetim.WebAPI.Services;

public sealed class EmployeeService(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork
    )
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

        employeeRepository.Create(employee);
        unitOfWork.SaveChanges();

        return employee.Id;
    }

    public List<Employee> GetAll()
    {
        var employees = employeeRepository.GetAll();

        return employees;
    }

    public void DeleteById(string id)
    {
        Employee? employee = employeeRepository.GetById(id);
        if (employee is null)
        {
            throw new ArgumentException("Employee not found");
        }

        employeeRepository.Delete(employee);
        unitOfWork.SaveChanges();
    }

    public void Update(UpdateEmployeeDto request)
    {
        Employee? employee = employeeRepository.GetById(request.Id.ToString());
        if (employee is null)
        {
            throw new ArgumentException("Employee not found");
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.StartingDate = request.StartingDate;
        employee.Salary = request.Salary;

        employeeRepository.Update(employee);
        unitOfWork.SaveChanges();
    }
}
