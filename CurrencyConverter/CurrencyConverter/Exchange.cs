using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Exchange : ExchangeRates, INotifyPropertyChanged, IConvertible
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string arrow = "→";
        private Currency fromCurrency;
        private Currency toCurrency;
        private double amount;
        private double exchangedAmount;
        private double rate;
        public string Arrow { get => arrow; }
        public Currency FromCurrency 
        { 
            get => fromCurrency;
            set 
            { 
                fromCurrency = value;
                OnPropertyChanged();
            }
        }
        public Currency ToCurrency
        {
            get => toCurrency;
            set
            {
                toCurrency = value;
                OnPropertyChanged();
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
            set
            {
                exchangedAmount = value;
                OnPropertyChanged();
            }
        }
        public double Rate
        {
            get => rate;
            private set
            {
                rate = value;
                OnPropertyChanged();
            }
        }

        public Exchange(Currency fromCurrency, Currency toCurrency, double amount)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Amount = amount;
            Rate = GetRate(new KeyValuePair<Currency, Currency>(FromCurrency, toCurrency));
            ExchangedAmount = Math.Round(Convert(), 2);     
        }
        public double Convert()
        {
            return amount * rate;
        }
        public double Convert(Exchange exchange)
        {
            return Amount * Rate;
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
