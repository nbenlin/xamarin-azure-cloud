using projectCdv.Model;
using projectCdv.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace projectCdv.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterNavigationCommand RegisterNavigationCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public MainViewModel()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand = new RegisterNavigationCommand(this);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
