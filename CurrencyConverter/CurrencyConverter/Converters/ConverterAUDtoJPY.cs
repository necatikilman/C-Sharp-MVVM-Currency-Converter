using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class ConverterAUDtoJPY : IConvertible
    {
        public double Convert(Exchange exchange)
        {
            return exchange.Amount * exchange.Rate;
        }
    }
}
