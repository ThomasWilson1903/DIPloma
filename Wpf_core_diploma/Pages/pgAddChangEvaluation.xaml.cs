using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using MaterialDesignThemes.Wpf;
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

namespace DIPloma.Pages
{
    /// <summary>
    /// Interaction logic for pgAddChangEvaluation.xaml
    /// </summary>
    public partial class pgAddChangEvaluation : Page
    {
        Journal Journal;
        int lvStudentLeft;
        DateTime today = DateTime.Today;
        DateTime? selectedDate;

        public pgAddChangEvaluation(Journal journal, int lvStudentLeft)
        {
            this.lvStudentLeft = lvStudentLeft;
            this.Journal = journal;
            InitializeComponent();
            DataContext = Journal;
            calendar1.SelectedDate = today;
        }

        private void clSaveAddChang(object sender, RoutedEventArgs e)
        {

            //Journal.Date = DateOnly.FromDateTime(today);

            //DateTime selectedDate = calendar1.SelectedDate;
            Journal.Date = DateOnly.FromDateTime(Convert.ToDateTime(selectedDate));
            Journal.ListItems = 1;
            Journal.Students = lvStudentLeft;
            if (lvStudentLeft != 0)
            {
                if (Journal.Idjournal == 0)
                {
                    EfModels.init().Add(Journal);
                    MessageBox.Show($"был успешно добавлен");
                }
            }
            else
                MessageBox.Show("Вы не выбрали учащего");


            EfModels.init().SaveChanges();
            new pgLvStudent();
        }

        private void visibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = calendar1.SelectedDate;
        }
    }
}
