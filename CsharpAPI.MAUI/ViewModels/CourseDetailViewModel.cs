using CsharpAPI.Library.Models;
using System.ComponentModel;    
using System.Runtime.CompilerServices;

namespace MAUI.guiLMS.ViewModels
{
    internal class CourseDetailViewModel
    {
        public CourseDetailViewModel()
        {
            course = new Course();
        }

        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }
        public string Prefix
        {
            get => course?.Prefix ?? string.Empty;
            set { if (course != null) course.Prefix = value; }
        }
        public int Id { get; private set; }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;

        public void AddCourse()
        {

            if (Id <= 0)
            {
                CourseManager.Current.AddCourse(new Course { Name = Name, Prefix = Prefix, Description = Description, Id = Id });
                Shell.Current.GoToAsync("//Instructor");
            }
            else
            {
                var refToUpdate = CourseManager.Current.GetById(Id) as Course;
                refToUpdate.Name = Name;
                refToUpdate.Prefix = Prefix;
                refToUpdate.Description = Description;
                Shell.Current.GoToAsync("//Instructor");
            }

        }

        private void LoadById(int id)
        {
            if (id == 0) { return; }
            var course = CourseManager.Current.GetById(id) as Course;
            if (course != null)
            {
                Name = course.Name;
                Prefix = course.Prefix;
                Id = course.Id;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Prefix));
            NotifyPropertyChanged(nameof(Description));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }
    }
}