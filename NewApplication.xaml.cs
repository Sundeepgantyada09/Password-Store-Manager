using nitesh_passman.ViewModel;

namespace nitesh_passman;

public partial class NewApplication : ContentPage
{
	public NewApplication()
	{
		InitializeComponent();
	}

    async void SaveButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var passwordviewModel = App.passwordViewModel;
            string appName = appNameEntry.Text;
            string appPassword = appPasswordEntry.Text;

            passwordviewModel.saveToHistory(appName, appPassword);
            await DisplayAlert("Alert", "Entry added to password manager", "OK");
        }
        catch(Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");

        }
        
    }
}
