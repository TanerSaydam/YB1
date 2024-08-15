using Microsoft.AspNetCore.Mvc;
using PersonelYonetim.WebAPI.DTOs;
using PersonelYonetim.WebAPI.Models;
using PersonelYonetim.WebAPI.Services;

namespace PersonelYonetim.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class EmployeesController(EmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Employee> employees = employeeService.GetAll();
        return Ok(employees);
    }

    [HttpPost]
    public IActionResult Create([FromForm] CreateEmployeeDto request)
    {
        string id = employeeService.Create(request);
        return Ok(new { Message = id });
    }

    [HttpDelete]
    public IActionResult DeleteById(string id)
    {
        employeeService.DeleteById(id);
        return Ok(new { Message = "Employee delete is successful" });
    }

    [HttpPut]
    public IActionResult Update(UpdateEmployeeDto request)
    {
        employeeService.Update(request);
        return Ok(new { Message = "Update is successful" });
    }
}