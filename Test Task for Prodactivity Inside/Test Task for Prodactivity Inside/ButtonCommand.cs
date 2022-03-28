using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_Task_for_Prodactivity_Inside
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> action;
        
        public ButtonCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
