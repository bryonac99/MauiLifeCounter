using AndroidX.Lifecycle;
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
    }

}
