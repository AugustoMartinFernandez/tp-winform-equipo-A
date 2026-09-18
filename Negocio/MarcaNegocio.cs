using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Negocio {
    public class MarcaNegocio {
        public List<Marca> listar() {
            List<Marca> lista = new List<Marca>() ;
            AccesoDatos datos = new AccesoDatos() ;

            try {
                datos.setearConsultas("SELECT Id, Descripcion FROM MARCAS") ;
                datos.ejecutarLectura() ;

                while (datos.Lector.Read()) {
                    Marca aux = new Marca() ;
                    aux.Id = (int)datos.Lector["Id"] ;
                    aux.Descripcion = (string)datos.Lector["Descripcion"] ;
                    lista.Add(aux) ;
                }
                return lista ;
            }
            catch (Exception ex) {
                throw ex ; 
            }
            finally {
                datos.cerrarConexion() ;
            }
        }

        public void agregar(Marca nueva) {
         
            if (string.IsNullOrWhiteSpace(nueva.Descripcion))
                throw new Exception("La descripción de la marca no puede estar vacía.");
            
            if (nueva.Descripcion.Length > 50)
                throw new Exception("La descripción de la marca no puede superar los 50 caracteres.");

            AccesoDatos datos = new AccesoDatos() ;
            try {
        
                datos.setearConsultas("INSERT INTO MARCAS (Descripcion) VALUES (@Descripcion)") ;
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.ejecutarAccion() ;
            }
            catch (Exception ex){
                throw ex ; 
            }
            finally{ 
                datos.cerrarConexion() ;
            }
        }

        public void modificar(Marca marca) {
            if (string.IsNullOrWhiteSpace(marca.Descripcion))
                throw new Exception("El nombre de la marca no puede quedar vacio.");
            
            if (marca.Descripcion.Length > 50)
                throw new Exception("El nombre de la marca no puede superar los 50 caracteres.");

            AccesoDatos datos = new AccesoDatos();
            try
            {
             
                datos.setearConsultas("UPDATE MARCAS SET Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Descripcion", marca.Descripcion);
                datos.setearParametro("@Id", marca.Id);
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
          
            AccesoDatos datosVerificacion = new AccesoDatos();
            try
            {
                datosVerificacion.setearConsultas("SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @IdMarca");
                datosVerificacion.setearParametro("@IdMarca", id);
                datosVerificacion.ejecutarLectura();
                
                if (datosVerificacion.Lector.Read())
                {
                    int cantidad = (int)datosVerificacion.Lector[0];
                    if (cantidad > 0)
                    {
                        throw new Exception("No se puede eliminar esta marca porque está asociada a uno o más artículos.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosVerificacion.cerrarConexion();
            }

         
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsultas("DELETE FROM MARCAS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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
    }
}