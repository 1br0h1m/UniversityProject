﻿using System;
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
            DataContext = new SubjectsViewModel();
        }
    }
}
