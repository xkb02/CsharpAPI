using csharpa1;
using MAUI.guiLMS.ViewModels;

namespace MAUI.guiLMS.Views;
[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDetailView : ContentPage
{
    public CourseDetailView()
    {
        InitializeComponent();
        BindingContext = new CourseDetailViewModel();
    }


    public int CourseId
    {
        set; get;
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }


    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddCourse(/*Shell.Current*/);
    }
    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDetailViewModel(CourseId);
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}