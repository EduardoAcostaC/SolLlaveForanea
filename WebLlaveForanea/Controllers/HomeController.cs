using EntidadLlaveForanea;
using NegociosLlaveForanea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLlaveForanea.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        N_Mascotas negocio = new N_Mascotas();
        N_Especie negEspecie = new N_Especie();
        public ActionResult Index()
        {
           
            try
            {
                List<E_Mascotas> lista = negocio.ObtenerMascotas();
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                List<E_Mascotas> lista = new List<E_Mascotas>();
                return View("Index", lista);
            }
        }
        public ActionResult IrFormulario()
        {
            try
            {
                List<E_Especie> lista = negEspecie.ObtenerEspecies();
                ViewBag.especieId = new SelectList(lista, "idEspecie", "nombreEspecie");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                List<E_Mascotas> lista = new List<E_Mascotas>();
                return View("Index", lista);
            }
            return View("VistaFormulario");
        }

        public ActionResult FormularioPOST(E_Mascotas mascota)
        {

            try
            {

                bool existe = negocio.ExisteMascota(mascota.nombre);
                if (existe == true)
                {
                    TempData["verificacion"] = $"Ya existe la mascota {mascota.nombre}";
                    List<E_Especie> lista = negEspecie.ObtenerEspecies();
                    ViewBag.especieId = new SelectList(lista, "idEspecie", "nombreEspecie", mascota.especieId);

                    return View("VistaFormulario");
                }

                negocio.AgregarMascotas(mascota);
                TempData["mensaje"] = "Se ha agregado a la base de datos";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("VistaFormulario");
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                negocio.BorrarMascotas(id);
                TempData["mensaje"] = "Se ha eliminado a la base de datos";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult IrEditar(int id)
        {
            try
            {
                E_Mascotas mascota = negocio.ObtenerMascotaPorId(id);
                List<E_Especie> lista = negEspecie.ObtenerEspecies();
                ViewBag.especieId = new SelectList(lista, "idEspecie", "nombreEspecie", mascota.especieId);
                return View("VistaEditar", mascota);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                List<E_Mascotas> lista = new List<E_Mascotas>();
                return View("Index", lista);
            }
            
        }

        public ActionResult EditarPOST(E_Mascotas mascota)
        {
            try
            {
                negocio.EditarMascotas(mascota);
                TempData["mensaje"] = "Se ha agregado a la base de datos";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("VistaEditar", mascota);
            }
        }

        public ActionResult Buscar(string valor)
        {

            try
            {
                List<E_Mascotas> lista = negocio.BuscarMascotas(valor);
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;

                return RedirectToAction("Index");
            }
        }

    }
}