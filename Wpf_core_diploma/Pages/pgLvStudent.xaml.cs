﻿using DIPloma.DataBase;
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
        public pgLvStudent()
        {
            InitializeComponent();
            select();
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

        void select()
        {
            IEnumerable<Journal> listStudent = EfModels.init().Journals.Include(p => p.StudentsNavigation).ToList();
            
        listStudent = listStudent.Where(p=>p.ListItems == 1).ToList();
        dgMainJornal.ItemsSource = listStudent;
        }

private void tcSerch(object sender, TextChangedEventArgs e)
{

}

private void mdSerch(object sender, MouseButtonEventArgs e)
{

}

private void muSerch2(object sender, MouseButtonEventArgs e)
{

}
    }
}
