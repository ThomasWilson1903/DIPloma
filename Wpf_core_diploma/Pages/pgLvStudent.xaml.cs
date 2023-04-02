﻿using DIPloma.DataBase;
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
            IEnumerable<Journal> items = EfModels.init().Journals.Where(p => p.Students == SelectStudent).ToList();
            items = items.OrderBy(p => p.Date);
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
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            frAddChangRight.Navigate(new pgAddChangEvaluation(new Journal(), selectStudent));
        }

        private void clChang(object sender, RoutedEventArgs e)
        {
            Journal chang = (sender as Button).DataContext as Journal;
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            frAddChangRight.Navigate(new pgAddChangEvaluation(chang, selectStudent));

        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            Journal Del = (sender as Button).DataContext as Journal;
            if (MessageBox.Show("точно да?", "dqw", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                EfModels.init().Journals.Remove(Del);
                EfModels.init().SaveChanges();
            }
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            select(selectStudent);
        }

        private void clUpdate(object sender, RoutedEventArgs e)
        {
            int selectStudent = lvStudentLeft.SelectedIndex + 1;
            select(selectStudent);
        }
    }
}
