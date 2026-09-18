namespace TPWinForm_equipo_A.UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblContadorArticulos = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnGestionCategoria = new System.Windows.Forms.Button();
            this.btnGestionMarca = new System.Windows.Forms.Button();
            this.btnEliminacionFisicaArticulo = new System.Windows.Forms.Button();
            this.lblArticulos = new System.Windows.Forms.Label();
            this.btnModificarArticulo = new System.Windows.Forms.Button();
            this.btnNuevoArticulo = new System.Windows.Forms.Button();
            this.pnlImagen = new System.Windows.Forms.Panel();
            this.lblContadorImagen = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.pnlCentro = new System.Windows.Forms.Panel();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBotones.Controls.Add(this.button1);
            this.pnlBotones.Controls.Add(this.pbxLogo);
            this.pnlBotones.Controls.Add(this.lblContadorArticulos);
            this.pnlBotones.Controls.Add(this.txtFiltro);
            this.pnlBotones.Controls.Add(this.lblFiltro);
            this.pnlBotones.Controls.Add(this.btnGestionCategoria);
            this.pnlBotones.Controls.Add(this.btnGestionMarca);
            this.pnlBotones.Controls.Add(this.btnEliminacionFisicaArticulo);
            this.pnlBotones.Controls.Add(this.lblArticulos);
            this.pnlBotones.Controls.Add(this.btnModificarArticulo);
            this.pnlBotones.Controls.Add(this.btnNuevoArticulo);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(331, 768);
            this.pnlBotones.TabIndex = 3;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxLogo.Image = global::TPWinForm_equipo_A.UI.Properties.Resources.logo;
            this.pbxLogo.Location = new System.Drawing.Point(0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(331, 333);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 16;
            this.pbxLogo.TabStop = false;
            // 
            // lblContadorArticulos
            // 
            this.lblContadorArticulos.AutoSize = true;
            this.lblContadorArticulos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblContadorArticulos.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorArticulos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblContadorArticulos.Location = new System.Drawing.Point(286, 336);
            this.lblContadorArticulos.Name = "lblContadorArticulos";
            this.lblContadorArticulos.Size = new System.Drawing.Size(30, 31);
            this.lblContadorArticulos.TabIndex = 15;
            this.lblContadorArticulos.Text = "0";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFiltro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(12, 412);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(313, 23);
            this.txtFiltro.TabIndex = 14;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblFiltro.Location = new System.Drawing.Point(7, 382);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(103, 27);
            this.lblFiltro.TabIndex = 13;
            this.lblFiltro.Text = "Buscar:";
            // 
            // btnGestionCategoria
            // 
            this.btnGestionCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionCategoria.BackColor = System.Drawing.Color.DimGray;
            this.btnGestionCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionCategoria.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGestionCategoria.Location = new System.Drawing.Point(6, 696);
            this.btnGestionCategoria.Name = "btnGestionCategoria";
            this.btnGestionCategoria.Size = new System.Drawing.Size(319, 47);
            this.btnGestionCategoria.TabIndex = 11;
            this.btnGestionCategoria.Text = "Gestión de Categorías";
            this.btnGestionCategoria.UseVisualStyleBackColor = false;
            this.btnGestionCategoria.Click += new System.EventHandler(this.btnGestionCategoria_Click);
            // 
            // btnGestionMarca
            // 
            this.btnGestionMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionMarca.BackColor = System.Drawing.Color.White;
            this.btnGestionMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionMarca.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionMarca.Location = new System.Drawing.Point(6, 645);
            this.btnGestionMarca.Name = "btnGestionMarca";
            this.btnGestionMarca.Size = new System.Drawing.Size(319, 45);
            this.btnGestionMarca.TabIndex = 10;
            this.btnGestionMarca.Text = "Gestión de Marcas";
            this.btnGestionMarca.UseVisualStyleBackColor = false;
            this.btnGestionMarca.Click += new System.EventHandler(this.btnGestionMarca_Click);
            // 
            // btnEliminacionFisicaArticulo
            // 
            this.btnEliminacionFisicaArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminacionFisicaArticulo.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminacionFisicaArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminacionFisicaArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminacionFisicaArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminacionFisicaArticulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminacionFisicaArticulo.Location = new System.Drawing.Point(6, 589);
            this.btnEliminacionFisicaArticulo.Name = "btnEliminacionFisicaArticulo";
            this.btnEliminacionFisicaArticulo.Size = new System.Drawing.Size(319, 45);
            this.btnEliminacionFisicaArticulo.TabIndex = 9;
            this.btnEliminacionFisicaArticulo.Text = "Eliminar Articulo";
            this.btnEliminacionFisicaArticulo.UseVisualStyleBackColor = false;
            this.btnEliminacionFisicaArticulo.Click += new System.EventHandler(this.btnEliminacionFisicaArticulo_Click);
            // 
            // lblArticulos
            // 
            this.lblArticulos.AutoSize = true;
            this.lblArticulos.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulos.ForeColor = System.Drawing.Color.Aqua;
            this.lblArticulos.Location = new System.Drawing.Point(6, 336);
            this.lblArticulos.Name = "lblArticulos";
            this.lblArticulos.Size = new System.Drawing.Size(287, 31);
            this.lblArticulos.TabIndex = 12;
            this.lblArticulos.Text = "Todos los Articulos:";
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarArticulo.BackColor = System.Drawing.Color.Gold;
            this.btnModificarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarArticulo.Location = new System.Drawing.Point(6, 534);
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.Size = new System.Drawing.Size(319, 49);
            this.btnModificarArticulo.TabIndex = 8;
            this.btnModificarArticulo.Text = "Modificar Articulo";
            this.btnModificarArticulo.UseVisualStyleBackColor = false;
            this.btnModificarArticulo.Click += new System.EventHandler(this.btnModificarArticulo_Click);
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoArticulo.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnNuevoArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoArticulo.Location = new System.Drawing.Point(6, 478);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.Size = new System.Drawing.Size(319, 50);
            this.btnNuevoArticulo.TabIndex = 3;
            this.btnNuevoArticulo.Text = "Nuevo Articulo";
            this.btnNuevoArticulo.UseVisualStyleBackColor = false;
            this.btnNuevoArticulo.Click += new System.EventHandler(this.btnNuevoArticulo_Click);
            // 
            // pnlImagen
            // 
            this.pnlImagen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlImagen.Controls.Add(this.lblContadorImagen);
            this.pnlImagen.Controls.Add(this.btnSiguiente);
            this.pnlImagen.Controls.Add(this.btnAnterior);
            this.pnlImagen.Controls.Add(this.pbxArticulo);
            this.pnlImagen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImagen.Location = new System.Drawing.Point(1252, 0);
            this.pnlImagen.Name = "pnlImagen";
            this.pnlImagen.Size = new System.Drawing.Size(334, 768);
            this.pnlImagen.TabIndex = 4;
            // 
            // lblContadorImagen
            // 
            this.lblContadorImagen.AutoSize = true;
            this.lblContadorImagen.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorImagen.Location = new System.Drawing.Point(150, 407);
            this.lblContadorImagen.Name = "lblContadorImagen";
            this.lblContadorImagen.Size = new System.Drawing.Size(40, 24);
            this.lblContadorImagen.TabIndex = 10;
            this.lblContadorImagen.Text = "1/1";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(231, 398);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(91, 33);
            this.btnSiguiente.TabIndex = 9;
            this.btnSiguiente.Text = "-->";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(7, 398);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(91, 33);
            this.btnAnterior.TabIndex = 8;
            this.btnAnterior.Text = "<--";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(7, 3);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(315, 389);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 7;
            this.pbxArticulo.TabStop = false;
            // 
            // pnlCentro
            // 
            this.pnlCentro.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlCentro.Controls.Add(this.dgvArticulos);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(331, 0);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(921, 768);
            this.pnlCentro.TabIndex = 5;
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvArticulos.GridColor = System.Drawing.Color.Fuchsia;
            this.dgvArticulos.Location = new System.Drawing.Point(0, 0);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.Size = new System.Drawing.Size(921, 768);
            this.dgvArticulos.TabIndex = 1;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Filtro Avanzado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1586, 768);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlImagen);
            this.Controls.Add(this.pnlBotones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1602, 807);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmprincipal_Load);
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlImagen.ResumeLayout(false);
            this.pnlImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.pnlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlImagen;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.Button btnNuevoArticulo;
        private System.Windows.Forms.Button btnModificarArticulo;
        private System.Windows.Forms.Button btnEliminacionFisicaArticulo;
        private System.Windows.Forms.Button btnGestionMarca;
        private System.Windows.Forms.Button btnGestionCategoria;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.Label lblContadorImagen;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Label lblContadorArticulos;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Button button1;
    }
}