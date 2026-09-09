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

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            // ShowDialog para que sea modal, no deja tocar el listado hasta que se cierre el alta
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            // Al volver del alta, refresco para que se vea el articulo nuevo
            cargarListado();
        }
    }
}
