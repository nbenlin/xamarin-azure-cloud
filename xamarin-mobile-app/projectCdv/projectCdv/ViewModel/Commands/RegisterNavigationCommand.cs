using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace projectCdv.ViewModel.Commands
{
    public class RegisterNavigationCommand : ICommand
    {
        private MainViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterNavigationCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
}
