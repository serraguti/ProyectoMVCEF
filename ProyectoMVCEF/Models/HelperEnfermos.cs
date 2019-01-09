using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region PROCEDIMIENTOS ALMACENADOS

//CREATE PROCEDURE ELIMINARENFERMO
//(@INSCRIPCION INT)
//AS
//    DELETE FROM ENFERMO

//    WHERE INSCRIPCION = @INSCRIPCION
//GO
//CREATE PROCEDURE MOSTRARENFERMOS
//AS

//    SELECT* FROM ENFERMO
//GO

#endregion

namespace ProyectoMVCEF.Models
{
    public class HelperEnfermos
    {
        EntidadHospital entidad;

        public HelperEnfermos()
        {
            entidad = new EntidadHospital();
        }

        public int EliminarEnfermo(int inscripcion)
        {
            int eliminados = this.entidad.ELIMINARENFERMO(inscripcion);
            return eliminados;
        }

        public List<ENFERMO> GetEnfermos()
        {
            List<ENFERMO> enfermos =
                this.entidad.MOSTRARENFERMOS().ToList();
            return enfermos;
        }
    }
}