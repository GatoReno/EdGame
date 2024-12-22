namespace EdGame;
using EdGame.Views;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();
 		Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
		MainPage = new GamePage(new ViewModels.GatoViewModel());
	}
}
