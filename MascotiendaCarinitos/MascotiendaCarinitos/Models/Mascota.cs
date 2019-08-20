
using System;
using System.Collections.Generic;
using System.Text;

namespace MascotiendaCarinitos.Models
{
    using Newtonsoft.Json;
    public class Mascota
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Tipo { get; set; }
        [JsonProperty(PropertyName = "price")]
        public double Precio { get; set; }

    }
}
