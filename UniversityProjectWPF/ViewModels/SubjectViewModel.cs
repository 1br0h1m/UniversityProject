using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversityProjectWPF.Consts;

namespace UniversityProjectWPF.ViewModels
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient httpClient = new();
        private string name;
        private string tempName;
        public int Id { get; set; }
        public required string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string TempName
        {
            get => tempName;
            set
            {
                tempName = value;
                OnPropertyChanged("TempName");
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public SubjectViewModel()
        {
            SaveCommand = new RelayCommand(SaveChanges);
            DeleteCommand = new RelayCommand(Delete);
        }
        private async void Delete()
        {
            var response = await httpClient.DeleteAsync(Urls.Url + "/api/subject/delete/" + Id);
        }
        private async void SaveChanges()
        {
            Name = TempName;
            var subject = new { Id, Name = TempName };
            var response = await httpClient.PutAsJsonAsync(Urls.Url + "/api/subject/update", subject);

            if (response.IsSuccessStatusCode)
            {
                Name = TempName;
            }
        }
        public void InitializeForEdit()
        {
            TempName = Name;
        }
        public List<TestViewModel> Tests { get; set; } = [];

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
