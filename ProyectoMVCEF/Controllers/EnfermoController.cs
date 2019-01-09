using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class EnfermoController : Controller
    {
        HelperEnfermos helper;

        public EnfermoController()
        {
            this.helper = new HelperEnfermos();
        }

        //Get: EliminarEnfermos
        public ActionResult EliminarEnfermos()
        {
            List<ENFERMO> enfermos = this.helper.GetEnfermos();
            return View(enfermos);
        }

        //Post: EliminarEnfermos
        [HttpPost]
        public ActionResult EliminarEnfermos(int inscripcion)
        {
            int afectados = this.helper.EliminarEnfermo(inscripcion);
            ViewBag.Afectados = "Registros eliminados: " + afectados;
            List<ENFERMO> enfermos = this.helper.GetEnfermos();
            return View(enfermos);
        }

    }
}