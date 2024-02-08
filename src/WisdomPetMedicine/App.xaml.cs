using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine;

public partial class App : Application
{
	public App(WpmDbContext wpmDbContext, WpmOutDbContext wpmOutDbContext)
	{
		InitializeComponent();

        wpmDbContext.Database.EnsureCreated();
        wpmOutDbContext.Database.EnsureCreated();
        wpmDbContext.Dispose();
        wpmOutDbContext.Dispose();

        MainPage = new AppShell();
	}
}