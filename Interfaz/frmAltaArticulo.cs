using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPWinForm_equipo_A.UI
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargo los combos con lo que ya existe en la bd, asi el usuario elige 
                MarcaNegocio negocioMarca = new MarcaNegocio();
                CategoriaNegocio negocioCategoria = new CategoriaNegocio();

                cmbMarca.DataSource = negocioMarca.listar();
                cmbCategoria.DataSource = negocioCategoria.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
                // Si la url esta vacia o rota cargo una imagen por defect
                pbxImagen.Load("https://product-list.sfo3.digitaloceanspaces.com/products/free-placeholder-image-generator/images/f4b83d56-b4f0-48fc-87fa-9a10b0dc4668.png");
            }
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            // Se carga cuando el usuario sale del campo, no mientras escribe
            cargarImagen(txtImagenUrl.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Precio = decimal.Parse(txtPrecio.Text);
            // Del combo saco el objeto completo seleccionado, no el texto
            nuevo.Marca = (Marca)cmbMarca.SelectedItem;
            nuevo.Categoria = (Categoria)cmbCategoria.SelectedItem;

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregar(nuevo);
                MessageBox.Show("Articulo guardado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
