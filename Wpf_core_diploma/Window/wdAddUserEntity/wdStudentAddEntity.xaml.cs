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
using System.Windows.Shapes;

namespace DIPloma.Window.wdAddUserEntity
{
    /// <summary>
    /// Interaction logic for wdStudentAddEntity.xaml
    /// </summary>
    public partial class wdStudentAddEntity
    {

        Student Student;

        public wdStudentAddEntity(Student student)
        {
            this.Student = student;
            InitializeComponent();
            DataContext = Student;
            List<EducationalClass> educationalClass = EfModels.init().EducationalClasses.ToList();
            cbGrops.ItemsSource = educationalClass;
        }

        private void clSaveChangUser(object sender, RoutedEventArgs e)
        {


            if (this.Student.Idstudents == 0)
            {
                if (loginString != "")
                {
                    Student.Login = loginString;
                    Student.Password = loginString;
                    EfModels.init().Add(Student);
                }
                else
                    MessageBox.Show("Заполните данные");


            }

            if (Student.Idstudents != 0)
            {
                if (loginString != "")
                {
                    Student.Login = loginString;
                    Student.Password = loginString;
                    EfModels.init().Update(Student);
                }
                else
                    MessageBox.Show("Заполните данные");

            }

            EfModels.init().SaveChanges();
            Close();
        }
        string nameChar;
        string Name;
        string DobleName;
        string loginString;
        void selectLogin(string name, string dobleName)
        {
            tbLogin.Text = "";
            Name = name;
            DobleName = dobleName;

            if (Name.Length != 0)
            {
                nameChar = Name.Substring(0, 1);

            }

            if (DobleName.Length != 0)
            {
                DobleName = dobleName.Substring(0, 1);

            }
            //char DobleNameChar = DobleName[0];

            loginString = tbSurName.Text + nameChar + DobleName;
            tbLogin.Text = $"Логин: {loginString}";
        }


        private void visibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            /*if ()
            {

            }*/
        }

        private void tChangedName(object sender, TextChangedEventArgs e)
        {
            selectLogin(tbName.Text, tbDobleName.Text);
        }

        private void tCangetSurName(object sender, TextChangedEventArgs e)
        {
            selectLogin(tbName.Text, tbDobleName.Text);
        }

        private void tChangetDobleName(object sender, TextChangedEventArgs e)
        {
            selectLogin(tbName.Text, tbDobleName.Text);
        }
    }
}
