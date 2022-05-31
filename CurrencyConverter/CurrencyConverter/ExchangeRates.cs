using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class ExchangeRates
    {
        private Dictionary<KeyValuePair<Currency, Currency>, double> rates = new Dictionary<KeyValuePair<Currency, Currency>, double>();

        public ExchangeRates()
        {
            UpdateExchangeRates();
        }

        public double GetRate(KeyValuePair<Currency, Currency> FromTo)
        {
            if (rates.ContainsKey(FromTo))
                return rates[FromTo];
            else
                return 0.0;
        }

        private void UpdateExchangeRates()
        {
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.EUR, Currency.USD), 1.07);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.USD, Currency.EUR), 0.93);
        }
    }
}
