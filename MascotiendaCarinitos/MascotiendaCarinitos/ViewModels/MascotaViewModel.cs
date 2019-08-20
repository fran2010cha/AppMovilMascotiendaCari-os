
using System.Text;

namespace MascotiendaCarinitos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using MascotiendaCarinitos.Models;
    using MascotiendaCarinitos.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MascotaViewModel :BaseViewModel
    {
        #region Services
        private readonly ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<MascotaItemViewModel> mascotas;
        private bool isRefreshing;
        private string filter;
        private List<Mascota> MascotaList;
        #endregion

        #region Properties
        public ObservableCollection<MascotaItemViewModel> Mascotas
        {
            get { return this.mascotas; }
            set { SetValue(ref this.mascotas, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set {
                SetValue(ref this.filter, value);
                this.Buscar();
            }
        }
        #endregion

        #region Constructors
        public MascotaViewModel()
        {
            this.apiService = new ApiService();
            this.LoadMascotas();
        }
        #endregion

        #region Methods
        private async void LoadMascotas()
        {
            
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                    connection.Message,
                   "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            
            var response = await this.apiService.GetList<Mascota>(
                "http://petstore-demo-endpoint.execute-api.com",
                "/petstore",
                "/pets");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            this.MascotaList = (List<Mascota>)response.Result;
            this.Mascotas =  new ObservableCollection<MascotaItemViewModel>(
                 this.ToMascotaItemViewModel());
            this.IsRefreshing = false;
        }

    #region Methods
        private IEnumerable<MascotaItemViewModel> ToMascotaItemViewModel()
        {
            return this.MascotaList.Select(l => new MascotaItemViewModel
            {
                Id = l.Id,
                Tipo = l.Tipo,
                Precio = l.Precio,
                
            });
        } 
        #endregion

    #endregion
        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadMascotas);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }
        private void Buscar()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Mascotas = new ObservableCollection<MascotaItemViewModel>(
                 this.ToMascotaItemViewModel());
            }
            else
            {
                this.Mascotas = new ObservableCollection<MascotaItemViewModel>(
                    this.ToMascotaItemViewModel().Where(m => m.Tipo.ToLower().Contains(this.Filter.ToLower())));

            }
        }
        #endregion
    }
}
