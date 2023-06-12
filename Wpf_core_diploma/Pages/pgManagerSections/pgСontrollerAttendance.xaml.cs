using DIPloma.DataBase;
using DIPloma.DataBase.Entity;
using DIPloma.Window.wdAddAttendance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
            //DataContext = Section;

            selectDayWake();
            lvDayWake.SelectedIndex = 0;
            selectDgNoMark(DateTime.Today);
            selectOnMark(DateTime.Today);


        }

        void selectDgNoMark(DateTime dateTimeNow)
        {
            attendancesMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(a => a.SectionSchedules == Section.Idsections && a.PresenceMark == null)
                .Where(p => p.DateAttendance == dateTimeNow)
                .ToList();
            dgNoMark.ItemsSource = attendancesMark;
        }

        void selectDayWake()
        {
            sectionSchedules = EfModels.init().SectionSchedules.Include(p => p.IdDayWeekNavigation)
                .Where(p => p.Sections == Section.Idsections)
                .ToList();
            lvDayWake.ItemsSource = sectionSchedules;
        }

        void selectOnMark(DateTime dateTimeNow)
        {
            attendancesOnMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(a => a.SectionSchedules == Section.Idsections && a.PresenceMark != null)
                .Where(p => p.DateAttendance == dateTimeNow)
                .ToList();
            dgMark.ItemsSource = attendancesOnMark;
        }

        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            clOptions.Visibility = Visibility.Collapsed;
            clOptionsMark.Visibility = Visibility.Collapsed;

            attendancesMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(a => a.SectionSchedules == Section.Idsections)
                .Where(p => p.DateAttendance >= DateTime.Today)
                .Where(p => (int)p.DateAttendance.DayOfWeek == sectionSchedules[lvDayWake.SelectedIndex].IdDayWeek)
                .ToList();
            dgNoMark.ItemsSource = attendancesMark;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgNoMark.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("DateAttendance");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void clMarkAdd(object sender, RoutedEventArgs e)
        {
            Attendance markOn = (sender as Button).DataContext as Attendance;
            
            markOn.PresenceMark = 1;
            DateTime dayToday = DateTime.Today;
            attendancesOnMark.Add(markOn);

            EfModels.init().Add(new Attendance
            {
                DateAttendance = dayToday.AddDays(7),
                SectionSchedules = Section.Idsections,
                Students = markOn.Students,
            });

            for (int i = 0; i < attendancesOnMark.Count; i++)
            {
                EfModels.init().Update(attendancesOnMark[i]);
            }

            EfModels.init().SaveChanges();
            selectDgNoMark(DateTime.Today);
            selectOnMark(DateTime.Today);
        }

        private void clRestartSelect(object sender, RoutedEventArgs e)
        {
            selectDgNoMark(DateTime.Today);
            selectOnMark(DateTime.Today);
            clOptions.Visibility = Visibility.Visible;
            clOptionsMark.Visibility = Visibility.Visible;
        }

        private void clAddAttNew(object sender, RoutedEventArgs e)
        {
            new wdAddAttendance(new Attendance { SectionSchedules = Section.Idsections }).ShowDialog();
            ///
            clOptions.Visibility = Visibility.Collapsed;
            clOptionsMark.Visibility = Visibility.Collapsed;

            attendancesMark = EfModels.init().Attendances.Include(p => p.StudentsNavigation)
                .Where(a => a.SectionSchedules == Section.Idsections)
                .Where(p => p.DateAttendance >= DateTime.Today)
                .Where(p => (int)p.DateAttendance.DayOfWeek == sectionSchedules[lvDayWake.SelectedIndex].IdDayWeek)
                .ToList();
            dgNoMark.ItemsSource = attendancesMark;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgNoMark.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("DateAttendance");
            view.GroupDescriptions.Add(groupDescription);

        }
    }
}
