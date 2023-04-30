using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Mvvm;


namespace TestMaui.ViewModel
{
    public partial class GameViewModel : INotifyPropertyChanged
    {
        public ICommand Minus { get; }
        public ICommand Back { get; }
        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isMyStackLayoutVisible = true;
        private bool _isPlayer1OperationsVisible = false;

        public bool IsMyStackLayoutVisible
        {
            get { return _isMyStackLayoutVisible; }
            set
            {
                _isMyStackLayoutVisible = value;
                OnPropertyChanged(nameof(IsMyStackLayoutVisible));
            }
        }

        public bool IsPlayer1OperationsVisible
        {
            get { return _isPlayer1OperationsVisible; }
            set
            {
                _isPlayer1OperationsVisible = value;
                OnPropertyChanged(nameof(IsPlayer1OperationsVisible));
            }
        }



        public GameViewModel(INavigation navigation)
        {
            Minus = new Command(OnMinusClicked);
            Back = new Command(OnBackClicked);
            _navigation = navigation;
          //  mainContentVisible = false;
          //  mainContentVisible = true;
        }

        private void OnMinusClicked()
        {
            IsMyStackLayoutVisible = false;
            IsPlayer1OperationsVisible = true;
           // mainContentVisible = false;
            //_navigation.PushAsync(new MainPage());
            //  mainContentVisible = false;
            //Navigation.PushAsync(new GamePage());
            // il codice che si vuole eseguire al momento del click
        }

        private void OnBackClicked()
        {
            IsMyStackLayoutVisible = true;
            IsPlayer1OperationsVisible = false;
            // mainContentVisible = false;
            //_navigation.PushAsync(new MainPage());
            //  mainContentVisible = false;
            //Navigation.PushAsync(new GamePage());
            // il codice che si vuole eseguire al momento del click
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

   

    
}
