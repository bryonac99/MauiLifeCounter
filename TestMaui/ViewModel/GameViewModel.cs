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
        //p1
        public ICommand MinusP1Command { get; }
        public ICommand PlusP1Command => new Command(OnPlusP1Clicked);
        public ICommand ResultP1 => new Command(OnResultP1Clicked);
        public ICommand Back { get; }

        public ICommand TestCommand => new Command(OnPlusP1Clicked);

        public ICommand OnNumberClickedP1 => new Command<string>(OnNumericButtonClickedP1);

        private ICommand _halveLifePointsCommandP1;

        public ICommand HalveLifePointsCommandP1
        {
            get
            {
                if (_halveLifePointsCommandP1 == null)
                {
                    _halveLifePointsCommandP1 = new Command(() =>
                    {
                        LifePointsP1 /= 2;
                    });
                }
                return _halveLifePointsCommandP1;
            }
        }

        //p2

        public ICommand MinusP2Command { get; }
        public ICommand PlusP2Command => new Command(OnPlusP2Clicked);
        public ICommand ResultP2 => new Command(OnResultP2Clicked);
        public ICommand BackP2 { get; }

        public ICommand OnNumberClickedP2 => new Command<string>(OnNumericButtonClickedP2);

        private ICommand _halveLifePointsCommandP2;

        public ICommand HalveLifePointsCommandP2
        {
            get
            {
                if (_halveLifePointsCommandP2 == null)
                {
                    _halveLifePointsCommandP2 = new Command(() =>
                    {
                        LifePointsP2 /= 2;
                    });
                }
                return _halveLifePointsCommandP2;
            }
        }

        private INavigation _navigation;

        public ICommand Reset => new Command(OnResetClicked);



        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isMyStackLayoutVisible = true;
        private bool _isMyStackLayoutVisibleP2 = true;

        private bool _isPlayer1OperationsVisible = false;
        private bool _isPlayer2OperationsVisible = false;
        private double _lifePointsP1 { get; set; }
        private double _savePointsP1 { get; set; }

        private double _lifePointsP2 { get; set; }
        private double _savePointsP2 { get; set; }

        private bool MinusP1 { get; set; } = false;
        private bool PlusP1 { get; set; } = false;

        private bool MinusP2 { get; set; } = false;
        private bool PlusP2 { get; set; } = false;

        public bool IsMyStackLayoutVisible
        {
            get { return _isMyStackLayoutVisible; }
            set
            {
                _isMyStackLayoutVisible = value;
                OnPropertyChanged(nameof(IsMyStackLayoutVisible));
            }
        }
        public bool IsMyStackLayoutVisibleP2
        {
            get { return _isMyStackLayoutVisibleP2; }
            set
            {
                _isMyStackLayoutVisibleP2 = value;
                OnPropertyChanged(nameof(IsMyStackLayoutVisibleP2));
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
        public bool IsPlayer2OperationsVisible
        {
            get { return _isPlayer2OperationsVisible; }
            set
            {
                _isPlayer2OperationsVisible = value;
                OnPropertyChanged(nameof(IsPlayer2OperationsVisible));
            }
        }

        public double LifePointsP1
        {
            get { return _lifePointsP1; }
            set
            {
                _lifePointsP1 = value;
                OnPropertyChanged(nameof(LifePointsP1));
            }
        }

        public double SavePointsP1
        {
            get { return _savePointsP1; }
            set
            {
                _savePointsP1 = value;
                OnPropertyChanged(nameof(SavePointsP1));
            }
        }

        public double LifePointsP2
        {
            get { return _lifePointsP2; }
            set
            {
                _lifePointsP2 = value;
                OnPropertyChanged(nameof(LifePointsP2));
            }
        }

        public double SavePointsP2
        {
            get { return _savePointsP2; }
            set
            {
                _savePointsP2 = value;
                OnPropertyChanged(nameof(SavePointsP2));
            }
        }

        private void OnNumericButtonClickedP1(string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                string currentText = LifePointsP1.ToString();
                currentText += intValue.ToString();
                double newValue;
                if (double.TryParse(currentText, out newValue))
                {
                    LifePointsP1 = newValue;
                }
            }
        }



        public GameViewModel(INavigation navigation)
        {
            MinusP1Command = new Command(OnMinusP1Clicked);
            MinusP2Command = new Command(OnMinusP2Clicked);
            Back = new Command(OnBackClicked);
            BackP2 = new Command(OnBackClickedP2);
            _navigation = navigation;
            LifePointsP1 = 8000;
            LifePointsP2 = 8000;
            Console.WriteLine("dd");

      
            //  mainContentVisible = false;
            //  mainContentVisible = true;
        }

        private void OnMinusP1Clicked()
        {
            IsMyStackLayoutVisible = false;
            IsPlayer1OperationsVisible = true;
            MinusP1 = true;
            SavePointsP1 = LifePointsP1;
            LifePointsP1 = 0;

           // mainContentVisible = false;
            //_navigation.PushAsync(new MainPage());
            //  mainContentVisible = false;
            //Navigation.PushAsync(new GamePage());
            // il codice che si vuole eseguire al momento del click
        }

        private void OnPlusP1Clicked()
        {
            IsMyStackLayoutVisible = false;
            IsPlayer1OperationsVisible = true;
            PlusP1 = true;
            SavePointsP1 = LifePointsP1;
            LifePointsP1 = 0;
        }

        private void OnResultP1Clicked()
        {
            if(MinusP1 == true)
                LifePointsP1 = SavePointsP1 - LifePointsP1;
            if(PlusP1 == true)
                LifePointsP1 = SavePointsP1 + LifePointsP1;

            IsMyStackLayoutVisible = true;
            IsPlayer1OperationsVisible = false;
            MinusP1 = false;
            PlusP1 = false;
        }

        private void OnBackClicked()
        {
            if (LifePointsP1 == 0)
            {
                IsMyStackLayoutVisible = true;
                IsPlayer1OperationsVisible = false;
                LifePointsP1 = SavePointsP1;
            }
            else
            {
                int lifePointsInt = (int)LifePointsP1;
                int newLifePointsInt = lifePointsInt / 10;
                LifePointsP1 = (double)newLifePointsInt;
            }
        }

        private void OnMinusP2Clicked()
        {
            IsMyStackLayoutVisibleP2 = false;
            IsPlayer2OperationsVisible = true;
            MinusP2 = true;
            SavePointsP2 = LifePointsP2;
            LifePointsP2 = 0;
        }

        private void OnPlusP2Clicked()
        {
            IsMyStackLayoutVisibleP2 = false;
            IsPlayer2OperationsVisible = true;
            PlusP2 = true;
            SavePointsP2 = LifePointsP2;
            LifePointsP2 = 0;
        }

        private void OnNumericButtonClickedP2(string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                string currentText = LifePointsP2.ToString();
                currentText += intValue.ToString();
                double newValue;
                if (double.TryParse(currentText, out newValue))
                {
                    LifePointsP2 = newValue;
                }
            }
        }

        private void OnResultP2Clicked()
        {
            if (MinusP2 == true)
                LifePointsP2 = SavePointsP2 - LifePointsP2;
            if (PlusP2 == true)
                LifePointsP2 = SavePointsP2 + LifePointsP2;

            IsMyStackLayoutVisibleP2 = true;
            IsPlayer2OperationsVisible = false;
            MinusP2 = false;
            PlusP2 = false;
        }

        private void OnBackClickedP2()
        {
            if (LifePointsP2 == 0)
            {
                IsMyStackLayoutVisibleP2 = true;
                IsPlayer2OperationsVisible = false;
                LifePointsP2 = SavePointsP2;
            }
            else
            {
                int lifePointsInt = (int)LifePointsP2;
                int newLifePointsInt = lifePointsInt / 10;
                LifePointsP2 = (double)newLifePointsInt;
            }
        }

        private void OnResetClicked()
        {
            LifePointsP1 = 8000;
            LifePointsP2 = 8000;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

   

    
}
