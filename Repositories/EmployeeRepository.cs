using personBeheerSysteem.Data;
using persoonBeheerSysteem.Models;
using System.Collections.Generic;
using System.Linq;

public class EmployeeRepository
{
    private readonly PersonenDbContext _dbContext;

    public EmployeeRepository(PersonenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _dbContext.Employees.ToList();
    }

    public void AddEmployee(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void UpdateEmployee(Employee employee)
    {
        _dbContext.Employees.Update(employee);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void DeleteEmployee(int employeeId)
    {
        var employee = _dbContext.Employees.Find(employeeId);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges(); // Save changes to persist the data
        }
    }
}
