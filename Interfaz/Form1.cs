using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio; 
using Negocio; 

namespace TPWinForm_equipo_A.UI
{
    public partial class frmArticulos : Form
    {
        private int indiceImagenActual = 0;
        private List<Articulo> listaCompleta;

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void cargarListado()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //ocultarColumnas();

            try
            {
                listaCompleta = negocio.listar();
                dgvArticulos.DataSource = listaCompleta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string Imagen)
        {
            try
            {
                pbxArticulo.Load(Imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
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

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            frmAltaArticulo modificar;
            
            if (dgvArticulos.CurrentRow != null)
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                modificar = new frmAltaArticulo(seleccionado);
                modificar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para modificar un articulo, primero debe seleccionarlo");
            }

            cargarListado();
        }

        private void btnEliminacionFisicaArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("De verdad queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)(dgvArticulos.CurrentRow.DataBoundItem);
                        negocio.eliminar(seleccionado.Id);
                        MessageBox.Show($"{seleccionado.Nombre}, eliminado correctamente");
                        cargarListado();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un articulo, primero debe seleccionarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 3)
            {
                listaFiltrada = listaCompleta.FindAll(art => art.Nombre.ToLower().Contains(filtro.ToLower()) || art.Descripcion.ToLower().Contains(filtro.ToLower()) || art.Marca.Descripcion.ToLower().Contains(filtro.ToLower()) || art.Categoria.Descripcion.ToLower().Contains(filtro.ToLower()) || art.Codigo.ToLower().Contains(filtro.ToLower()));
            }
            else
            {
                listaFiltrada = listaCompleta;
            }
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
        }
    }
}