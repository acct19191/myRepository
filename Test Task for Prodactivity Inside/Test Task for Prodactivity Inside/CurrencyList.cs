using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_for_Prodactivity_Inside
{
    public class CurrencyList
    {

        public string Date { get; set; }
        public string PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public string Timestamp { get; set; }

        public Dictionary<string, Currency> Valute { get; set; } = new Dictionary<string, Currency>();
    }
}
