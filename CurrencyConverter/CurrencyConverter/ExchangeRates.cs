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
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.EUR, Currency.AUD), 1.50);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.EUR, Currency.JPY), 138.22);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.EUR, Currency.GBP), 0.85);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.USD, Currency.EUR), 0.93);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.USD, Currency.GBP), 0.79);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.USD, Currency.JPY), 128.74);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.USD, Currency.AUD), 1.39);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.GBP, Currency.EUR), 1.17);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.GBP, Currency.USD), 1.26);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.GBP, Currency.JPY), 162.33);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.GBP, Currency.AUD), 1.76);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.JPY, Currency.EUR), 0.0072);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.JPY, Currency.USD), 0.0078);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.JPY, Currency.GBP), 0.0062);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.JPY, Currency.AUD), 0.011);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.AUD, Currency.EUR), 0.67);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.AUD, Currency.USD), 0.72);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.AUD, Currency.GBP), 0.57);
            rates.Add(new KeyValuePair<Currency, Currency>(Currency.AUD, Currency.JPY), 92.46);
        }
    }
}
