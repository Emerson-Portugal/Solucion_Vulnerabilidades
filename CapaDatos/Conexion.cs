using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace CapaDatos
{
    public static class Conexion
    {
        public static string Cn { get; } = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}

