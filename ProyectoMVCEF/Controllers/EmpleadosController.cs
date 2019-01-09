using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class EmpleadosController : Controller
    {
        HelperEmpleados helper;

        public EmpleadosController()
        {
            this.helper = new HelperEmpleados();
        }

        //GET: EmpleadosOficio
        public ActionResult EmpleadosOficio()
        {
            List<String> oficios = helper.GetOficios();
            ViewBag.Oficios = oficios;
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadosOficio(string oficio)
        {
            List<String> oficios = this.helper.GetOficios();
            List<EMP> empleados = this.helper.GetEmpleadosOficio(oficio);
            ResumenEmpleados resumen = 
                this.helper.GetResumenEmpleados(oficio);
            ViewBag.Oficios = oficios;
            ViewBag.Resumen = resumen;
            return View(empleados);
        }

        public ActionResult EmpleadosDepartamento()
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadosDepartamento(int departamento)
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();
            ViewBag.Departamentos = departamentos;
            ResumenEmpleados resumen =
                this.helper.GetResumenEmpleadosDepartamento(departamento);
            ViewBag.Resumen = resumen;
            List<EMP> empleados =
                this.helper.GetEmpleadosDepartamento(departamento);
            return View(empleados);
        }

        public ActionResult OrdenarEmpleados(String orden)
        {
            List<EMP> empleados = this.helper.GetEmpleados();
            if (orden != null)
            {
                if (orden.ToLower() == "asc")
                {
                    empleados = 
                        empleados.OrderBy(z => z.APELLIDO).ToList();
                    ViewBag.Orden = "DESC";
                }
                else
                {
                    empleados =
                      empleados.OrderByDescending(z => z.APELLIDO).ToList();
                    ViewBag.Orden = "ASC";
                }
            }
            else
            {
                ViewBag.Orden = "ASC";
            }
            
            return View(empleados);
        }

        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }
    }
}