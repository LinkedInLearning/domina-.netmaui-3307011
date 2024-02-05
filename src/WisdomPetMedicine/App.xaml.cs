using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine;

public partial class App : Application
{
	public App(WpmOutDbContext wpmOutDbContext)
	{
		InitializeComponent();

        wpmOutDbContext.Database.EnsureCreated();

        MainPage = new AppShell();
	}
}
