using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_A.UI
{
    public partial class frmPrincipal : Form
    {
        private int indiceImagenActual = 0;
        private List<Articulo> listaCompleta;
        public frmPrincipal()
        {
            InitializeComponent();

        }

        private void frmprincipal_Load(object sender, EventArgs e)
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
                lblContadorArticulos.Text = listaCompleta.Count.ToString();
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
            catch (Exception)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
        private void actualizarVisorImagen()
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                if (articuloSeleccionado.Imagenes != null && articuloSeleccionado.Imagenes.Count > 0)
                {
                    // Cargar imagen actual.
                    cargarImagen(articuloSeleccionado.Imagenes[indiceImagenActual].ImagenUrl);
                    // Actualizamos label.
                    lblContadorImagen.Text = (indiceImagenActual + 1).ToString() + " / " + articuloSeleccionado.Imagenes.Count.ToString();
                    // Logica botones
                    btnAnterior.Enabled = indiceImagenActual > 0;
                    btnSiguiente.Enabled = indiceImagenActual < articuloSeleccionado.Imagenes.Count - 1;
                }
                else
                {
                    // Si no hay imagen mostramos vacio y botones OFF.
                    cargarImagen("");
                    lblContadorImagen.Text = "0 / 0";
                    btnAnterior.Enabled = false;
                    btnSiguiente.Enabled = false;
                }
            }
        }
        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargarListado();
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

        private void btnGestionMarca_Click(object sender, EventArgs e)
        {
            // Verificamos si ya está abierta la ventana de Marcas
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmGestionMarcaCategoria)
                {
                    if (form.Text.Contains("Marcas"))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }

            // Si no está abierta, la creamos enviando "MARCA"
            frmGestionMarcaCategoria ventana = new frmGestionMarcaCategoria("MARCA");
            ventana.Show();
        }

        private void btnGestionCategoria_Click(object sender, EventArgs e)
        {
            // Verificamos si ya está abierta la ventana de Categorías
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmGestionMarcaCategoria)
                {
                    if (form.Text.Contains("Categorías"))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }

            // Si no está abierta, la creamos enviando "CATEGORIA"
            frmGestionMarcaCategoria ventana = new frmGestionMarcaCategoria("CATEGORIA");
            ventana.Show();
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
            lblContadorArticulos.Text = listaFiltrada.Count.ToString();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                indiceImagenActual = 0; // Se vuelve a la primer imagen al cambiar de Articulo.
                actualizarVisorImagen();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indiceImagenActual--;
            actualizarVisorImagen();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceImagenActual++;
            actualizarVisorImagen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFiltroAvanzado filtro = new frmFiltroAvanzado();
            filtro.ShowDialog();
            cargarListado(); // Para que se refresque al volver
        }
    }
}
