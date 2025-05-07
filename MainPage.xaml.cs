namespace nitesh_passman;
using Microsoft.Extensions.Configuration;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        checkAndNavigate();
    }

    async Task<bool> checkAndNavigate()
    {
        try
        {
            //var savedPassword = await SecureStorage.GetAsync("password");
            var savedPassword = Preferences.Get("password", null);
            if (savedPassword != null)
            {
                await navigateToNext();
            }
            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    async Task<int> navigateToNext()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Navigation.RemovePage(this);
        await Shell.Current.GoToAsync("//allpasswords");
        return 0;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var password = passwordEntry.Text;
        try
        {
            Preferences.Set("password", password);
            //await SecureStorage.SetAsync("password", password);
            await DisplayAlert("Success", "Password saved!", "OK");
        await navigateToNext();

        }catch(Exception ex)
        {
        await DisplayAlert("Error", ex.Message, "OK");

        }


    }
}
