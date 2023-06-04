using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppemployee.Commands
{
    public class relay : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action dowork;

        public relay(Action work)
        {

            dowork = work;

        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            dowork();
        }
    }
}
