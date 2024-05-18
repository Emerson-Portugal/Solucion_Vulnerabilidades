using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string correo, string clave)
        {
            var usuario = new CnUsuarios().Listar()
                                          .Find(u => u.Correo == correo && u.Clave == CnRecursos.ConvertirSha256(clave));

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }
            else
            {
                if (usuario.Reestablecer)
                {
                    TempData["IdUsuario"] = usuario.IdUsuario;
                    return RedirectToAction("CambiarClave");
                }

                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }
        }





        [HttpPost]
        public ActionResult CambiarClave(string idusuario, string claveactual, string nuevaclave, string confirmarclave)
        {
            Usuario oUsuario = new CnUsuarios().Listar().Find(u => u.IdUsuario == int.Parse(idusuario));

            if (oUsuario == null)
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "Usuario no encontrado";
                return View();
            }

            if (oUsuario.Clave != CnRecursos.ConvertirSha256(claveactual))
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }

            if (nuevaclave != confirmarclave)
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = claveactual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            ViewData["vclave"] = "";

            nuevaclave = CnRecursos.ConvertirSha256(nuevaclave);

            string mensaje = string.Empty;
            bool respuesta = new CnUsuarios().CambiarClave(int.Parse(idusuario), nuevaclave, out mensaje);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdUsuario"] = idusuario;
                ViewBag.Error = mensaje;
                return View();
            }
        }




        [HttpPost]
        public ActionResult Reestablecer(string correo)
        {
            var usuario = new CnUsuarios().Listar().Find(item => item.Correo == correo);

            if (usuario == null)
            {
                ViewBag.Error = "No se encontró un usuario relacionado a ese correo";
                return View();
            }

            string mensaje = string.Empty;
            bool respuesta = new CnUsuarios().ReestablecerClave(usuario.IdUsuario, correo, out mensaje);

            if (respuesta)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }



        public ActionResult CerrarSesion() {

            return RedirectToAction("Index", "Acceso");

        }



    }
}