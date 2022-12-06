﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {
                    var municipios = context.Municipios.FromSqlRaw($"MunicipioGetByIdEstado {IdEstado}").ToList();
                    result.Objects = new List<object>();
                    if (municipios != null)
                    {
                        foreach (var objMunicipio in municipios)
                        {

                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = objMunicipio.IdMunicipio;
                            municipio.Nombre = objMunicipio.Nombre;

                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = IdEstado;

                            result.Objects.Add(municipio);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
