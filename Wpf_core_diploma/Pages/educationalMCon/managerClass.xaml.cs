using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
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

namespace DIPloma.Pages.educationalMCon
{
    /// <summary>
    /// Interaction logic for managerClass.xaml
    /// </summary>
    public partial class managerClass : Page
    {
        List<Student> students;
        List<Student> studentsSecond;
        List<EducationalClass> educationalClasses = new();


        public managerClass()
        {
            InitializeComponent();

            educationalClasses = EfModels.init().EducationalClasses.ToList();
            cbFirst.ItemsSource = educationalClasses;
            cbSecond.ItemsSource = educationalClasses;
            cbFirst.SelectedIndex = 0;
            cbSecond.SelectedIndex = 0;
            selectFirst();
            selectSecond();
        }

        void selectFirst()
        {
            students = EfModels.init().Students.Where(p => p.Group == educationalClasses[cbFirst.SelectedIndex].Idgroup).ToList();
            dgFirst.ItemsSource = students;
            //students[1].Group = 2;
        }

        void selectSecond()
        {
            studentsSecond = EfModels.init().Students.Where(p => p.Group == educationalClasses[cbSecond.SelectedIndex].Idgroup).ToList();
            dgSecond.ItemsSource = studentsSecond;
        }

        void raising()
        {
            for (int i = 0; i < students.Count(); i++)
            {
                students[i].Group = educationalClasses[cbSecond.SelectedIndex].Idgroup;
                EfModels.init().Update(students[i]);
            }
            EfModels.init().SaveChanges();
            selectFirst();
            selectSecond();
        }

        private void scFirst(object sender, SelectionChangedEventArgs e)
        {
            selectFirst();
        }

        private void clAllRaising(object sender, RoutedEventArgs e)
        {
            raising();
        }

        private void scSecond(object sender, SelectionChangedEventArgs e)
        {
            selectSecond();
        }

        private void clFromFirstIsSecond(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;
            student.Group = educationalClasses[cbSecond.SelectedIndex].Idgroup;
            EfModels.init().Update(student);
            EfModels.init().SaveChanges();
            selectFirst();
            selectSecond();
        }

        private void clFromSecondIsFirst(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;
            student.Group = educationalClasses[cbFirst.SelectedIndex].Idgroup;
            EfModels.init().Update(student);
            EfModels.init().SaveChanges();
            selectFirst();
            selectSecond();
        }

        private void clAllEditRaising(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < studentsSecond.Count(); i++)
            {
                studentsSecond[i].Group = educationalClasses[cbFirst.SelectedIndex].Idgroup;
                EfModels.init().Update(studentsSecond[i]);
            }
            EfModels.init().SaveChanges();
            selectFirst();
            selectSecond();
        }
    }
}
