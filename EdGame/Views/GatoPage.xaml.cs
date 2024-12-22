using EdGame.ViewModels;
namespace EdGame.Views;
 
public partial class GamePage : ContentPage
{
     
    public GamePage(GatoViewModel vm)
    {
       //
        BindingContext = vm ;
        InitializeComponent(); 
    }
}
 
 



