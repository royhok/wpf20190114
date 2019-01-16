using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator
{
    public class Calc : INotifyPropertyChanged
    {
        string inputString = "";

        string displayText = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Op { get; set; }
        public double? Op1 { get; set; }
        public ICommand Append { protected set; get; }
        public ICommand Backspace { protected set; get; }
        public ICommand Clear { protected set; get; }
        public ICommand Operator { protected set; get; }
        public ICommand Calculate { protected set; get; }

        public Calc()
        {
            this.Append = new Append(this);
            this.Backspace = new Backspace(this);
            this.Clear = new Clear(this);
            this.Operator = new Operator(this);
            this.Calculate = new Calculate(this);
        }

        public string InputString
        {
            internal set
            {
                if(inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    if(value != "")
                    {
                        DisplayText = value;
                    }
                }
            }
            get { return inputString; }
        }

        public string DisplayText
        {
            internal set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class Append : ICommand
    {
        private Calc c;
        public event EventHandler CanExecuteChanged;

        public Append(Calc c)
        {
            this.c = c;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            c.InputString += parameter;
        }
    }

    class Backspace : ICommand
    {
        private Calc c;

        public Backspace(Calc c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            int length = c.InputString.Length - 1;
            if( length > 0)
            {
                c.InputString = c.InputString.Substring(0, length);
            }
            else
            {
                c.InputString = c.DisplayText = "";
            }
        }
    }

    class Clear : ICommand
    {
        private Calc c;

        public Clear(Calc c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            c.InputString = c.DisplayText = "";
            c.Op1 = null;
        }
    }

    class Operator : ICommand
    {
        private Calc c;

        public Operator(Calc c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.InputString.Length > 0 || parameter.ToString() == "-";
        }

        public void Execute(object parameter)
        {
            string op = parameter.ToString();
            double op1;
            if (double.TryParse(c.InputString, out op1))
            {
                c.Op1 = op1;
                c.Op = op;
                c.InputString = "";
            }
            else if(c.InputString == "" && op == "-")
            {
                c.InputString = "-";
            }
        }
    }

    class Calculate : ICommand
    {
        private Calc c;

        public Calculate(Calc c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            double op2;
            return c.Op1 != null && double.TryParse(c.InputString, out op2) && (c.Op != "/" || op2 != 0);
        }

        public void Execute(object parameter)
        {
            double op2 = double.Parse(c.InputString);
            c.InputString = calculate(c.Op, (double)c.Op1, op2).ToString();
            c.Op1 = null;
        }

        private static double calculate(string op, double op1, double op2)
        {
            switch(op)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "*": return op1 * op2;
                case "/": return op1 / op2;
            }
            return 0;
        }
    }
}
