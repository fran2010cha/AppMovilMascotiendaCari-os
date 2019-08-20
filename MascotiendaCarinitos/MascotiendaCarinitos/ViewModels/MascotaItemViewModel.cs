
using GalaSoft.MvvmLight.Command;
using MascotiendaCarinitos.Models;
using MascotiendaCarinitos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MascotiendaCarinitos.ViewModels
{
   public class MascotaItemViewModel : Mascota
    {
        
        public ICommand SelectMascotaCommand
        {
            get
            {
                return new RelayCommand(SelectMascota);
            }
        }

        public async void SelectMascota()
        {
            MainViewModels.GetInstance().Mascota = new MascotViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new MascotaPage());
        }
    }
}
