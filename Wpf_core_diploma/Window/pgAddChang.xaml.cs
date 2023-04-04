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
using System.Windows.Shapes;

namespace DIPloma.Window
{
    /// <summary>
    /// Interaction logic for pgAddChang.xaml
    /// </summary>
    public partial class pgAddChang
    {
        Journal Journal;
        int StudentIndex;
        DateTime? date;
        public pgAddChang(Journal journal, int StudentIndex, int ListItems)
        {
            this.Journal = journal;
            this.StudentIndex = StudentIndex;
            DataContext = Journal;
            /*if(Journal.Date != null)
            {
                calendar1.SelectedDates = Journal.Date;
            }*/
            Journal.Students = StudentIndex;
            Journal.ListItems = ListItems;
            InitializeComponent();
        }



        private void clSaveAddChang(object sender, RoutedEventArgs e)
        {
            if (Journal.Idjournal == 0)
            {
                if (date == null)
                {
                    //var today = DateOnly.FromDateTime(DateTime.Today);
                    Journal.Date = Journal.Date;
                }
                EfModels.init().Add(Journal);
            }
            EfModels.init().SaveChanges();
            Close();

        }

        private void sdChangedAdd(object sender, SelectionChangedEventArgs e)
        {
            date = calendar1.SelectedDate;
        }

        

        private void IsVisibleChanged1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Journal.Idjournal != null)
            {
                EfModels.init().Entry(Journal).Reload();
            }
            EfModels.init().SaveChanges();
        }
    }
}
