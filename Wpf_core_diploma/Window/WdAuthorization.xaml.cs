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
using Wpf_core_diploma.Pages;

namespace Wpf_core_diploma.Window
{
    /// <summary>
    /// Interaction logic for WdAuthorization.xaml
    /// </summary>
    public partial class WdAuthorization 
    {
        public WdAuthorization()
        {
            InitializeComponent();
            FrameSelect();
        }
        void FrameSelect()
        {
            FrAuth.Navigate(new PgAuthorization());
        }
    }
}
