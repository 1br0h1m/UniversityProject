using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniversityProjectWPF.Consts;
using UniversityProjectWPF.ViewModels;

namespace UniversityProjectWPF.Pages.Subject
{
    /// <summary>
    /// Логика взаимодействия для ManageSubjectsPage.xaml
    /// </summary>
    public partial class ManageSubjectsPage : Page
    {
        private readonly HttpClient httpClient = new();
        public ManageSubjectsPage()
        {
            InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await httpClient.GetAsync(Urls.LocalUrl + "/api/subjects/get");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<List<SubjectViewModel>>();

                Subjects.ItemsSource = content;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = $"Ошибка: {ex.Message}";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
