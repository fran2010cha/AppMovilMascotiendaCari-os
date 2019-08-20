using System;
using System.Collections.Generic;
using System.Text;

namespace MascotiendaCarinitos.ViewModels
{
    using Models;
    public class MascotViewModel : BaseViewModel
    {
        #region
        public Mascota Mascota
        {
            get;
            set;
        }
        #endregion
        
        #region Constructors
        public MascotViewModel(Mascota mascot)
        {
            this.Mascota = mascot;
        } 
        #endregion
    }
}
