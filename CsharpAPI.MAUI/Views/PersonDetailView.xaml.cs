using MAUI.guiLMS.ViewModels;
//using csharpa1;


//using static csharpa1.Person;


namespace MAUI.guiLMS.Views;

[QueryProperty(nameof(PersonId), "personId")]
public partial class PersonDetailView : ContentPage
{
    public PersonDetailView()
    {
        InitializeComponent();

        //BindingContext = new PersonDetailViewModel(PersonId);
    }

    public int PersonId
    {
        set; get;
    }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as PersonDetailViewModel).AddPerson();
      
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonDetailViewModel(PersonId);
    }



    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}
