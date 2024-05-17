using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CnVenta
    {
        private readonly CdVenta objCapaDato;

        public CnVenta()
        {
            objCapaDato = new CdVenta();
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objCapaDato.Registrar(obj, DetalleVenta, out Mensaje);
        }
    }

}
