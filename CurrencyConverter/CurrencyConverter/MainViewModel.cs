using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CurrencyConverter
{
    internal class MainViewModel
    {
        public Array Currencies => Enum.GetValues(typeof(Currency));

    }
}
