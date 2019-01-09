using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class ResumenEmpleados
    {
        public int MaximoSalario { get; set; }
        public int Personas { get; set; }
        public int SumaSalarial { get; set; }
        public double MediaSalarial { get; set; }
    }
}