using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Test_Task_for_Prodactivity_Inside
{
    public class CurrencyConverterModel : INotifyPropertyChanged
    {
        string firstValue;
        string secondValue;
        static CurrencyList currencyList = new CurrencyList();
        static Currency first = new Currency();
        static Currency second = new Currency();
        public event PropertyChangedEventHandler PropertyChanged;
        static ChangeFirstCurrencyWindow firstChangeWindow;
        static ChangeSecondCurrencyWindow secondChangeWindow;
        static string key;

        public CurrencyConverterModel()
        {

            WebRequest myRequest = WebRequest.Create("https://www.cbr-xml-daily.ru/daily_json.js");
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream());
            string test = reader.ReadToEnd();

            currencyList = JsonConvert.DeserializeObject<CurrencyList>(test);
            currencyList.Valute.Add("RUB", new Currency()
            {
                ID = "R8050",
                Name = "Российский Рубль",
                Nominal = 1,
                NumCode = "643",
                Previous = 1,
                Value = 1
            }
           );
        }

       public ICommand ReverseCurrency
        {
            get {
                return new ButtonCommand
                  ((obj) => 
                  {
                      Currency tmp = first;
                      first = second;
                      second = tmp;
                      PropertyChanging("First");
                      PropertyChanging("Second");
                      string res = firstValue;
                      FirstValue = SecondValue;
                      

                  }
              );
            }
        }

        public ICommand OpenFirstChangeCurrencyWindow
        {
            get
            {
                return new ButtonCommand(
                    (obj) =>
                    {
                        firstChangeWindow = new ChangeFirstCurrencyWindow();
                        firstChangeWindow.ShowDialog();
                        First = key;
                    }
                    );
            }
        }

        public ICommand OpenSecondChangeCurrencyWindow
        {
            get
            {
                return new ButtonCommand(
                    (obj) =>
                    {
                        secondChangeWindow = new ChangeSecondCurrencyWindow();
                        secondChangeWindow.ShowDialog();
                        Second = key;
                    }
                    );
            }
        }

        public Dictionary<string, Currency> CurrencyList
        {
            get
            {
                return currencyList.Valute;
            }

        }

        double ConvertCurrency(Currency first, Currency second)
        {
            return ((first.Value / first.Nominal) / (second.Value / second.Nominal));
        }

        public string First
        {
            get
            {
                return first.Name;
            }
            set
            {
                if (value != null)
                {
                    first = currencyList.Valute[value.Substring(1, 3)];
                    //MessageBox.Show(first.Nominal.ToString());
                    key = value;
                    PropertyChanging("First");
                }
            }
        }

        public string Second
        {
            get { return second.Name; }
            set
            {
                if (value != null)
                {
                    second = currencyList.Valute[value.Substring(1, 3)];
                    key = value;
                    PropertyChanging("Second");
                }
            }
        }

        public ICommand CloseFirstChangeWindow
        {
            get
            {
                return new ButtonCommand(
                    (obj) =>
                    {

                        firstChangeWindow.Close();
                        PropertyChanging("First");

                    }
                    );
            }
        }

        public ICommand CloseSecondChangeWindow
        {
            get
            {
                return new ButtonCommand(
                    (obj) =>
                    {

                        secondChangeWindow.Close();
                        PropertyChanging("Second");
                    }
                    );
            }
        }

        private void PropertyChanging(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string FirstValue
        {
            get { return firstValue; }
            set
            {


                if (value == null || value.Length == 0 || secondValue == null)
                {
                    firstValue = "";
                    secondValue = "";
                    PropertyChanging("SecondValue");
                }

                if (value.Length != 0 && CheckNum(value[value.Length - 1]))
                {
                    if (CheckNum(value[value.Length - 1])
                       && CheckCntSymbol(value) == 1
                        && value.Length != 0)
                    {
                        firstValue += ",";

                    }
                    else if (value.Length != 0 && CheckCntSymbol(value) <= 1)
                    {
                        firstValue = value;
                        secondValue = (Convert.ToDouble(firstValue) * ConvertCurrency(first, second)).ToString();
                        PropertyChanging("SecondValue");

                    }

                }
                PropertyChanging("FirstValue");
            }
        }

        public string SecondValue
        {
            get { return secondValue; }
            set
            {
                if (value == null || value.Length == 0 || firstValue == null)
                {
                    secondValue = "";
                    firstValue = "";
                    PropertyChanging("FirstValue");
                }
                if (value.Length != 0 && CheckNum(value[value.Length - 1]))
                {
                    if (CheckNum(value[value.Length - 1])
                        && value[value.Length - 1] == '.'
                        && secondValue != null
                        && value.Contains(",") == false
                        && value.Length != 0)
                    {
                        secondValue += ",";

                    }
                    else if (value.Length != 0 && CheckCntSymbol(value) <= 1)
                    {
                        secondValue = value;
                        firstValue = (Convert.ToDouble(secondValue) * ConvertCurrency(second, first)).ToString();
                        PropertyChanging("FirstValue");

                    }

                }
                PropertyChanging("SecondValue");
            }
        }

        int CheckCntSymbol(string str)
        {
            int i = 0;
            foreach (var n in str)
            {
                if (n == '.' || n == ',')
                    i++;
            }
            return i;
        }

        bool CheckNum(char i)
        {
            string check = "1234567890.,";
            if (check.Contains(i))
            {
                return true;
            }
            return false;
        }


    }
}
