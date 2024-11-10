using personBeheerSysteem.Data;
using persoonBeheerSysteem.Models;
using System.Collections.Generic;
using System.Linq;

public class DepartmentRepository
{
    private readonly PersonenDbContext _dbContext;

    public DepartmentRepository(PersonenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _dbContext.Departments.ToList();
    }

    public void AddDepartment(Department department)
    {
        _dbContext.Departments.Add(department);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void UpdateDepartment(Department department)
    {
        _dbContext.Departments.Update(department);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void DeleteDepartment(int departmentId)
    {
        var department = _dbContext.Departments.Find(departmentId);
        if (department != null)
        {
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges(); // Save changes to persist the data
        }
    }
}
