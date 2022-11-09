using System;
using System.Collections.Generic;

#nullable disable

namespace Salary.Models
{
    public partial class Empleo
    {
        public int IdEmpleo { get; set; }
        public int? IdPuesto { get; set; }
        public string Empresa { get; set; }
        public int? IdExperiencia { get; set; }
        public int? UltimoSueldo { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdContrato { get; set; }
    }
}
