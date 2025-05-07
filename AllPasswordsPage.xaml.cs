using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using nitesh_passman.ViewModel;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace nitesh_passman;

public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}


public partial class AllPasswordsPage : ContentPage
{
	public AllPasswordsPage()
	{
		InitializeComponent();
        BindingContext = App.passwordViewModel;

    }

    void Expander_ExpandedChanged(System.Object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
    {
       
    }


    async void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        var btn = (Button)sender;
        var app = (PasswordViewModel)BindingContext;
        app.removeSingle(int.Parse(btn.ClassId));
        app.initData();
        await DisplayAlert("Alert", "Item Deleted", "Okay");
    }


    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var btn = (Button)sender;
        var app = (PasswordViewModel)BindingContext;
        string result = await DisplayPromptAsync("UNLOCK PASSWORD", "Enter the unlock password !");
        var savedPassword = Preferences.Get("password", null);
        if(savedPassword == null)
        {
            await DisplayAlert("Alert", "No Global Password saved", "Okay");
            await Shell.Current.GoToAsync("//MainPage");
            return;
        }
        if (result == savedPassword)
        {
            var allAppLists = app.historyOut;
            var item = allAppLists.First((e) => e.id.ToString() == btn.ClassId);
            await DisplayAlert($"{item.Title} Password", $"Password : {item.Password}", "Okay");
        }
        else
        {
            await DisplayAlert("Alert", "BAD PASSWORD", "Okay");
        }


    }

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
       App.passwordViewModel.initData();
    }
}
