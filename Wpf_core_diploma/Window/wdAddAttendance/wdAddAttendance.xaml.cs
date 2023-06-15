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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DIPloma.Window.wdAddAttendance
{
    /// <summary>
    /// Interaction logic for wdAddAttendance.xaml
    /// </summary>
    public partial class wdAddAttendance
    {
        Attendance Attendance;
        List<Student> students;
        List<Student> studentsChoose = new List<Student>(10);

        public wdAddAttendance(Attendance attendance)
        {
            this.Attendance = attendance;
            InitializeComponent();
            select();
        }
        void select()
        {
            students = EfModels.init().Students.ToList();
            dgListStudents.ItemsSource = students;

        }


        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Student> students2 = students.Where(p => p.SurnameStudent.ToLower().Contains(tbSerch.Text.ToLower())).ToList();
            dgListStudents.ItemsSource = students2;
        }

        private void clСhoose(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;

            studentsChoose.Add(student);

            dgListSelectStudent.ItemsSource = null;

            dgListSelectStudent.ItemsSource = studentsChoose;
            select();
        
        }
    }
}
