using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_equipo_A.UI
{
    internal class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            // siempre cuando toquemos una bd debemos protegerla aca, por si se corta la conexion o falla algo
            try
            {
                // Seteamos la consulta: trae los articulos con marca y categoria
                datos.setearConsultas("Select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion AS 'Marca', CATEGORIAS.Descripcion AS 'Categoria', Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id");
                datos.ejecutarLectura();

                // Recorremos fila por fila con lo que trajo la consulta
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    // No hace falta instanciar Marca ni Categoria de nuevo, ya nacen creadas desde el constructor de Articulo
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // Cierro la conexion pase lo que pase, haya salido bien o no
                datos.cerrarConexion();
            }
            // Devuelvo la lista ya armada con todos los articulos
            return lista;
        }
    }
}
