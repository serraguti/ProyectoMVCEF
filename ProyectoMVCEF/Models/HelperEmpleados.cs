using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class HelperEmpleados
    {
        //context, entity
        EntidadHospital entidad;

        public HelperEmpleados()
        {
            this.entidad = new EntidadHospital();
        }

        public List<String> GetOficios()
        {
            //WHERE NO PODEMOS UTILIZAR PARSE
            var consulta = (from datos in entidad.EMP
                            select datos.OFICIO).Distinct();
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosOficio(String oficio)
        {
            var consulta = from datos in entidad.EMP
                           where datos.OFICIO == oficio
                           select datos;
            return consulta.ToList();
        }

        public ResumenEmpleados GetResumenEmpleados(String oficio)
        {
            List<EMP> empleados = this.GetEmpleadosOficio(oficio);
            int personas = empleados.Count;
            int? maximo = empleados.Max(x => x.SALARIO);
            System.Nullable<int> suma = empleados.Sum(z => z.SALARIO);
            double? media = empleados.Average(z => z.SALARIO);
            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = personas;
            resumen.SumaSalarial = suma.GetValueOrDefault();
            resumen.MaximoSalario = maximo.GetValueOrDefault();
            resumen.MediaSalarial = media.GetValueOrDefault();
            return resumen;
        }

        public List<DEPT> GetDepartamentos()
        {
            var consulta = from datos in entidad.DEPT
                           select datos;
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosDepartamento(int deptno)
        {
            var consulta = from datos in entidad.EMP
                           where datos.DEPT_NO == deptno
                           select datos;
            return consulta.ToList();
        }

        public ResumenEmpleados GetResumenEmpleadosDepartamento(int deptno)
        {
            List<EMP> empleados = this.GetEmpleadosDepartamento(deptno);
            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = empleados.Count();
            resumen.MaximoSalario = 
                empleados.Max(z => z.SALARIO).GetValueOrDefault();
            resumen.SumaSalarial =
                empleados.Sum(x => x.SALARIO).GetValueOrDefault();
            resumen.MediaSalarial =
                empleados.Average(z => z.SALARIO).GetValueOrDefault();
            return resumen;
        }

        public List<EMP> GetEmpleados()
        {
            var consulta = from datos in entidad.EMP
                           select datos;
            return consulta.ToList();
        }
    }
}