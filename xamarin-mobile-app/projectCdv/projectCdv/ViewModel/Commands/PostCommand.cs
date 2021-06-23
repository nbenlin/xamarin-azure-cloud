using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace projectCdv.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        NewTravelViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public PostCommand(NewTravelViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post == null)
                return false;                
            
            return true;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
