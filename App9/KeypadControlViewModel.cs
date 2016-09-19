using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App9
{
    public class KeypadControlViewModel : BindableBase
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        private string _valueText;

        public string ValueText
        {
            get { return _valueText; }
            set { SetProperty(ref _valueText, value); }
        }

        public DelegateCommand<object> ClickCommand { get; set; }

        public KeypadControlViewModel()
        {
            ClickCommand = new DelegateCommand<object>(ClickAction);
            ValueText = "0";
            Value = 0;
        }

        private void ClickAction(object parameter)
        {
            string entry = (string)parameter;

            switch (entry)
            {
                case "<":
                    if (ValueText.Length > 0)
                    {
                        ValueText = ValueText.Substring(0, ValueText.Length - 1);
                    }
                    if (ValueText.Length == 0)
                    {
                        ValueText = "0";
                    }
                    break;

                case null:
                    break;

                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (ValueText == "0")
                    {
                        if (entry != "0")
                        {
                            ValueText = entry;
                        }
                    }
                    else
                    {
                        ValueText = ValueText + entry;
                    }
                    break;

                case ".":
                    if (ValueText == "0")
                    {
                        ValueText = "0.";
                    }
                    else
                    {
                        if (!ValueText.Contains("."))
                        {
                            ValueText = ValueText + ".";
                        }
                    }
                    break;
            }

            Value = decimal.Parse(ValueText);
        }
    }
}
