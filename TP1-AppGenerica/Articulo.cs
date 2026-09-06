using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio {
    public class Articulo {

        public int Id { get ; set ; }

        public string Codigo { get ; set ; }

        public string Nombre { get ; set ; }

        public string Descripcion { get ; set; }
 
        public decimal Precio { get ; set ; }

        // Objeto Marca para mantener la relación de Clave Foránea (IdMarca)
        public Marca Marca { get ; set; }

        // Objeto Categoria para mantener la relación de Clave Foránea (IdCategoria)
        public Categoria Categoria { get ; set ; }

        // Relación 1 a N: soporta que el producto tenga una o varias imágenes
        public List<Imagen> Imagenes { get ; set ; }

        // Constructor para inicializar las instancias y evitar errores de referencia nula (NullReferenceException)
        public Articulo()  {

            Marca = new Marca() ;

            Categoria = new Categoria() ;

            Imagenes = new List<Imagen>() ;
        }
    }
}