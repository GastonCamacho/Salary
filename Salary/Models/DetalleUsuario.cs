using System;
using System.Collections.Generic;

#nullable disable

namespace Salary.Models
{
    public partial class DetalleUsuario
    {
        public int IdDetalle { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int? Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public int? Hijos { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdEmpleo { get; set; }
        public int? IdTipoUsuario { get; set; }
    }
}
