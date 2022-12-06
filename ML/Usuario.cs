using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int? IdUsuario { get; set; }
        //[Required]
        //[StringLength(50)]
        public string? Nombre { get; set; }
        //[Required]
        //[DisplayName("Apellido Paterno: ")]
        public string? ApellidoPaterno { get; set; }
        //[DisplayName("Apellido Materno: ")]
        public string? ApellidoMaterno { get; set; }
        //[DisplayName("Fecha De Nacimiento: ")]
        public string? FechaNacimiento { get; set; }
        //[Required]
        public string? Sexo { get; set; }
        //[Required]
        public string? Telefono { get; set; }
        //[Required]
        public string? Email { get; set; }
        //[Required]
        public string? UserName { get; set; }
        //[Required]
        public string? Password { get; set; }
        public string? Celular { get; set; }
        public string? Curp { get; set; }
        public string? Imagen { get; set; }
        public bool? Status { get; set; }
        public List<object>? Usuarios { get; set; }

        //propiedad de navegacion
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }
    }
}
