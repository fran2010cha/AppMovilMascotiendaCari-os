using System;
using System.Collections.Generic;
using System.Text;

namespace MascotiendaCarinitos.Models
{
    class Raza
    {
        public int RazaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EspecieID { get; set; }
        public virtual ICollection<Mascota> Mascotas { get; set; }
    }
}
