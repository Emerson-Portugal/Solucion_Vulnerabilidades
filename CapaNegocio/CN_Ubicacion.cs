using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CnUbicacion
    {
        private readonly CdUbicacion objCapaDato;

        public CnUbicacion()
        {
            objCapaDato = new CdUbicacion();
        }

        public List<Departamento> ObtenerDepartamento()
        {
            return objCapaDato.ObtenerDepartamento();
        }

        public List<Provincia> ObtenerProvincia(string iddepartamento)
        {
            return objCapaDato.ObtenerProvincia(iddepartamento);
        }

        public List<Distrito> ObtenerDistrito(string iddepartamento, string idprovincia)
        {
            return objCapaDato.ObtenerDistrito(iddepartamento, idprovincia);
        }
    }

}
