using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniversityProjectWPF.Consts;

namespace UniversityProjectWPF.ViewModels
{
    public class SubjectsViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient httpClient = new();
        private SubjectViewModel selectedSubject;

        public ObservableCollection<SubjectViewModel> Subjects { get; set; } = [];
        public SubjectViewModel SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                selectedSubject.InitializeForEdit();
                OnPropertyChanged("SelectedSubject");
            }
        }

        public SubjectsViewModel()
        {
            LoadSubjectsAsync().ConfigureAwait(false);
        }

        public async Task LoadSubjectsAsync()
        {
            var response = await httpClient.GetAsync(Urls.LocalUrl + "/api/subject/get");
            if (response.IsSuccessStatusCode)
            {
                var subjects = await response.Content.ReadFromJsonAsync<List<SubjectViewModel>>();

                Subjects.Clear();
                foreach (var subject in subjects)
                {
                    Subjects.Add(new SubjectViewModel()
                    {
                        Id = subject.Id,
                        Name = subject.Name
                    });
                }

                SelectedSubject = Subjects.FirstOrDefault();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
