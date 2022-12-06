using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Curp { get; set; }

    public int IdRol { get; set; }

    public string? Imagen { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Aseguradora> Aseguradoras { get; } = new List<Aseguradora>();

    public virtual ICollection<Direccion> Direccions { get; } = new List<Direccion>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    //Agregadas
    public string RolNombre { get; set; }
    public int IdDireccion { get; set; }
    public string Calle { get; set; }
    public string NumeroInterior { get; set; }
    public string NumeroExterior { get; set; }
    public int IdColonia { get; set; }
    public string ColoniaNombre { get; set; }
    public string CodigoPostal { get; set; }
    public int IdMunicipio { get; set; }
    public string MunicipioNombre { get; set; }
    public int IdEstado { get; set; }
    public string EstadoNombre { get; set; }
    public int IdPais { get; set; }
    public string PaisNombre { get; set; }

}
