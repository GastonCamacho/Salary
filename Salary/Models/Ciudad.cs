using System;
using System.Collections.Generic;

#nullable disable

namespace Salary.Models
{
    public partial class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Ciudad1 { get; set; }
        public int? IdProvincia { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
