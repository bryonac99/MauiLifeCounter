using TestMaui.ViewModel;

namespace TestMaui.Pages;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();

		var vm = new GameViewModel(Navigation);
        BindingContext = vm;

        myStackLayout.SetBinding(IsVisibleProperty, nameof(vm.IsMyStackLayoutVisible));
        myStackLayoutP2.SetBinding(IsVisibleProperty, nameof(vm.IsMyStackLayoutVisibleP2));
        NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);

    }

}
