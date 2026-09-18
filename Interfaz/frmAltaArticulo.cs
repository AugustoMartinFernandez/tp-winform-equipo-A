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
        // Cuando toquemos modificar Articulo dejara de estar null, pasara a estar cargado con un Articulo 
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        // Empieza en false porque al abrir la ventana todavia no hay imagen.
        private bool imagenCargoBien = false;
        // Guarda la ruta final de la imagen local ya copiada, para guardarla en la bd
        private string rutaImagenFinal = null;
        // Cada vez que el usuario agregue una URL, la vamos a sumar aca con .Add() Cada vez que elimine una la sacamos con .Remove() Y la grilla siempre muestra el contenido actual de esta lista.
        private List<Imagen> listaImagenes = new List<Imagen>();

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
                        // crea una copia nueva de la lista, no la misma referencia.
                        listaImagenes = new List<Imagen>(articulo.Imagenes);
                        actualizarGrillaImagenes();

                        // Muestro la primera como vista previa en el PictureBox
                        cargarImagen(listaImagenes[0].ImagenUrl);
                    }
                    else
                    {
                        // El articulo no tiene ninguna imagen cargada muestro el placeholder desde el arranque, en vez de dejar el PictureBox en blanco
                        cargarImagen("");
                    }
                }
                else
                {
                    // Alta nueva todavia no hay ninguna imagen, mostramos el placeholder desde el arranque.
                    cargarImagen("");
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
                imagenCargoBien = true; // La imagen se cargo correctamente
            }
            catch (Exception)
            {
                // Si la url esta vacia o rota cargo una imagen por defect
                pbxImagen.Load("https://product-list.sfo3.digitaloceanspaces.com/products/free-placeholder-image-generator/images/f4b83d56-b4f0-48fc-87fa-9a10b0dc4668.png");
                imagenCargoBien = false; // La imagen no se cargo correctamente, se muestra el placeholder
            }
        }
        private void actualizarGrillaImagenes()
        {
            dgvImagenes.DataSource = null;
            dgvImagenes.DataSource = new List<Imagen>(listaImagenes);
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            // / Si el usuario escribio/pego una URL a mano, ya no es imagen local reseteo la ruta de copia
            rutaImagenFinal = null;
            archivo = null;
            cargarImagen(txtImagenUrl.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                // Si hay algun error de validacion, validamos, cortamos y no se guarda nada
                if (hayErrores())
                    return;

                if(articulo == null)
                articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                // Del combo saco el objeto completo seleccionado, no el texto
                articulo.Marca = (Marca)cmbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;

                // Le paso al articulo la lista completa de imagenes que se armo en pantalla
                articulo.Imagenes = listaImagenes;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado correctamente.");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo guardado correctamente.");
                }
                // Copio a la carpeta local todas las imagenes que vinieron de un archivo
                foreach (Imagen img in listaImagenes)
                {
                    if (img.RutaOrigenLocal != null)
                    {
                        File.Copy(img.RutaOrigenLocal, img.ImagenUrl, true);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        // Validaciones
        private bool hayErrores()
        {
            // Codigo Vacio
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El campo codigo es obligatorio");
                return true;
            }
            if (txtCodigo.Text.Length < 4)
            {
                MessageBox.Show("El codigo tiene que tener al menos 4 caracteres");
                return true;
            }
            // Nombre Vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                return true;
            }
            // Descripcion Vacia
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo Descripcion es obligatorio.");
                return true;
            }
            // Precio Vacio
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("El campo Precio es obligatorio.");
                return true;
            }
            // Numero invalido
            decimal precioProbado;
            if(!decimal.TryParse(txtPrecio.Text, out precioProbado))
            {
                MessageBox.Show("El precio tiene que ser un numero valido");
                return true;
            }
            // Precio negativo o mayo a 0
            if (precioProbado <= 0)
            {
                MessageBox.Show("El precio tiene que ser mayor a cero.");
                return true;
            }
            // Marca sin seleccionada
            if (cmbMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Tenes que elegir una Marca");
                return true;
            }
            // Categoria sin seleccionar
            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Tenes que elegir una Categoria");
                return true;
            }
            // Imagen obligatoria y que haya cargado bien
            if (listaImagenes.Count == 0)
            {
                MessageBox.Show("Tenes que cargar una imagen (URL o archivo)");
                return true;
            }
            if (!imagenCargoBien)
            {
                MessageBox.Show("La imagen no se pudo cargar. Revisa la URL o elegi otra.");
                return true;
            }
            return false;
        }
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                // Armo un nombre unico para la imagen: codigo del articulo + un id unico corto + la extension original
                //  Asi dos imagenes distintas nunca se pisan, aunque el archivo original se llame igual
                string extension = Path.GetExtension(archivo.FileName);  // saca el ".jpg" de la ruta original
                string idUnico = Guid.NewGuid().ToString().Substring(0,8); // un codigo unico de 8 caracteres
                string nombreNuevo = txtCodigo.Text + "_" + idUnico + extension; // ej: AP01_a3f8e2d1.jpg

                // Armo la ruta destino completa (la carpeta de App.config + el nombre nuevo)
                rutaImagenFinal = ConfigurationManager.AppSettings["articulos-imagenes"] + "\\" + nombreNuevo;

                // Muestro la imagen en pantalla desde el origen (todavia no la copie)
                txtImagenUrl.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            // Si tiene 4 o mas caracteres, se pondra en verde si no en un rojo
            if (txtCodigo.Text.Length >= 4)
            {
                txtCodigo.BackColor = Color.FromArgb(200,255,200); // Verde
            }
            else
            {
                txtCodigo.BackColor = Color.FromArgb(255,200,200); // Rojo
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Si esta cerca del limite (mas de 45 de los 50 permitidos), aviso en amarillo
            if (txtNombre.Text.Length > 45)
            {
                txtNombre.BackColor = Color.FromArgb(255, 255, 180); // amarillo, cerca del limite
            }
            else
            {
                txtNombre.BackColor = Color.White; // normal
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSumarImagen_Click(object sender, EventArgs e)
        {
            // Si no hay nada escrito, no hay nada para agregar
            if (string.IsNullOrWhiteSpace(txtImagenUrl.Text))
            {
                MessageBox.Show("Escribi una URL o elegi un archivo antes de agregarla a la lista.");
                return;
            }
            // Imagen nueva decidiendo la misma URL/ruta que ya calculaba btnGuardar
            Imagen nuevaImg = new Imagen();
            if (rutaImagenFinal != null)
            {
                nuevaImg.ImagenUrl = rutaImagenFinal; // Local
                nuevaImg.RutaOrigenLocal = archivo.FileName;
            }
            else
            {
                nuevaImg.ImagenUrl = txtImagenUrl.Text; // Url
                nuevaImg.RutaOrigenLocal = null;
            }

            listaImagenes.Add(nuevaImg);
            actualizarGrillaImagenes();

            // Limpio los campos para que el usuario pueda cargar la siguiente imagen
            txtImagenUrl.Text = "";
            rutaImagenFinal = null;
            archivo = null;
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (dgvImagenes.CurrentRow != null)
            {
                Imagen imagenSeleccionada = (Imagen)dgvImagenes.CurrentRow.DataBoundItem;

                // Le muestro al usuario cual imagen especifica va a eliminar, no un mensaje generico
                DialogResult respuesta = MessageBox.Show(
                    "Se eliminara la imagen:\n" + imagenSeleccionada.ImagenUrl + "\n\n¿Estas seguro?",
                    "Eliminar imagen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    listaImagenes.Remove(imagenSeleccionada);
                    actualizarGrillaImagenes();
                }
            }
            else
            {
                MessageBox.Show("Seleccioná una imagen de la lista para eliminarla.");
            }
        }

        private void dgvImagenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImagenes.CurrentRow != null)
            {
                Imagen imagenSeleccionada = (Imagen)dgvImagenes.CurrentRow.DataBoundItem;

                // Si es local y todavia no se copio, la vista previa se hace desde el origen.
                // Si no tiene origen local (URL, o imagen ya guardada antes), se usa ImagenUrl.
                string rutaParaPreview = imagenSeleccionada.RutaOrigenLocal ?? imagenSeleccionada.ImagenUrl;
                cargarImagen(rutaParaPreview);
            }
        }
    }
}
