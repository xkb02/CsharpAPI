using MAUI.guiLMS.ViewModels;

namespace MAUI.guiLMS.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void AddEnrollmentClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel).AddClick(Shell.Current);
    }

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RefreshView();
	}

    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveClick();
    }

	private void EditEnrollmentClick(object sender, EventArgs e)
	{
        (BindingContext as InstructorViewViewModel).EditClick(Shell.Current);
    }

    private void AddCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
    }

    private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowEnrollments();
    }

    private void Toolbar_CoursesClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowCourses();
    }

    private void EditCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).EditCourseClick(Shell.Current);
    }
}
