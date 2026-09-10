using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dominio; // <--- Agrego para poder usar la clase Articulo
using Negocio; // <--- Agrego para poder usar la clase ArticuloNegocio

namespace TPWinForm_equipo_A.UI
{
    public partial class frmArticulos : Form
    {
        private int indiceImagenActual = 0;

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargarListado();
        }
        // Separado en un metodo aparte para poder llamarlo de nuevo despues de cerrar el alta
        private void cargarListado()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                dgvArticulos.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void cargarImagen(string Imagen)
        {
            try
            {
                pbxArticulo.Load(Imagen);
            }
            catch (Exception ex)
            {
                // Placeholder
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            // ShowDialog para que sea modal, no deja tocar el listado hasta que se cierre el alta
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            // Al volver del alta, refresco para que se vea el articulo nuevo
            cargarListado();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                indiceImagenActual = 0;

                if (articuloSeleccionado.Imagenes != null && articuloSeleccionado.Imagenes.Count > 0)
                {
                    cargarImagen(articuloSeleccionado.Imagenes[indiceImagenActual].ImagenUrl);

                    lblContadorImagen.Text = "1 / " + articuloSeleccionado.Imagenes.Count.ToString();
                }
                else
                {
                    cargarImagen("");
                    lblContadorImagen.Text = "0 / 0";
                }
            }
        }
    }
}
