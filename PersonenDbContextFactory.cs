using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using personBeheerSysteem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personBeheerSysteem
{
    public class PersonenDbContextFactory : IDesignTimeDbContextFactory<PersonenDbContext>
    {
        public PersonenDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonenDbDev;Integrated Security=True;");

            return new PersonenDbContext(optionsBuilder.Options);
        }
    }
}
