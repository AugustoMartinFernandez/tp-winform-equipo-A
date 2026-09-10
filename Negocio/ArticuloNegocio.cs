using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
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

                    // Buscar las imagenes
                    AccesoDatos datosImagen = new AccesoDatos();
                    try
                    {
                        datosImagen.setearConsultas("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = " + aux.Id);
                        datosImagen.ejecutarLectura();

                        while (datosImagen.Lector.Read())
                        {
                            Imagen img = new Imagen();
                            img.Id = (int)datosImagen.Lector["Id"];
                            img.ImagenUrl = (string)datosImagen.Lector["ImagenUrl"];

                            aux.Imagenes.Add(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        datosImagen.cerrarConexion();
                    }
                    // -------------------------------------------------------------

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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Insert con parametros en vez de concatenar el texto directo
                datos.setearConsultas("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria)");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                // Mando el Id de la marca y la categoria, no el objeto entero
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                //Cierro la conexion pase lo que pase, haya salido bien o no
                datos.cerrarConexion(); 
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion AS 'Marca', CATEGORIAS.Descripcion AS 'Categoria', Precio, IdMarca, IdCategoria FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id AND ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "ARTICULOS.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "ARTICULOS.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "ARTICULOS.Descripcion LIKE '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsultas(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}