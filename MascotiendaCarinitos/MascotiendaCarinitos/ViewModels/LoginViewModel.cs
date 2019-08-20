using System;
using System.Collections.Generic;
using System.Text;


namespace MascotiendaCarinitos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using MascotiendaCarinitos.Views;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {

            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }

        }
        public bool IsRemenbered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemenbered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

       
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Entre un Email",
                    "Accept");
                return;

            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Entre una password",
                    "Accept");
                return;

            }
            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "chamisimo@gmail.com" || this.Password != "1234") {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Email o contraseña incorrecta.",
                   "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModels.GetInstance().Mascotas= new MascotaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MascotasPage());


        }
        #endregion
    }
}
