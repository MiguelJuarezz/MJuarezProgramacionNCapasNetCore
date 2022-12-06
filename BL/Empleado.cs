using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
        //        {

        //            var empleados = context.Empleados.FromSqlRaw("AseguradoraGetAll").ToList();
        //            result.Objects = new List<object>();

        //            if (empleados != null)
        //            {
        //                foreach (var obj in empleados)
        //                {
        //                    ML.Aseguradora aseguradora = new ML.Aseguradora();
        //                    aseguradora.IdAseguradora = obj.IdAseguradora;
        //                    aseguradora.Nombre = obj.Nombre;
        //                    aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
        //                    aseguradora.FechaModificacion = obj.FechaModificacion.ToString();
        //                    aseguradora.Usuario = new ML.Usuario();
        //                    aseguradora.Usuario.IdUsuario = obj.IdUsuario.Value;
        //                    aseguradora.Usuario.Nombre = obj.UsuarioNombre;


        //                    result.Objects.Add(aseguradora);
        //                }

        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontraron registros.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;

        //    }

        //    return result;
        //}
    }
}
