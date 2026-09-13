using System;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_A.UI
{
    public partial class frmGestionMarcaCategoria : Form
    {
        private string tipoEntidad; // Recibirá "MARCA" o "CATEGORIA"

        public frmGestionMarcaCategoria()
    {
        InitializeComponent();
    }

        public frmGestionMarcaCategoria(string tipo)
        {
            InitializeComponent();
            tipoEntidad = tipo;

            // Asignamos el título según corresponda
            if (tipoEntidad == "MARCA")
            {
                Text = "Gestión de Marcas";
            }
            else
            {
                Text = "Gestión de Categorías";
            }

            // Cargamos la grilla apenas se crea la ventana
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                if (tipoEntidad == "MARCA")
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    dgvElementos.DataSource = negocio.listar();
                }
                else
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    dgvElementos.DataSource = negocio.listar();
                }

                if (dgvElementos.Columns["Descripcion"] != null)
        {
            dgvElementos.Columns["Descripcion"].HeaderText = "Nombre";
        }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, ingresa el Nombre.");
                    return;
                }

                if (tipoEntidad == "MARCA")
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca nueva = new Marca();
                    nueva.Descripcion = txtDescripcion.Text;
                    negocio.agregar(nueva);
                }
                else
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtDescripcion.Text;
                    negocio.agregar(nueva);
                }

                MessageBox.Show("Agregado exitosamente.");
                txtDescripcion.Clear();
                cargarGrilla(); // Recargamos la grilla para ver el cambio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvElementos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Seguro querés eliminar este elemento?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (tipoEntidad == "MARCA")
                        {
                            Marca seleccionado = (Marca)dgvElementos.CurrentRow.DataBoundItem;
                            MarcaNegocio negocio = new MarcaNegocio();
                            negocio.eliminar(seleccionado.Id);
                        }
                        else
                        {
                            Categoria seleccionado = (Categoria)dgvElementos.CurrentRow.DataBoundItem;
                            CategoriaNegocio negocio = new CategoriaNegocio();
                            negocio.eliminar(seleccionado.Id);
                        }
                        
                        cargarGrilla(); // Recargamos la grilla
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un elemento de la lista.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar porque está asociado a un artículo existente o ocurrió un error: " + ex.Message);
            }
        }

       private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvElementos.CurrentRow != null)
                {
                    if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    {
                        MessageBox.Show("Por favor, ingresa una descripción para modificar.");
                        return;
                    }

                    if (tipoEntidad == "MARCA")
                    {
                        Marca seleccionado = (Marca)dgvElementos.CurrentRow.DataBoundItem;
                        seleccionado.Descripcion = txtDescripcion.Text;

                        MarcaNegocio negocio = new MarcaNegocio();
                        negocio.modificar(seleccionado);
                    }
                    else
                    {
                        Categoria seleccionado = (Categoria)dgvElementos.CurrentRow.DataBoundItem;
                        seleccionado.Descripcion = txtDescripcion.Text;

                        CategoriaNegocio negocio = new CategoriaNegocio();
                        negocio.modificar(seleccionado);
                    }

                    MessageBox.Show("Modificado exitosamente.");
                    txtDescripcion.Clear();
                    cargarGrilla();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un elemento de la lista para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}