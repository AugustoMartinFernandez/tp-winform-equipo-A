namespace TPWinForm_equipo_A.UI
{
    partial class frmArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.lblArticulos = new System.Windows.Forms.Label();
            this.btnNuevoArticulo = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblContadorImagen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(13, 67);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.Size = new System.Drawing.Size(428, 208);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // lblArticulos
            // 
            this.lblArticulos.AutoSize = true;
            this.lblArticulos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulos.Location = new System.Drawing.Point(13, 13);
            this.lblArticulos.Name = "lblArticulos";
            this.lblArticulos.Size = new System.Drawing.Size(205, 24);
            this.lblArticulos.TabIndex = 1;
            this.lblArticulos.Text = "Todos los Articulos";
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.Location = new System.Drawing.Point(13, 281);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.Size = new System.Drawing.Size(101, 33);
            this.btnNuevoArticulo.TabIndex = 2;
            this.btnNuevoArticulo.Text = "Nuevo Articulo";
            this.btnNuevoArticulo.UseVisualStyleBackColor = true;
            this.btnNuevoArticulo.Click += new System.EventHandler(this.btnNuevoArticulo_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(566, 67);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(239, 208);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 3;
            this.pbxArticulo.TabStop = false;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(595, 290);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 4;
            this.btnAnterior.Text = "<--";
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(706, 290);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = "-->";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblContadorImagen
            // 
            this.lblContadorImagen.AutoSize = true;
            this.lblContadorImagen.Location = new System.Drawing.Point(676, 295);
            this.lblContadorImagen.Name = "lblContadorImagen";
            this.lblContadorImagen.Size = new System.Drawing.Size(24, 13);
            this.lblContadorImagen.TabIndex = 6;
            this.lblContadorImagen.Text = "1/1";
            this.lblContadorImagen.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 348);
            this.Controls.Add(this.lblContadorImagen);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnNuevoArticulo);
            this.Controls.Add(this.lblArticulos);
            this.Controls.Add(this.dgvArticulos);
            this.Name = "frmArticulos";
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.Button btnNuevoArticulo;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblContadorImagen;
    }
}

