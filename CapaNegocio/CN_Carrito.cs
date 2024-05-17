using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CnCarrito
    {
        private readonly CdCarrito objCapaDato;

        public CnCarrito()
        {
            objCapaDato = new CdCarrito();
        }

        public bool ExisteCarrito(int idcliente, int idproducto)
        {
            return objCapaDato.ExisteCarrito(idcliente, idproducto);
        }

        public bool OperacionCarrito(int idcliente, int idproducto, bool sumar, out string Mensaje)
        {
            return objCapaDato.OperacionCarrito(idcliente, idproducto, sumar, out Mensaje);
        }

        public int CantidadEnCarrito(int idcliente)
        {
            return objCapaDato.CantidadEnCarrito(idcliente);
        }

        public List<Carrito> ListarProducto(int idcliente)
        {
            return objCapaDato.ListarProducto(idcliente);
        }

        public bool EliminarCarrito(int idcliente, int idproducto)
        {
            return objCapaDato.EliminarCarrito(idcliente, idproducto);
        }
    }
}
