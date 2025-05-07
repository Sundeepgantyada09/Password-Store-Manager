using nitesh_passman.ViewModel;

namespace nitesh_passman;

public partial class App : Application
{
	public static PasswordViewModel passwordViewModel;
    public App(DatabaseService databaseService)
	{
		passwordViewModel = new PasswordViewModel(databaseService);
		InitializeComponent();
        MainPage = new AppShell();
	}
}

