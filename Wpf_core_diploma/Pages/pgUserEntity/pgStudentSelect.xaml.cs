using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Window.wdAddUserEntity;
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

namespace DIPloma.Pages.pgUserEntity
{
    /// <summary>
    /// Interaction logic for pgStudentSelect.xaml
    /// </summary>
    public partial class pgStudentSelect : Page
    {
        public pgStudentSelect()
        {
            InitializeComponent();
            selectStudent();
        }

        void selectStudent()
        {
            IEnumerable<Student> listStudent = EfModels.init().Students.Include(p => p.GroupNavigation).Where(p => p.SurnameStudent.Contains(tbSerch.Text)).ToList();
            dgUserMember.ItemsSource = listStudent;
        }



        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            selectStudent();

        }

        private void clChang(object sender, RoutedEventArgs e)
        {
            Student change = (sender as Button).DataContext as Student;
            new wdStudentAddEntity(change).ShowDialog();
            selectStudent();
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            Student del = (sender as Button).DataContext as Student;
            List<Journal> list = EfModels.init().Journals.Where(p => p.Students == del.Idstudents).ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    EfModels.init().Remove(list[i]);
                }

            }

            List<StudentInfoParent> delStudentInfoParent = EfModels.init().StudentInfoParents.Where(p => p.StudentParentsStudent == del.Idstudents).ToList();

            if (delStudentInfoParent.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    EfModels.init().Remove(delStudentInfoParent[i]);
                }

            }


            List<Attendance> delAttendance = EfModels.init().Attendances.Where(p => p.Students == del.Idstudents).ToList();
            if (delAttendance.Count > 0)
            {
            for (int i = 0; i < list.Count; i++)
            {
                EfModels.init().Remove(delAttendance[i]);
            }

            }

            EfModels.init().Remove(del);
            EfModels.init().SaveChanges();
            selectStudent();
        }
    }
}
