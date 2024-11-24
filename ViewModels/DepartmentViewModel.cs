using persoonBeheerSysteem.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace persoonBeheerSysteem.ViewModels
{
    public class DepartmentViewModel : INotifyPropertyChanged //zorgen dat UI informed is
    {
        private readonly DepartmentRepository _departmentRepository;
        private ObservableCollection<Department>? _departments; //automatische updates -> UI

        public DepartmentViewModel(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            LoadDepartments();
        }

        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnPropertyChanged();
            }
        }

        private void LoadDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            Departments = new ObservableCollection<Department>(departments);
        }

        // Command to add a new Department
        public void AddDepartment(Department newDepartment)
        {
            _departmentRepository.AddDepartment(newDepartment);
            LoadDepartments();
        }

        // Command to edit a Department
        public void EditDepartment(Department updatedDepartment)
        {
            _departmentRepository.UpdateDepartment(updatedDepartment);
            LoadDepartments();
        }

        // Command to delete a Department
        public void DeleteDepartment(int departmentID)
        {
            _departmentRepository.DeleteDepartment(departmentID);
            LoadDepartments();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
