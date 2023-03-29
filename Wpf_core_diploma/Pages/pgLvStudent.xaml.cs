using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static DIPloma.Pages.lvAppMain;

namespace DIPloma.Pages
{
    /// <summary>
    /// Логика взаимодействия для pgLvStudent.xaml
    /// </summary>
    public partial class pgLvStudent : Page
    {
        private object dgMainJornal;

        public pgLvStudent()
        {
            InitializeComponent();
            select();
            SelectStudentListViewLeft();
        }

        class listAccell
        {
            public string nameStudent { get; set; }

            public string? access { get; set; }

            public listAccell(string name)
            {
                nameStudent = name;
            }
        }

        void SelectStudentListViewLeft()
        {
            IEnumerable<Student> students = EfModels.init().Students.Where(p => p.Group == 39 ).ToList();
            lvStudentLeft.ItemsSource = students;
        }

        void select()
        {
            IEnumerable<Journal> listStudent = EfModels.init().Journals.Where(p=>p.Students == 1).Include(p => p.StudentsNavigation).ToList();

            lvWeek.ItemsSource = listStudent; 
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            
        }

        private void muSerch2(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tboxSerch);

        }

        private void muSerch(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(tboxSerch);
        }
    }
}
