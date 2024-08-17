using PersonelYonetim.WebAPI.Models;

namespace PersonelYonetim.WebAPI.Repositories;

public interface IEmployeeRepository
{
    void Create(Employee employee);
    List<Employee> GetAll();
    void Delete(Employee employee);
    void Update(Employee employee);
    Employee? GetById(string id);
}

