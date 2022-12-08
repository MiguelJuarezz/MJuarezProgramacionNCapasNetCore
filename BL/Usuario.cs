using System.Data;
using System.Data.OleDb;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {
                    usuario.Rol.IdRol = (usuario.Rol.IdRol ==null) ? 0: usuario.Rol.IdRol;
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;

                    var usuarios = context.Usuarios.FromSqlRaw($"UsuarioGetAll '{usuario.Nombre}','{usuario.ApellidoPaterno}',{usuario.Rol.IdRol}").ToList();
                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuarioobj = new ML.Usuario();
                            usuarioobj.IdUsuario = obj.IdUsuario;
                            usuarioobj.Nombre = obj.Nombre;
                            usuarioobj.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioobj.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarioobj.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuarioobj.Sexo = obj.Sexo;
                            usuarioobj.Telefono = obj.Telefono;
                            usuarioobj.Email = obj.Email;
                            usuarioobj.UserName = obj.UserName;
                            usuarioobj.Password = obj.Password;
                            usuarioobj.Celular = obj.Celular;
                            usuarioobj.Imagen = obj.Imagen;
                            usuarioobj.Curp = obj.Curp;

                            usuarioobj.Rol = new ML.Rol();
                            usuarioobj.Rol.IdRol = obj.IdRol;
                            usuarioobj.Rol.Nombre = obj.RolNombre;

                            usuarioobj.Direccion = new ML.Direccion();
                            usuarioobj.Direccion.IdDireccion = obj.IdDireccion;
                            usuarioobj.Direccion.Calle = obj.Calle;
                            usuarioobj.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuarioobj.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuarioobj.Direccion.Colonia = new ML.Colonia();
                            usuarioobj.Direccion.Colonia.IdColonia = obj.IdColonia;
                            usuarioobj.Direccion.Colonia.Nombre = obj.ColoniaNombre;
                            usuarioobj.Direccion.Colonia.CosdigoPostal = obj.CodigoPostal;


                            usuarioobj.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioobj.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuarioobj.Direccion.Colonia.Municipio.Nombre = obj.MunicipioNombre;

                            usuarioobj.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioobj.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Nombre = obj.EstadoNombre;

                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.PaisNombre;

                            usuarioobj.Status = obj.Status.Value;

                            result.Objects.Add(usuarioobj);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
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

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {

                    var objUsuario = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Email = objUsuario.Email;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Password = objUsuario.Password;
                        usuario.Celular = objUsuario.Celular;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Curp = objUsuario.Curp;


                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objUsuario.ColoniaNombre;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.PaisNombre;

                        usuario.Status = objUsuario.Status.Value;

                        result.Object = usuario;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla usuarios";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetByUsername(string username)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {

                    var objUsuario = context.Usuarios.FromSqlRaw($"UsuarioGetByUsername {username}").FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Email = objUsuario.Email;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Password = objUsuario.Password;
                        usuario.Celular = objUsuario.Celular;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Curp = objUsuario.Curp;


                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objUsuario.ColoniaNombre;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.PaisNombre;

                        usuario.Status = objUsuario.Status.Value;

                        result.Object = usuario;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla usuarios";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result ConvertirExceltoDataTable(string connString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Hoja1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableusuario = new DataTable();

                        da.Fill(tableusuario);

                        if (tableusuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableusuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.FechaNacimiento = row[3].ToString();
                                usuario.Sexo = row[4].ToString();
                                usuario.Telefono = row[5].ToString();
                                usuario.Email = row[6].ToString();
                                usuario.UserName = row[7].ToString();
                                usuario.Password = row[8].ToString();
                                usuario.Celular = row[9].ToString();
                                usuario.Curp = row[10].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[11].ToString());

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInterior = row[13].ToString();
                                usuario.Direccion.NumeroExterior = row[14].ToString();

                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[15].ToString());


                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        if (tableusuario.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
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

        public static ML.Result ValidarExcel(List<object> Object)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //Datatablle   //rows   //columns
                int i = 1;
                foreach (ML.Usuario usuario in Object)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;


                    usuario.Nombre = (usuario.Nombre == "") ? error.Mensaje += "Ingresar el Nombre " : usuario.Nombre;//operador ternario

                    if(usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresar El Apellido Paterno";
                    }
                    if(usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingresa El Apellido Materno";
                    }
                    if (usuario.FechaNacimiento == "")
                    {
                        error.Mensaje += "Ingresa La Fecha De Nacimiento";
                    }
                    if (usuario.Sexo == "")
                    {
                        error.Mensaje += "Ingresa El Sexo";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingresa El Telefono";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingresa El Email";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingresa El Username";
                    }
                    if (usuario.Password == "")
                    {
                        error.Mensaje += "Ingresa El Password";
                    }
                    if (usuario.Celular == "")
                    {
                        error.Mensaje += "Ingresa El Celular";
                    }
                    if (usuario.Curp == "")
                    {
                        error.Mensaje += "Ingresa El Curp";
                    }
                    if (usuario.Rol.IdRol.ToString() == "")
                    {
                        error.Mensaje += "Ingresa El IdRol";
                    }
                    if (usuario.Direccion.Calle == "")
                    {
                        error.Mensaje += "Ingresa La Calle";
                    }
                    if (usuario.Direccion.NumeroInterior == "")
                    {
                        error.Mensaje += "Ingresa El Numero Interior";
                    }
                    if (usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje += "Ingresa El Numero Exterior";
                    }
                    if (usuario.Direccion.Colonia.IdColonia.ToString() == "")
                    {
                        error.Mensaje += "Ingresa El Id Colonia";
                    }
                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {

                    //var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento,
                    //    usuario.Sexo, usuario.Telefono, usuario.Email, usuario.UserName, usuario.Password, usuario.Celular,
                    //    usuario.Curp, usuario.Imagen, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                    //    usuario.Direccion.Colonia.IdColonia);

                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}' , '{usuario.ApellidoPaterno}' , '{usuario.ApellidoMaterno}' , '{usuario.FechaNacimiento}' , '{usuario.Sexo}' , '{ usuario.Telefono}' ," +
                        $"'{usuario.Email}' , '{usuario.UserName}' , '{usuario.Password}' , '{usuario.Celular}' , '{usuario.Curp}' , '{usuario.Imagen}' , {usuario.Rol.IdRol}," +
                        $"'{usuario.Direccion.Calle}' , '{usuario.Direccion.NumeroInterior}' , '{usuario.Direccion.NumeroExterior}' , {usuario.Direccion.Colonia.IdColonia},{usuario.Status}");


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {

                    var updateResult = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario}, '{usuario.Nombre}' , '{usuario.ApellidoPaterno}' , '{usuario.ApellidoMaterno}' , '{usuario.FechaNacimiento}' , '{usuario.Sexo}' , '{usuario.Telefono}' ," +
                      $"'{usuario.Email}' , '{usuario.UserName}' , '{usuario.Password}' , '{usuario.Celular}' , '{usuario.Curp}' , '{usuario.Imagen}', {usuario.Rol.IdRol} , " +
                      $"'{usuario.Direccion.Calle}' , '{usuario.Direccion.NumeroInterior}' , '{usuario.Direccion.NumeroExterior}' , {usuario.Direccion.Colonia.IdColonia}");

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos";
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

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result ChangeStatus(int IdUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezProgramacionNcapasContext context = new DL.MjuarezProgramacionNcapasContext())
                {
                    var usuarios = context.Database.ExecuteSqlRaw($"UsuarioChangeStatus {IdUsuario}, {status}");

                    if (usuarios > 0)
                    {
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
