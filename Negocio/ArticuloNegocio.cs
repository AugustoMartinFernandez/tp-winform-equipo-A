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

            try
            {
                datos.setearConsultas("Select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion AS 'Marca', CATEGORIAS.Descripcion AS 'Categoria', Precio, ARTICULOS.IdMarca, ARTICULOS.IdCategoria FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

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
                datos.cerrarConexion();
            }

            // Traigo TODAS las imagenes en una sola consulta aparte
            AccesoDatos datosImagenes = new AccesoDatos();
            List<Imagen> todasLasImagenes = new List<Imagen>();

            try
            {
                datosImagenes.setearConsultas("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datosImagenes.ejecutarLectura();

                while (datosImagenes.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)datosImagenes.Lector["Id"];
                    img.IdArticulo = (int)datosImagenes.Lector["IdArticulo"];
                    img.ImagenUrl = (string)datosImagenes.Lector["ImagenUrl"];
                    todasLasImagenes.Add(img);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datosImagenes.cerrarConexion();
            }

            foreach (Articulo articulo in lista)
            {
                articulo.Imagenes = todasLasImagenes.FindAll(img => img.IdArticulo == articulo.Id);
            }

            return lista;
        }

        public void agregar(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsultas("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria)");

                datos.setearParametro("@Codigo", nuevoArticulo.Codigo);
                datos.setearParametro("@Nombre", nuevoArticulo.Nombre);
                datos.setearParametro("@Descripcion", nuevoArticulo.Descripcion);
                datos.setearParametro("@Precio", nuevoArticulo.Precio);
                datos.setearParametro("@IdMarca", nuevoArticulo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevoArticulo.Categoria.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datos.cerrarConexion(); 
            }
        }

        public void modificar(Articulo modificarArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultas("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdMarca = @IdMarca, IdCategoria = @IdCategoria where Id = @Id");
                datos.setearParametro("@Codigo", modificarArticulo.Codigo);
                datos.setearParametro("@Nombre", modificarArticulo.Nombre);
                datos.setearParametro("@Descripcion", modificarArticulo.Descripcion);
                datos.setearParametro("@Precio", modificarArticulo.Precio);
                datos.setearParametro("@IdMarca", modificarArticulo.Marca.Id);
                datos.setearParametro("@IdCategoria", modificarArticulo.Categoria.Id);
                datos.setearParametro("@Id", modificarArticulo.Id);

                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultas("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
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