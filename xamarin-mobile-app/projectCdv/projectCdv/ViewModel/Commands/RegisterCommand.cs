using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace projectCdv.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;

            if (user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                        return false;

                    return true;
                }

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            User user = (User)parameter;
            viewModel.Register(user);
        }
    }
}
