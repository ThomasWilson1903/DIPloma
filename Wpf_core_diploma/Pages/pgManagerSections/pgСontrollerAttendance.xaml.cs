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
        List<SectionSchedule> sectionSchedules;
        Section Section;

        public pgСontrollerAttendance(Section section)
        {
            InitializeComponent();
            Section = EfModels.init().Sections.Include(p => p.TeachersNavigation).FirstOrDefault(p => p.Idsections == section.Idsections);
            tbName.Text = Section.TeachersNavigation.NameTeacher;
            tbUserSurName.Text = Section.TeachersNavigation.SurnameTeacher;

            DateTime dateValue = DateTime.Now;

            lvDayWake.SelectedIndex = 0;

            selectDayWake();
            selectDgNoMark();
            selectOnMark();
        }

        void selectDgNoMark()
        {
            attendancesMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(a => a.SectionSchedules == Section.Idsections && a.PresenceMark == null)
                .Where(p=>p.DateAttendance == DateTime.Today)
                .ToList();
            dgNoMark.ItemsSource = attendancesMark;
        }

        void selectDayWake()
        {
            sectionSchedules = EfModels.init().SectionSchedules.Include(p=>p.IdDayWeekNavigation).ToList();
            lvDayWake.ItemsSource = sectionSchedules;
        }

        void selectOnMark()
        {
            attendancesOnMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(p => p.SectionSchedules == Section.Idsections && p.PresenceMark != null)
                .Where(p => p.DateAttendance == DateTime.Today)
                .Where(p=>p.SectionSchedulesNavigation.IdDayWeek == sectionSchedules[lvDayWake.SelectedIndex].IdDayWeek)
                .ToList();

            dgMark.ItemsSource = attendancesOnMark;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            attendancesMark = attendancesMark.Where(p => p.SectionSchedulesNavigation.IdDayWeek == sectionSchedules[lvDayWake.SelectedIndex].IdDayWeek).ToList();
            dgMark.ItemsSource = attendancesMark;

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
