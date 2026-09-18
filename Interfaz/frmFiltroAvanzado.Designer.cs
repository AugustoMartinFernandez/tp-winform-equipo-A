namespace TPWinForm_equipo_A.UI
{
    partial class frmFiltroAvanzado
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
            this.comboBoxCampo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCriterio = new System.Windows.Forms.ComboBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dgvResultadoFiltro = new System.Windows.Forms.DataGridView();
            this.pictureBoxFiltro = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCampo
            // 
            this.comboBoxCampo.FormattingEnabled = true;
            this.comboBoxCampo.Location = new System.Drawing.Point(92, 54);
            this.comboBoxCampo.Name = "comboBoxCampo";
            this.comboBoxCampo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCampo.TabIndex = 0;
            this.comboBoxCampo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCampo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Campo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Criterio:";
            // 
            // comboBoxCriterio
            // 
            this.comboBoxCriterio.FormattingEnabled = true;
            this.comboBoxCriterio.Location = new System.Drawing.Point(92, 81);
            this.comboBoxCriterio.Name = "comboBoxCriterio";
            this.comboBoxCriterio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCriterio.TabIndex = 8;
            this.comboBoxCriterio.SelectedIndexChanged += new System.EventHandler(this.dgvResultadoFiltro_SelectionChanged);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(92, 108);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(121, 20);
            this.txtFiltroAvanzado.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filto Avanzado:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(92, 134);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 12;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvResultadoFiltro
            // 
            this.dgvResultadoFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadoFiltro.Location = new System.Drawing.Point(219, 54);
            this.dgvResultadoFiltro.Name = "dgvResultadoFiltro";
            this.dgvResultadoFiltro.Size = new System.Drawing.Size(452, 130);
            this.dgvResultadoFiltro.TabIndex = 13;
            // 
            // pictureBoxFiltro
            // 
            this.pictureBoxFiltro.Location = new System.Drawing.Point(692, 54);
            this.pictureBoxFiltro.Name = "pictureBoxFiltro";
            this.pictureBoxFiltro.Size = new System.Drawing.Size(153, 130);
            this.pictureBoxFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFiltro.TabIndex = 14;
            this.pictureBoxFiltro.TabStop = false;
            // 
            // frmFiltroAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 225);
            this.Controls.Add(this.pictureBoxFiltro);
            this.Controls.Add(this.dgvResultadoFiltro);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCriterio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCampo);
            this.Name = "frmFiltroAvanzado";
            this.Text = "frmFiltroAvanzado";
            this.Load += new System.EventHandler(this.frmFiltroAvanzado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiltro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCampo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCriterio;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dgvResultadoFiltro;
        private System.Windows.Forms.PictureBox pictureBoxFiltro;
    }
}