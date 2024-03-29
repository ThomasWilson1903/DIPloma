﻿using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DIPloma.Window.wdAddAttendance
{
    /// <summary>
    /// Interaction logic for wdAddAttendance.xaml
    /// </summary>
    public partial class wdAddAttendance
    {
        Attendance Attendance;
        List<Student> students;
        List<Attendance> studentsChoose = new List<Attendance>(10);
        List<Student> studentsChoose2 = new List<Student>(10);
        List<EducationalClass> group;

        public wdAddAttendance(Attendance attendance)
        {
            this.Attendance = attendance;
            InitializeComponent();
            select();

            calendar1.DisplayDateStart = DateTime.Today;
            calendar1.DisplayDateEnd = (DateTime.Today).AddDays(14);
            calendar1.SelectedDate = DateTime.Today;
            
            group = EfModels.init().EducationalClasses.ToList();

            cbGroup.ItemsSource = group;

        }
        void select()
        {
            if (cbGroup.SelectedItem != null)
            {
                students = EfModels.init().Students.Where(p => p.Group == group[cbGroup.SelectedIndex].Idgroup).ToList();

            }
            else
            {
                students = EfModels.init().Students.ToList();

            }
            dgListStudents.ItemsSource = students;

        }


        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Student> students2 = students.Where(p => p.SurnameStudent.ToLower().Contains(tbSerch.Text.ToLower())).ToList();
            dgListStudents.ItemsSource = students2;
        }

        private void clСhoose(object sender, RoutedEventArgs e)
        {
            if (studentsChoose.Count != 10)
            {
                Student student = (sender as Button).DataContext as Student;
                DateTime date = Convert.ToDateTime(calendar1.SelectedDate);

                studentsChoose.Add(new Attendance
                {
                    SectionSchedules = Attendance.SectionSchedules,
                    Students = student.Idstudents,
                    DateAttendance = date,
                });

                studentsChoose2.Add(student);

                dgListSelectStudent.ItemsSource = null;

                dgListSelectStudent.ItemsSource = studentsChoose2;
                select();
            }
            else
                MessageBox.Show("", "");

        }

        private void clSaveList(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < studentsChoose.Count; i++)
            {
                EfModels.init().Add(studentsChoose[i]);
            }
            EfModels.init().SaveChanges();
            Close();
        }

        private void scGroup(object sender, SelectionChangedEventArgs e)
        {
            select();
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;

            studentsChoose2.Remove(student);

            var studentsChoose23 = studentsChoose.Where(p => p.Students == student.Idstudents).ToList();

            for (int i = 0; i < studentsChoose23.Count; i++)
            {
                studentsChoose.Remove(studentsChoose23[i]);
            }

            dgListSelectStudent.ItemsSource = null;

            dgListSelectStudent.ItemsSource = studentsChoose2;
            select();
        }
    }
}
