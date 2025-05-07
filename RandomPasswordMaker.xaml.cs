namespace nitesh_passman;

public partial class RandomPasswordMaker : ContentPage
{
	public RandomPasswordMaker()
	{
		InitializeComponent();
	}

    static string GeneratePassword(int length, bool includeNumbers, bool includeLowercase, bool includeSymbols)
    {
        // Define character sets
        string numbers = "0123456789";
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>/?";

        // Build character set based on configuration
        string charset = "";
        if (includeNumbers)
        {
            charset += numbers;
        }
        if (includeLowercase)
        {
            charset += lowercase;
        }
        if (includeSymbols)
        {
            charset += symbols;
        }
        charset += uppercase;

        // Generate password
        Random random = new Random();
        string password = new string(Enumerable.Repeat(charset, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return password;
    }

    async void CopyButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Clipboard.SetTextAsync(passgend.Text);
        await DisplayAlert("Alert", "Password copied to clipboard", "Thanks");
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var lengthValue = ((int)slider.Value);
        var includeNumbers = switchNumbers.IsToggled;
        var includeLowercase = switchLowercase.IsToggled;
        var includeSymbols = switchSymbols.IsToggled;
        var password = GeneratePassword(lengthValue, includeNumbers, includeLowercase, includeSymbols);
        passgend.Text = password;
    }

    void slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        try
        {
            if (sender != null)
            {
        var send = ((Slider)sender);
        passlen.Text = $"Length = {(int)send.Value}";

            }
        }
        catch (Exception ex)
        {
            //DisplayAlert("Alert", ex.Message, "OK");
        }
    }
}
