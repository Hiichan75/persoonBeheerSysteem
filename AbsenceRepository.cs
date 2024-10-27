using personBeheerSysteem.Data;
using personBeheerSysteem.Models;
using System.Collections.Generic;
using System.Linq;

public class AbsenceRepository
{
    private readonly PersonenDbContext _dbContext;

    public AbsenceRepository(PersonenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Absence> GetAllAbsences()
    {
        return _dbContext.Absences.ToList();
    }

    public void AddAbsence(Absence absence)
    {
        _dbContext.Absences.Add(absence);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void UpdateAbsence(Absence absence)
    {
        _dbContext.Absences.Update(absence);
        _dbContext.SaveChanges(); // Save changes to persist the data
    }

    public void DeleteAbsence(int absenceId)
    {
        var absence = _dbContext.Absences.Find(absenceId);
        if (absence != null)
        {
            _dbContext.Absences.Remove(absence);
            _dbContext.SaveChanges(); // Save changes to persist the data
        }
    }
}
