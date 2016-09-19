using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App9
{
    public class MainPageViewModel : BindableBase
    {
        private decimal _count;

        public decimal Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand<object> ClickCommand { get; set; }

        public MainPageViewModel()
        {
            ClickCommand = new DelegateCommand<object>(ClickAction);
            Message = "0";  //"Hello, World!\nCount = " + Count.ToString();
            Count = 0;
        }

        private void ClickAction(object parameter)
        {
            //Random rnd = new Random();
            //Count += (int)((double)100000 * rnd.Next() / int.MaxValue);
            //Message = "Hello, Windows IoT!\nCount = " + Count.ToString();

            string entry = (string)parameter;

            switch (entry)
            {
                case "<":
                    if (Message.Length > 0)
                    {
                        Message = Message.Substring(0, Message.Length - 1);
                    }
                    if (Message.Length == 0)
                    {
                        Message = "0";
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
                    if (Message == "0")
                    {
                        if (entry != "0")
                        {
                            Message = entry;
                        }
                    }
                    else
                    {
                        Message = Message + entry;
                    }
                    break;

                case ".":
                    if(Message == "0")
                    {
                        Message = "0.";
                    }
                    else
                    {
                        if (!Message.Contains("."))
                        {
                            Message = Message + ".";
                        }
                    }
                    break;
            }

            Count = decimal.Parse(Message);
        }
    }
}