using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Window;
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
            SelectStudentListViewLeft();
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            select(selectStudent);

        }

        

        

        


        
    

        void SelectStudentListViewLeft()
        {
            IEnumerable<Student> students = EfModels.init().Students.Where(p => p.Group == 39 && p.SurnameStudent.Contains(tbSerchStudent.Text)).ToList();
            lvStudentLeft.ItemsSource = students;
        }

        void select(int SelectStudent)
        {
            List<Journal> items = EfModels.init().Journals.Where(p => p.Students == SelectStudent).ToList();
            lvMain.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvMain.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Date");
            view.GroupDescriptions.Add(groupDescription);//тестовый комент
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

        private void scStudent(object sender, SelectionChangedEventArgs e)
        {
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            select(selectStudent);
        }

        private void tChangedSerchStuden(object sender, TextChangedEventArgs e)
        {
            SelectStudentListViewLeft();
        }

        private void scMonth(object sender, SelectionChangedEventArgs e)
        {
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            select(selectStudent);
        }

        private void muAddEstimation(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
