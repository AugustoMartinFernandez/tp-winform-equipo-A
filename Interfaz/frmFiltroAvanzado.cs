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
    public partial class frmFiltroAvanzado : Form
    {
        public frmFiltroAvanzado()
        {
            InitializeComponent();
        }

        private void frmFiltroAvanzado_Load(object sender, EventArgs e)
        {
            comboBoxCampo.Items.Clear();
            comboBoxCampo.Items.Add("Código");
            comboBoxCampo.Items.Add("Nombre");
            comboBoxCampo.Items.Add("Descripción");
            comboBoxCampo.Items.Add("Precio");
            comboBoxCampo.Items.Add("Marca");
            comboBoxCampo.Items.Add("Categoría");
            comboBoxCampo.SelectedIndex = 0;

            dgvResultadoFiltro.SelectionChanged += dgvResultadoFiltro_SelectionChanged;
        }

        private void comboBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCampo.SelectedItem == null) return;

            string opcion = comboBoxCampo.SelectedItem.ToString();
            comboBoxCriterio.Items.Clear();

            if (opcion == "Precio")
            {
                comboBoxCriterio.Items.Add("Mayor a");
                comboBoxCriterio.Items.Add("Menor a");
                comboBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                comboBoxCriterio.Items.Add("Comienza con");
                comboBoxCriterio.Items.Add("Termina con");
                comboBoxCriterio.Items.Add("Contiene");
            }
            
            if (comboBoxCriterio.Items.Count > 0)
                comboBoxCriterio.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (comboBoxCampo.SelectedIndex < 0 || comboBoxCriterio.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor, seleccione un campo y un criterio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string campo = comboBoxCampo.SelectedItem.ToString();
                string criterio = comboBoxCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text.Trim();

                if (campo == "Precio")
                {
                    if (string.IsNullOrWhiteSpace(filtro) || !decimal.TryParse(filtro, out _))
                    {
                        MessageBox.Show("Para filtrar por precio debe ingresar un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                List<Articulo> listaFiltrada = negocio.filtrar(campo, criterio, filtro);
                dgvResultadoFiltro.DataSource = listaFiltrada;
                
                // Orden de columnas secuencial solicitado
                if (dgvResultadoFiltro.Columns["Codigo"] != null)
                    dgvResultadoFiltro.Columns["Codigo"].DisplayIndex = 0;
                if (dgvResultadoFiltro.Columns["Nombre"] != null)
                    dgvResultadoFiltro.Columns["Nombre"].DisplayIndex = 1;
                if (dgvResultadoFiltro.Columns["Descripcion"] != null)
                    dgvResultadoFiltro.Columns["Descripcion"].DisplayIndex = 2;
                if (dgvResultadoFiltro.Columns["Precio"] != null)
                    dgvResultadoFiltro.Columns["Precio"].DisplayIndex = 3;
                if (dgvResultadoFiltro.Columns["Marca"] != null)
                    dgvResultadoFiltro.Columns["Marca"].DisplayIndex = 4;
                if (dgvResultadoFiltro.Columns["Categoria"] != null)
                    dgvResultadoFiltro.Columns["Categoria"].DisplayIndex = 5;

                // Ocultamos columnas innecesarias
                if (dgvResultadoFiltro.Columns["Id"] != null)
                    dgvResultadoFiltro.Columns["Id"].Visible = false;
                if (dgvResultadoFiltro.Columns["UrlImagen"] != null)
                    dgvResultadoFiltro.Columns["UrlImagen"].Visible = false;
                if (dgvResultadoFiltro.Columns["Imagenes"] != null)
                    dgvResultadoFiltro.Columns["Imagenes"].Visible = false;

                // Extraemos la URL usando la propiedad correcta .ImagenUrl
                string urlPrimerImagen = null;
                if (listaFiltrada.Count > 0 && listaFiltrada[0].Imagenes != null && listaFiltrada[0].Imagenes.Count > 0)
                {
                    urlPrimerImagen = listaFiltrada[0].Imagenes[0].ImagenUrl;
                }

                cargarImagen(urlPrimerImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.ToString());
            }
        }

        private void dgvResultadoFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultadoFiltro.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvResultadoFiltro.CurrentRow.DataBoundItem;
                
                string urlImagenSeleccionada = null;
                if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
                {
                    urlImagenSeleccionada = seleccionado.Imagenes[0].ImagenUrl;
                }

                cargarImagen(urlImagenSeleccionada);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                if (pictureBoxFiltro != null)
                {
                    if (!string.IsNullOrEmpty(imagen))
                    {
                        pictureBoxFiltro.Load(imagen);
                    }
                    else
                    {
                        pictureBoxFiltro.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg");
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    pictureBoxFiltro.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg");
                }
                catch
                {
                    pictureBoxFiltro.Image = null; 
                }
            }
        } 
    }
}