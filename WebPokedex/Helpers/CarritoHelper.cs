using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebPokedex.Helpers
{
    public static class CarritoHelper
    {
        public static List<CarritoItem> obtenerCarrito()
        {
            if (HttpContext.Current.Session["carrito"] == null)
                HttpContext.Current.Session["carrito"] = new List<CarritoItem>();

            return (List<CarritoItem>)HttpContext.Current.Session["carrito"];
        }

        public static void AgregarCarrito(CarritoItem nuevo)
        {

            var carrito = CarritoHelper.obtenerCarrito();
            var existente = carrito.FirstOrDefault(x => x.PokeId == nuevo.PokeId);

            if (existente != null)
            {
                existente.Cantidad++;
            }
            else
            {
                carrito.Add(nuevo);

            }
        }

        public static CarritoItem mapPokeACarrito(Pokemon poke, int cantidad = 1)
        {
            return new CarritoItem
            {
                PokeId = poke.Id,
                PokeName = poke.Nombre,
                PokeTipo = poke.Tipo,
                PrecioUnitario = poke.PrecioUnitario,
                Cantidad = cantidad,
                CantidadMax = poke.Cantidad

            };    
        }

        public static bool CarritoVacio()
        {
            if (obtenerCarrito().Count == 0)
                return true;
            else return false;
        }

        public static CarritoItem itemExistente(Pokemon poke)
        {
            var carrito = CarritoHelper.obtenerCarrito();
            var exitente = carrito.FirstOrDefault(x => x.PokeId == poke.Id);

            return exitente;

        }

        public static CarritoItem obtenerItemDeCarrito(int id)
        {
            var carrito = CarritoHelper.obtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.PokeId == id);
            return item != null ? item : null;
        }

        public static decimal SumaCarrito()
        {
            return CarritoHelper.obtenerCarrito()?.Sum(item => item.Subtotal) ?? 0;
        }

        public static bool estaEnCarrito(int Id)
        {
            var carrito = CarritoHelper.obtenerCarrito();
            var existente = carrito.FirstOrDefault(x => x.PokeId == Id);
            if(existente != null)
            {
                return true;
            }

            return false;
        }
    }
}