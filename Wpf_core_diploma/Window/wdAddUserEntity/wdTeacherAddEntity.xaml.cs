using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace DIPloma.Window.wdAddUserEntity
{
    /// <summary>
    /// Interaction logic for wdTeacherAddEntity.xaml
    /// </summary>
    public partial class wdTeacherAddEntity 
    {
        Teacher Teacher;
        public wdTeacherAddEntity(Teacher teacher)
        {
            this.Teacher = teacher;
            DataContext = Teacher;
            InitializeComponent();
        }

        private void clOpenCalendarHB(object sender, RoutedEventArgs e)
        {
            DateTime date = Teacher.DateBirth;
            if(date == new DateTime(0001, 01 ,01))
            {
                date = DateTime.Today;
            }
            wdCalendar calendar = new wdCalendar(date);//attention dibil
            calendar.ShowDialog();//attention dibil, da blute, aaaaa!
            Teacher.DateBirth = calendar.TeacherHB;
            //MessageBox.Show($"{calendar.TeacherHB}");
        }

        private void clDomlodeImage(object sender, RoutedEventArgs e)
        {
            downloadImage();
        }
        void downloadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All file|*.*" };

            if (openFile.ShowDialog() == true)
            {
                Teacher.PhotoTeachers = File.ReadAllBytes(openFile.FileName);

                var uri = new Uri(openFile.FileName);
                var bitmap = new BitmapImage(uri);
                ImageTeacher.ImageSource = bitmap;

               
            }
        }

        private void clOpenCalendarWork(object sender, RoutedEventArgs e)
        {
            DateTime date = Teacher.DateWork;
            if (date == new DateTime(0001, 01, 01))
            {
                date = DateTime.Today;
            }
            wdCalendar calendar = new wdCalendar(date);//attention dibil
            calendar.ShowDialog();//attention dibil, da blute, aaaaa!
            Teacher.DateWork = calendar.TeacherHB;
            //MessageBox.Show($"{calendar.TeacherHB}");
        }

        private void clSaveDataBase(object sender, RoutedEventArgs e)
        {
            if (Teacher == null)
            {
                EfModels.init().Add(Teacher);

            }
            EfModels.init().SaveChanges();
            Close();
        }

        private void isVisibleChang1(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (Teacher.IdTeachers != null)
            {
                EfModels.init().Entry(Teacher).Reload();
            }
            EfModels.init().SaveChanges();

        }
    }
}
