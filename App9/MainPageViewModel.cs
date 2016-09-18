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
        private int _count;

        public int Count
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

        public DelegateCommand ClickCommand { get; set; }

        public MainPageViewModel()
        {
            ClickCommand = new DelegateCommand(ClickAction);
            Message = "Hello, World!";
            Count = 0;
        }

        private void ClickAction()
        {
            Random rnd = new Random();
            Count += 100000 * rnd.Next() / int.MaxValue;
            Message = "Hello, Windows IoT!\nCount = " + Count.ToString();
        }
    }
}
