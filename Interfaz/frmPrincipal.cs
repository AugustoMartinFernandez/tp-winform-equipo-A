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
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {

        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in Application.OpenForms)
            {
                if (form is frmArticulos)
                {
                    ((Form)form).BringToFront();
                    return;
                }
            }
            frmArticulos ventana = new frmArticulos();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
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
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
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
            ventana.MdiParent = this;
            ventana.Show();
        }
    }
}