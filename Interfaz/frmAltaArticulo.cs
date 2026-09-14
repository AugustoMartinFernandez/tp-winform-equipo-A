using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Negocio;
using Dominio;

namespace TPWinForm_equipo_A.UI
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        // Cuando toquemos modificar Articulo dejara de estar null, pasara a estar cargado con un Articulo       
        private OpenFileDialog archivo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            // Cargo los combos con lo que ya existe en la bd, asi el usuario elige 
            MarcaNegocio negocioMarca = new MarcaNegocio();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();

            try
            {
                cmbMarca.DataSource = negocioMarca.listar();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";

                cmbCategoria.DataSource = negocioCategoria.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cmbMarca.SelectedValue = articulo.Marca.Id;
                    cmbCategoria.SelectedValue = articulo.Categoria.Id;

                    // Cargamos la imagen existente al abrir la ventana de modificación
                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        txtImagenUrl.Text = articulo.Imagenes[0].ImagenUrl;
                        cargarImagen(txtImagenUrl.Text);
                    }
                }
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
            // Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if(articulo == null)
                articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                // Del combo saco el objeto completo seleccionado, no el texto
                articulo.Marca = (Marca)cmbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;

                // Capturamos la URL del TextBox y la guardamos en la lista de imágenes del articulo
                if (!string.IsNullOrWhiteSpace(txtImagenUrl.Text))
                {
                    if (articulo.Imagenes == null)
                        articulo.Imagenes = new List<Imagen>();

                    if (articulo.Imagenes.Count == 0)
                    {
                        Imagen nuevaImg = new Imagen();
                        nuevaImg.ImagenUrl = txtImagenUrl.Text;
                        articulo.Imagenes.Add(nuevaImg);
                    }
                    else
                    {
                        articulo.Imagenes[0].ImagenUrl = txtImagenUrl.Text;
                    }
                }

                if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado correctamente.");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo guardado correctamente.");
                }
                // Guardo imagen si la levanto localmente
                if (archivo != null && !txtImagenUrl.Text.ToUpper().Contains("HTTP"))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["articulos-imagenes"] + "\\" + archivo.SafeFileName);
                }

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagenUrl.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }
    }
}
