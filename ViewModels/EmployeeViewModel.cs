using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using personBeheerSysteem.Data;
using persoonBeheerSysteem.Models;

namespace persoonBeheerSysteem.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeRepository _employeeRepository;
        private ObservableCollection<Employee>? _employees;

        public EmployeeViewModel(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            LoadEmployees();
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private void LoadEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            Employees = new ObservableCollection<Employee>(employees);
        }

        // Command to add a new Employee
        public void AddEmployee(Employee newEmployee)
        {
            _employeeRepository.AddEmployee(newEmployee);
            LoadEmployees();
        }

        // Command to edit an Employee
        public void EditEmployee(Employee updatedEmployee)
        {
            _employeeRepository.UpdateEmployee(updatedEmployee);
            LoadEmployees();
        }

        // Command to delete an Employee
        public void DeleteEmployee(int employeeID)
        {
            _employeeRepository.DeleteEmployee(employeeID);
            LoadEmployees();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
