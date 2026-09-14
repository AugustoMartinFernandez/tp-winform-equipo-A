using Dominio;
using Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

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

            // evento

            dgvElementos.SelectionChanged += new EventHandler(dgvElementos_SelectionChanged);

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
        string textoNuevo = txtDescripcion.Text.Trim();

        if (string.IsNullOrWhiteSpace(textoNuevo))
        {
            MessageBox.Show("Por favor, ingresa el Nombre.");
            return;
        }

        if (tipoEntidad == "MARCA")
        {
            MarcaNegocio negocio = new MarcaNegocio();
            var lista = negocio.listar();

            // Validar si ya existe la marca (sin importar mayúsculas/minúsculas)
            if (lista.Any(x => x.Descripcion.Equals(textoNuevo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe una marca con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Marca nueva = new Marca();
            nueva.Descripcion = textoNuevo;
            negocio.agregar(nueva);
        }
        else
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            var lista = negocio.listar();

            // Validar si ya existe la categoría
            if (lista.Any(x => x.Descripcion.Equals(textoNuevo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria nueva = new Categoria();
            nueva.Descripcion = textoNuevo;
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
            string textoModificado = txtDescripcion.Text.Trim();
            if (string.IsNullOrWhiteSpace(textoModificado))
            {
                MessageBox.Show("Por favor, ingresa una descripción para modificar.");
                return;
            }

            if (tipoEntidad == "MARCA")
            {
                Marca seleccionado = (Marca)dgvElementos.CurrentRow.DataBoundItem;
                MarcaNegocio negocio = new MarcaNegocio();
                
                // Validar duplicados excluyendo al elemento que estamos editando
                var lista = negocio.listar();
                if (lista.Any(x => x.Id != seleccionado.Id && x.Descripcion.Equals(textoModificado, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe otra marca con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                seleccionado.Descripcion = textoModificado;
                negocio.modificar(seleccionado);
            }
            else
            {
                Categoria seleccionado = (Categoria)dgvElementos.CurrentRow.DataBoundItem;
                CategoriaNegocio negocio = new CategoriaNegocio();

                var lista = negocio.listar();
                if (lista.Any(x => x.Id != seleccionado.Id && x.Descripcion.Equals(textoModificado, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe otra categoría con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                seleccionado.Descripcion = textoModificado;
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
        private void dgvElementos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvElementos.CurrentRow != null)
            {
                if (tipoEntidad == "MARCA")
                {
                    Marca seleccionado = (Marca)dgvElementos.CurrentRow.DataBoundItem;
                    if (seleccionado != null)
                        txtDescripcion.Text = seleccionado.Descripcion;
                }
                else
                {
                    Categoria seleccionado = (Categoria)dgvElementos.CurrentRow.DataBoundItem;
                    if (seleccionado != null)
                        txtDescripcion.Text = seleccionado.Descripcion;
                }
            }
        }

       
    }
}