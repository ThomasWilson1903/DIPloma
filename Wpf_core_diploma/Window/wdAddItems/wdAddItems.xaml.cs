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

namespace DIPloma.Window.wdAddItems
{
    /// <summary>
    /// Interaction logic for wdAddItems.xaml
    /// </summary>
    public partial class wdAddItems
    {

        Subiectum Subiectum;
        public wdAddItems(Subiectum subiectum, int visible)
        {
            this.Subiectum = subiectum;
            InitializeComponent();
            DataContext = Subiectum;

            switch (visible)
            {
                case 0:
                    btDel.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    btDel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void clAddItems(object sender, RoutedEventArgs e)
        {
            Subiectum.NameSubiectum = tbNameItems.Text;
            if (Subiectum.Idobjects == null)
            {

                if (this.Subiectum.NameSubiectum != null)
                {
                    EfModels.init().Add(Subiectum);
                }
                else
                    MessageBox.Show("Введите название предмета", "Ошибка!");
            }

            if (Subiectum.Idobjects != null)
            {
                EfModels.init().Update(Subiectum);
            }
            EfModels.init().SaveChanges();
            Close();

        }
        void downloadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All file|*.*" };

            if (openFile.ShowDialog() == true)
            {
                Subiectum.ImageIcon = File.ReadAllBytes(openFile.FileName);

                var uri = new Uri(openFile.FileName);
                var bitmap = new BitmapImage(uri);
                imageIcon.Source = bitmap;


            }
        }

        private void clAddImage(object sender, RoutedEventArgs e)
        {
            downloadImage();
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                List<Journal> listDel = EfModels.init().Journals.Where(p => p.ListItemsNavigation.Subiectum == Subiectum.Idobjects).ToList();
                if (listDel.Count > 0)
                {
                    for (int i = 0; i < listDel.Count; i++)
                    {
                        EfModels.init().Remove(listDel[i]);
                    }

                }
                List<DataBase.Entity.ListItem> delListItems = EfModels.init().ListItems.Where(p => p.Subiectum == Subiectum.Idobjects).ToList();
                if (delListItems.Count > 0)
                {
                    for (int i = 0; i < delListItems.Count; i++)
                    {
                        EfModels.init().Remove(delListItems[i]);
                    }

                }
                EfModels.init().Remove(Subiectum);
                EfModels.init().SaveChanges();
                Close();
            }
        }
    }
}
