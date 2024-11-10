using persoonBeheerSysteem.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace persoonBeheerSysteem.ViewModels
{
    public class AbsenceViewModel : INotifyPropertyChanged
    {
        private readonly AbsenceRepository _absenceRepository;
        private ObservableCollection<Absence>? _absences;

        public AbsenceViewModel(AbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
            LoadAbsences();
        }

        public ObservableCollection<Absence> Absences
        {
            get => _absences;
            set
            {
                _absences = value;
                OnPropertyChanged();
            }
        }

        private void LoadAbsences()
        {
            var absences = _absenceRepository.GetAllAbsences();
            Absences = new ObservableCollection<Absence>(absences);
        }

        // Command to add a new Absence
        public void AddAbsence(Absence newAbsence)
        {
            _absenceRepository.AddAbsence(newAbsence);
            LoadAbsences();
        }

        // Command to edit an Absence
        public void EditAbsence(Absence updatedAbsence)
        {
            _absenceRepository.UpdateAbsence(updatedAbsence);
            LoadAbsences();
        }

        // Command to delete an Absence
        public void DeleteAbsence(int absenceID)
        {
            _absenceRepository.DeleteAbsence(absenceID);
            LoadAbsences();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
