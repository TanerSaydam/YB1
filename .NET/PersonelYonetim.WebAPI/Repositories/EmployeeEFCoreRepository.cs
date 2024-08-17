using PersonelYonetim.WebAPI.Context;
using PersonelYonetim.WebAPI.Models;

namespace PersonelYonetim.WebAPI.Repositories;

public class EmployeeEFCoreRepository(
    ApplicationDbContext context) : IEmployeeRepository
{
    public void Create(Employee employee)
    {
        context.Add(employee);
    }

    public void Delete(Employee employee)
    {
        context.Remove(employee);
    }

    public List<Employee> GetAll()
    {
        return context.Employees.OrderBy(p => p.FirstName).ToList();
    }

    public Employee? GetById(string id)
    {
        return context.Employees.Find(id);
    }

    public void Update(Employee employee)
    {
        context.Update(employee);
    }
}
