using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using personBeheerSysteem.Data;
using persoonBeheerSysteem.Models;
using persoonBeheerSysteem.ViewModels;

namespace personBeheerSysteem
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly DepartmentRepository _departmentRepo;
        private readonly AbsenceRepository _absenceRepo;
        private EmployeeViewModel _employeeViewModel;

        public MainWindow()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonenDbDev;Integrated Security=True;");

            var dbContext = new PersonenDbContext(optionsBuilder.Options);
            _employeeRepo = new EmployeeRepository(dbContext);
            _departmentRepo = new DepartmentRepository(dbContext);
            _absenceRepo = new AbsenceRepository(dbContext);

            var employeeViewModel = new EmployeeViewModel(_employeeRepo);
            var departmentViewModel = new DepartmentViewModel(_departmentRepo);
            var absenceViewModel = new AbsenceViewModel(_absenceRepo);

            // Set the DataContexts for each tab
            EmployeeTab.DataContext = employeeViewModel;
            DepartmentTab.DataContext = departmentViewModel;
            AbsenceTab.DataContext = absenceViewModel;

            Refresh(); // Initial load of data for all controls
        }

        // Method to refresh data for all ComboBoxes and DataGrids
        private void Refresh()
        {
            LoadData();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
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

        // Single Refresh button event handler for all data
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        // Filter methods for employees, departments, and absences
        private void EmployeeFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_employeeRepo == null) return;

            var filterText = EmployeeFilterTextBox.Text.ToLower();
            EmployeeDataGrid.ItemsSource = _employeeRepo.GetAllEmployees()
                .Where(emp => emp.Name.ToLower().Contains(filterText)).ToList();
        }

        private void DepartmentFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_departmentRepo == null) return;

            var filterText = DepartmentFilterTextBox.Text.ToLower();
            DepartmentDataGrid.ItemsSource = _departmentRepo.GetAllDepartments()
                .Where(dept => dept.DepartmentName.ToLower().Contains(filterText)).ToList();
        }

        private void AbsenceFilterDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_absenceRepo == null) return;

            var selectedDate = AbsenceFilterDatePicker.SelectedDate;
            AbsenceDataGrid.ItemsSource = selectedDate.HasValue
                ? _absenceRepo.GetAllAbsences().Where(abs => abs.Date.Date == selectedDate.Value.Date).ToList()
                : _absenceRepo.GetAllAbsences();
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

                if (textBox == EmployeeNameTextBox) textBox.Text = "Employee Name";
                if (textBox == EmployeeContactTextBox) textBox.Text = "Contact Info";
                if (textBox == EmployeeSalaryTextBox) textBox.Text = "Salary";
                if (textBox == DepartmentNameTextBox) textBox.Text = "Department Name";
                if (textBox == AbsenceReasonTextBox) textBox.Text = "Reason for Absence";
            }
        }

        // Context Menu Clear Handlers
        private void ClearEmployeeName_Click(object sender, RoutedEventArgs e)
        {
            EmployeeNameTextBox.Clear();
        }

        private void ClearEmployeeContact_Click(object sender, RoutedEventArgs e)
        {
            EmployeeContactTextBox.Clear();
        }

        private void ClearEmployeeFilter_Click(object sender, RoutedEventArgs e)
        {
            EmployeeFilterTextBox.Clear();
        }

        private void ClearEmployeeSalary_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSalaryTextBox.Clear();
        }

        // Employee CRUD methods
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(EmployeeSalaryTextBox.Text, out decimal salary) && EmployeeDepartmentComboBox.SelectedValue != null)
            {
                var newEmployee = new Employee
                {
                    Name = EmployeeNameTextBox.Text,
                    ContactInfo = EmployeeContactTextBox.Text,
                    Salary = salary,
                    DepartmentID = (int)EmployeeDepartmentComboBox.SelectedValue
                };
                _employeeRepo.AddEmployee(newEmployee);
                Refresh();
            }
            else
            {
                MessageBox.Show("Invalid input. Please check the salary and department fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                try
                {
                    if (EmployeeDepartmentComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Please select a department for the employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Ensure the Salary field is not empty and contains a valid decimal value.
                    if (string.IsNullOrWhiteSpace(EmployeeSalaryTextBox.Text) || !decimal.TryParse(EmployeeSalaryTextBox.Text, out decimal salary))
                    {
                        MessageBox.Show("Please enter a valid salary for the employee (numeric value).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Check if employee name and contact info are also provided.
                    if (string.IsNullOrWhiteSpace(EmployeeNameTextBox.Text))
                    {
                        MessageBox.Show("Please enter a name for the employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(EmployeeContactTextBox.Text))
                    {
                        MessageBox.Show("Please enter contact information for the employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    selectedEmployee.Name = EmployeeNameTextBox.Text;
                    selectedEmployee.ContactInfo = EmployeeContactTextBox.Text;
                    selectedEmployee.Salary = salary;
                    selectedEmployee.DepartmentID = (int)EmployeeDepartmentComboBox.SelectedValue;

                    _employeeRepo.UpdateEmployee(selectedEmployee);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                var result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _employeeRepo.DeleteEmployee(selectedEmployee.EmployeeID);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting employee: {ex.Message}");
                    }
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
                Refresh();
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
                    Refresh();
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
                var result = MessageBox.Show("Are you sure you want to delete this department?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _departmentRepo.DeleteDepartment(selectedDepartment.DepartmentID);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting department: {ex.Message}");
                    }
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
                if (AbsenceEmployeeComboBox.SelectedValue == null || AbsenceDatePicker.SelectedDate == null || string.IsNullOrWhiteSpace(AbsenceReasonTextBox.Text))
                {
                    MessageBox.Show("Please complete all fields for the absence record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newAbsence = new Absence
                {
                    EmployeeID = (int)AbsenceEmployeeComboBox.SelectedValue,
                    Date = AbsenceDatePicker.SelectedDate.Value,
                    Reason = AbsenceReasonTextBox.Text
                };

                _absenceRepo.AddAbsence(newAbsence);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding absence: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AbsenceDataGrid.SelectedItem is Absence selectedAbsence)
            {
                try
                {
                    if (AbsenceEmployeeComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Please select an employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (AbsenceDatePicker.SelectedDate == null)
                    {
                        MessageBox.Show("Please select a date for the absence.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(AbsenceReasonTextBox.Text))
                    {
                        MessageBox.Show("Please enter a reason for the absence.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    selectedAbsence.EmployeeID = (int)AbsenceEmployeeComboBox.SelectedValue;
                    selectedAbsence.Date = AbsenceDatePicker.SelectedDate.Value;
                    selectedAbsence.Reason = AbsenceReasonTextBox.Text;

                    _absenceRepo.UpdateAbsence(selectedAbsence);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing absence: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an absence to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AbsenceDataGrid.SelectedItem is Absence selectedAbsence)
            {
                var result = MessageBox.Show("Are you sure you want to delete this absence?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _absenceRepo.DeleteAbsence(selectedAbsence.AbsenceID);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting absence: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an absence to delete.");
            }
        }

        // Selection change events, if needed
        private void AbsenceEmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void AbsenceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
