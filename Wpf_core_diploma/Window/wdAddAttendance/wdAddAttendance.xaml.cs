using DIPloma.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        public wdAddAttendance(Attendance attendance)
        {
            this.Attendance = attendance;
            InitializeComponent();

        }
    }
}
