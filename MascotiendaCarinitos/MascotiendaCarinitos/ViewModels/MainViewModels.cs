using System;
using System.Collections.Generic;
using System.Text;

namespace MascotiendaCarinitos.ViewModels
{
    public class MainViewModels
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public MascotaViewModel Mascotas
        {
            get;
            set;
        }
        public MascotViewModel Mascota
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public MainViewModels()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        #endregion
        #region Singleton
        private static MainViewModels instance;

        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();
            }

            return instance;
        }
        #endregion
    }
}
