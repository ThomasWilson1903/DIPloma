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

        List<Attendance> attendancesMark;
        List<Attendance> attendancesOnMark;
        List<DayWeek> dayWeeks;
        Section Section;

        public pgСontrollerAttendance(Section section)
        {
            InitializeComponent();
            /*Section = EfModels.init().Sections.Include(p=>p.TeachersNavigation).FirstOrDefault(p => p.Idsections == section.Idsections);
            tbName.Text = Section.TeachersNavigation.NameTeacher;
            tbUserSurName.Text = Section.TeachersNavigation.SurnameTeacher;
*/
            selectDgNoMark();
            selectDayWake();
            selectOnMark();
        }

        void selectDgNoMark()
        {
            attendancesMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation).Where(a => a.SectionSchedules == 1 && a.PresenceMark == null).ToList();
            dgNoMark.ItemsSource = attendancesMark;
        }

        void selectDayWake()
        {
            dayWeeks = EfModels.init().DayWeeks.ToList();
            lvDayWake.ItemsSource = dayWeeks;
        }

        void selectOnMark()
        {
            attendancesOnMark = EfModels.init().Attendances.Where(p => p.PresenceMark != null).ToList();
            dgMark.ItemsSource = attendancesOnMark;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void clMarkAdd(object sender, RoutedEventArgs e)
        {
            Attendance markOn = (sender as Button).DataContext as Attendance;

            markOn.PresenceMark = 1;

            attendancesOnMark.Add(markOn);

            for (int i = 0; i < attendancesOnMark.Count; i++)
            {
                EfModels.init().Update(attendancesOnMark[i]);
            }

            EfModels.init().SaveChanges();
            selectOnMark();
            selectDgNoMark();
        }
    }
}
