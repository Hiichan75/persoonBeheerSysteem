using Microsoft.EntityFrameworkCore;
using personBeheerSysteem.Data;
using personBeheerSysteem.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using persoonBeheerSysteem;


namespace personBeheerSysteem
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly DepartmentRepository _departmentRepo;
        private readonly AbsenceRepository _absenceRepo;

        public MainWindow()
        {
            InitializeComponent();
            
            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");

            var dbContext = new PersonenDbContext(optionsBuilder.Options);
            _employeeRepo = new EmployeeRepository(dbContext);
            _departmentRepo = new DepartmentRepository(dbContext);
            _absenceRepo = new AbsenceRepository(dbContext);

            LoadData();
            LoadComboBoxData();
        }


        private void EmployeeFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_employeeRepo == null) return; // Ensure _employeeRepo is initialized

            var filterText = EmployeeFilterTextBox.Text.ToLower();
            EmployeeDataGrid.ItemsSource = _employeeRepo.GetAllEmployees()
                .Where(emp => emp.Name.ToLower().Contains(filterText)).ToList();
        }


        private void DepartmentFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_departmentRepo == null) return; // Ensure _departmentRepo is initialized

            var filterText = DepartmentFilterTextBox.Text.ToLower();
            DepartmentDataGrid.ItemsSource = _departmentRepo.GetAllDepartments()
                .Where(dept => dept.DepartmentName.ToLower().Contains(filterText)).ToList();
        }

        private void AbsenceFilterDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_absenceRepo == null) return; // Ensure _absenceRepo is initialized

            var selectedDate = AbsenceFilterDatePicker.SelectedDate;
            if (selectedDate.HasValue)
            {
                AbsenceDataGrid.ItemsSource = _absenceRepo.GetAllAbsences()
                    .Where(abs => abs.Date.Date == selectedDate.Value.Date).ToList();
            }
            else
            {
                AbsenceDataGrid.ItemsSource = _absenceRepo.GetAllAbsences();
            }
        }




        private void LoadComboBoxData()
        {
            // Populate the EmployeeDepartmentComboBox with a list of departments
            EmployeeDepartmentComboBox.ItemsSource = _departmentRepo.GetAllDepartments();
            AbsenceEmployeeComboBox.ItemsSource = _employeeRepo.GetAllEmployees();
        }

        private void LoadData()
        {
            try
            {
                EmployeeDataGrid.ItemsSource = _employeeRepo.GetAllEmployees();
                DepartmentDataGrid.ItemsSource = _departmentRepo.GetAllDepartments();
                AbsenceDataGrid.ItemsSource = _absenceRepo.GetAllAbsences();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // Placeholder simulation for TextBox controls
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;

                // Set the placeholder text for each TextBox
                if (textBox == EmployeeNameTextBox) textBox.Text = "Employee Name";
                if (textBox == EmployeeContactTextBox) textBox.Text = "Contact Info";
                if (textBox == EmployeeSalaryTextBox) textBox.Text = "Salary";
                if (textBox == DepartmentNameTextBox) textBox.Text = "Department Name";
                if (textBox == AbsenceReasonTextBox) textBox.Text = "Reason for Absence";
            }
        }

        // Employee CRUD methods
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newEmployee = new Employee
                {
                    Name = EmployeeNameTextBox.Text,
                    ContactInfo = EmployeeContactTextBox.Text,
                    Salary = decimal.Parse(EmployeeSalaryTextBox.Text),
                    DepartmentID = (int)EmployeeDepartmentComboBox.SelectedValue
                };
                _employeeRepo.AddEmployee(newEmployee);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}");
            }
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                try
                {
                    selectedEmployee.Name = EmployeeNameTextBox.Text;
                    selectedEmployee.ContactInfo = EmployeeContactTextBox.Text;
                    selectedEmployee.Salary = decimal.Parse(EmployeeSalaryTextBox.Text);
                    selectedEmployee.DepartmentID = (int)EmployeeDepartmentComboBox.SelectedValue;

                    _employeeRepo.UpdateEmployee(selectedEmployee);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing employee: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                try
                {
                    _employeeRepo.DeleteEmployee(selectedEmployee.EmployeeID);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }

        // Department CRUD methods
        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newDepartment = new Department
                {
                    DepartmentName = DepartmentNameTextBox.Text
                };
                _departmentRepo.AddDepartment(newDepartment);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding department: {ex.Message}");
            }
        }

        private void EditDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentDataGrid.SelectedItem is Department selectedDepartment)
            {
                try
                {
                    selectedDepartment.DepartmentName = DepartmentNameTextBox.Text;
                    _departmentRepo.UpdateDepartment(selectedDepartment);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing department: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a department to edit.");
            }
        }

        private void DeleteDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentDataGrid.SelectedItem is Department selectedDepartment)
            {
                try
                {
                    _departmentRepo.DeleteDepartment(selectedDepartment.DepartmentID);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting department: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a department to delete.");
            }
        }

        // Absence CRUD methods
        private void AddAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newAbsence = new Absence
                {
                    EmployeeID = (int)AbsenceEmployeeComboBox.SelectedValue,
                    Date = AbsenceDatePicker.SelectedDate.GetValueOrDefault(),
                    Reason = AbsenceReasonTextBox.Text
                };
                _absenceRepo.AddAbsence(newAbsence);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding absence: {ex.Message}");
            }
        }

        private void EditAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AbsenceDataGrid.SelectedItem is Absence selectedAbsence)
            {
                try
                {
                    selectedAbsence.EmployeeID = (int)AbsenceEmployeeComboBox.SelectedValue;
                    selectedAbsence.Date = AbsenceDatePicker.SelectedDate.GetValueOrDefault();
                    selectedAbsence.Reason = AbsenceReasonTextBox.Text;

                    _absenceRepo.UpdateAbsence(selectedAbsence);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing absence: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an absence to edit.");
            }
        }

        private void DeleteAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AbsenceDataGrid.SelectedItem is Absence selectedAbsence)
            {
                try
                {
                    _absenceRepo.DeleteAbsence(selectedAbsence.AbsenceID);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting absence: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an absence to delete.");
            }
        }

        private void AbsenceEmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // You can add any logic here if needed for when the selection changes
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AbsenceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
