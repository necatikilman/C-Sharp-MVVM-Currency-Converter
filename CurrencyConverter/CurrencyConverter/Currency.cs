using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]

    public enum Currency
    {
        [Description("United States Dollar")]
        USD,
        [Description("Euro")]
        EUR,
        [Description("Japanese Yen")]
        JPY,
        [Description("Pound sterling")]
        GBP,
        [Description("Australian Dollar")]
        AUD
    }
}