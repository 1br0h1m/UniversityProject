using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace UniversityProjectWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateSubjectPage.xaml
    /// </summary>
    public partial class CreateSubjectPage : Page
    {
        private readonly HttpClient httpClient = new();
        public CreateSubjectPage()
        {
            InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            var subject = new
            {
                Name = Name.Text
            };

            string json = JsonSerializer.Serialize(subject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Urls.Url + "/api/subject/create", content);

            if (response.IsSuccessStatusCode)
            {
                ErrorMessage.Text = "Subject created successful";
            }
            else
            {
                ErrorMessage.Text = $"Error: {response.StatusCode}";
            }
        }
    }
}
