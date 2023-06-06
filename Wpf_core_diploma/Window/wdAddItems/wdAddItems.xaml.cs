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
        public wdAddItems(Subiectum subiectum)
        {
            this.Subiectum = subiectum;
            InitializeComponent();
            DataContext = Subiectum;
        }

        private void clAddItems(object sender, RoutedEventArgs e)
        {
            Subiectum.NameSubiectum = tbNameItems.Text;
            if (this.Subiectum.NameSubiectum != null)
            {
                EfModels.init().Add(Subiectum);
                EfModels.init().SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Введите название предмета", "Ошибка!");
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
    }
}
