namespace EdGame;
using EdGame.Views;
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	  private async void OnPlayButtonClicked(object sender, EventArgs e)
        {
            // Navegar usando la ruta registrada
            await Shell.Current.GoToAsync(nameof(GamePage));
        }
}

