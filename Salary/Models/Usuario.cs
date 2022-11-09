using System;
using System.Collections.Generic;

#nullable disable

namespace Salary.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
    }
}
