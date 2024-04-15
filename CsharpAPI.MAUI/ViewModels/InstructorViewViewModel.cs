//using Android.App.People;
using csharpa1;
using csharpa1.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.guiLMS.ViewModels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public InstructorViewViewModel()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
        }
        public ObservableCollection<Person> People {
            get
            {
                var filteredList = PersonManager
                    .Current
                    .people
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Person>(filteredList);
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseManager.Current.courses);
            }
        }

        public string Title { get => "Instructor / Administrator Menu"; }

        public bool IsEnrollmentsVisible
        {
            get; set;
        }

        public bool IsCoursesVisible
        {
            get; set;
        }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(People));
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void AddClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail?personId=0");
        }
        public void EditClick(Shell s)
        {
            var idParam = SelectedPerson?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }
        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseDetail?courseId=0");
        }

        //public void EditClick(Shell s)
        //{
        //    var idParam = SelectedPerson?.Id ?? 0;
        //    s.GoToAsync($"//PersonDetail?personId={idParam}");
        //}
        public void RemoveClick()
        {
            if(SelectedPerson == null) { return; }

            PersonManager.Current.RemovePerson(SelectedPerson);
            RefreshView();
        }

        public void EditCourseClick(Shell s)
        {
            var CodeParam = SelectedCourse?.Id ?? 0;
            s.GoToAsync($"//CourseDetail?courseId={CodeParam}");
        }
    }
}
