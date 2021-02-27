using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_UI.Models;
using Xamarin_UI.Views;

namespace Xamarin_UI.ViewModels
{
    public class MainViewModel
{   
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand MoveToSignUpCommand { get; }

        public ICommand SignUpCommand { get; }

        public MenuOption StudentDetails { get; set; } = new MenuOption("Students Detail", "user.png");

        public MenuOption Settings { get; set; } = new MenuOption("Settings", "redPadlock.png");

        public MenuOption Access { get; set; } = new MenuOption("Access", "loginUser.png");

        public MenuOption Community { get; set; } = new MenuOption("Community", "intec.png");

        public MenuOption MoreDetails { get; set; } = new MenuOption("More Details", "grid.png");

        public MenuOption Status { get; set; } = new MenuOption("Status", "status.png");

        public MainViewModel()
        {
            LoginCommand = new Command(OnLogin);
            MoveToSignUpCommand = new Command(OnSignUpPage);
            SignUpCommand = new Command(OnSignUp);
        }

        private async void OnLogin()
        {
            
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No field can be empty", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Welcome!", $"Hello, {Username}. You are succefully Logged In.", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }

        private async void OnSignUpPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        private async void OnSignUp()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No fields can be empty", "OK");
            }
            else if (Password != PasswordConfirm)
            {
                await App.Current.MainPage.DisplayAlert("Error", "The passwords you entered are not the same.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Welcome!", $"Hello, {Name}. You are succefully Logged In.", "OK");

                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }
    }
}
