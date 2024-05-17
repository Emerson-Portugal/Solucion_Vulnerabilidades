using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CnReporte
    {
        private readonly CdReporte objCapaDato;

        public CnReporte()
        {
            objCapaDato = new CdReporte();
        }

        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion)
        {
            return objCapaDato.Ventas(fechainicio, fechafin, idtransaccion);
        }

        public DashBoard VerDashBoard()
        {
            return objCapaDato.VerDashBoard();
        }
    }

}
