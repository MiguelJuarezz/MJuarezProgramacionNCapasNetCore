using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public string NumeroEmpleado { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string FechaNaciento { get; set; }
        public string NSS { get; set; }
        public string FechaIngreso { get; set; }
        public string Foto { get; set; }
        public List<object> Empleados { get; set; }

        //propiedad de navegacion
        public ML.Empresa Empresa { get; set; }

    }
}