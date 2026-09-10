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
            // Verificacion de ventana abierta.
            foreach (var form in Application.OpenForms)
            {
                if (form is frmArticulos)
                {
                    ((Form)form).BringToFront(); // Si esta abierta, la traemos al frente.
                    return;
                }
            }
            // Caso contrario la creamos y la abrimos.
            frmArticulos ventana = new frmArticulos();
            ventana.MdiParent = this;
            ventana.Show();

        }
    }
}
