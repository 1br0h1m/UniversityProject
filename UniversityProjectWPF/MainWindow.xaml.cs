using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using UniversityProjectWPF.Pages;
using UniversityProjectWPF.Pages.Subject;

namespace UniversityProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoToCreateSubjectPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateSubjectPage());
        }
        private void GoToManageSubjectsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageSubjectsPage());
        }
    }
}