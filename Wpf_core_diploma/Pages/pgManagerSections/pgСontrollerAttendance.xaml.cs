using DIPloma.DataBase;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIPloma.Pages.pgManagerSections
{
    /// <summary>
    /// Interaction logic for pgСontrollerAttendance.xaml
    /// </summary>
    public partial class pgСontrollerAttendance : Page
    {

        List<Attendance> attendances;
        Section Section;

        public pgСontrollerAttendance(Section section)
        {
            InitializeComponent();
            /*Section = EfModels.init().Sections.Include(p=>p.TeachersNavigation).FirstOrDefault(p => p.Idsections == section.Idsections);
            tbName.Text = Section.TeachersNavigation.NameTeacher;
            tbUserSurName.Text = Section.TeachersNavigation.SurnameTeacher;
*/
            selectDgNoMark();
        }

        void selectDgNoMark()
        {
            attendances = EfModels.init().Attendances.Include(p=>p.StudentsNavigation).Where(a => a.SectionSchedules == 1).ToList();
            dgNoMark.ItemsSource = attendances;
        }

    }
}
