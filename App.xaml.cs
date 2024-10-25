using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Windows;

namespace persoonBeheerSysteem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False");
        }
      
    }

}
