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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIPloma.Pages.educationalMCon
{
    /// <summary>
    /// Interaction logic for managerClass.xaml
    /// </summary>
    public partial class managerClass : Page
    {
        List<Student> students = new();
        List<EducationalClass> educationalClasses = new();


        public managerClass()
        {
            InitializeComponent();

            educationalClasses = EfModels.init().EducationalClasses.ToList();

            cbFirst.ItemsSource = educationalClasses;
            cbSecond.ItemsSource = educationalClasses;
        }
    }
}
