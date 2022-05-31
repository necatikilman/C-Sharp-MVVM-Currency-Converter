using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CurrencyConverter
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Exchange> exchanges = new ObservableCollection<Exchange>();
        public ObservableCollection<Exchange> Exchanges
        {
            get => exchanges;
            set => exchanges = value;
        }

        IConvertible converter = null;

        private Currency fromCurrency;
        private Currency toCurrency;
        private double amount;
        private double exchangedAmount;
        public Currency FromCurrency
        {
            get => fromCurrency;
            set
            {
                fromCurrency = value;
                OnPropertyChanged();
                SetConverter();
            }
        }

        public Currency ToCurrency
        {
            get => toCurrency;
            set
            {
                toCurrency = value;
                OnPropertyChanged();
                SetConverter();
            }
        }
        public double Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public double ExchangedAmount
        {
            get => exchangedAmount;
            private set
            {
                exchangedAmount = value;
                OnPropertyChanged();
            }
        }

        public Array Currencies => Enum.GetValues(typeof(Currency));

        public ICommand ConvertCommand { get; set; }

        public MainViewModel()
        {
            FromCurrency = Currency.EUR;
            ToCurrency = Currency.USD;
            ConvertCommand = new ActionCommand(ConvertCommandAction);
        }

        private void ConvertCommandAction()
        {
            if (converter != null && Amount != double.NaN && FromCurrency != ToCurrency )
            {
                Exchange exchange = new Exchange(FromCurrency, ToCurrency, Amount);
                ExchangedAmount = Math.Round(converter.Convert(exchange), 2);
                Exchanges.Add(exchange);
            }
            // Or simply (without converters)
            // if (Amount != double.NaN)
            // {
            //      Exchange exchange = new Exchange(FromCurrency, ToCurrency, Amount);
            //      ExchangedAmount = exchange.Convert(exchange);   // The parameter would be removed in Exchange and IConvertible.
            // }
        }

        private void SetConverter()
        {
            if (FromCurrency == Currency.EUR && ToCurrency == Currency.USD)
                converter = new ConverterEURtoUSD();
            else if (FromCurrency == Currency.USD && ToCurrency == Currency.EUR)
                converter = new ConverterUSDtoEUR();
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
