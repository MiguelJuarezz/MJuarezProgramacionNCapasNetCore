using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AseguradoraController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.Aseguradora.GetAll();

            if (result.Correct)
            {
                ML.Aseguradora aseguradora = new ML.Aseguradora();
                aseguradora.Aseguradoras = result.Objects;
                return View(aseguradora);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.Rol = new ML.Rol();

            ML.Result resultUsuario = BL.Usuario.GetAll(aseguradora.Usuario);


            if (IdAseguradora == null)
            {
                aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                return View(aseguradora);
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Aseguradora.GetById(IdAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la aseguradora seleccionada";
                }
                return View(aseguradora);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {

            ML.Result result = new ML.Result();

            if (aseguradora.IdAseguradora == 0)
            {
                //add
                result = BL.Aseguradora.Add(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado La Aseguradora";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado la Aseguradora" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                //update
                result = BL.Aseguradora.Update(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha Actualizado El Registro";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha Actualizado El Registro " + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
        }

        [HttpGet]
        public ActionResult Delete(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            result = BL.Aseguradora.Delete(IdAseguradora);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha elimnado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha elimnado el registro" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
    }
}
