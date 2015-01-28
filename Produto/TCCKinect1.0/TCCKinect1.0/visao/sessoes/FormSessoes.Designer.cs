namespace TCCKinect1._0.visao.sessoes
{
    partial class FormSessoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSessoes));
            System.Windows.Forms.Button btnLiberarSessão;
            btnLiberarSessão = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "Consultar.png");
            this.imageList1.Images.SetKeyName(1, "Deletar.png");
            this.imageList1.Images.SetKeyName(2, "Fechar.png");
            this.imageList1.Images.SetKeyName(3, "Novo.png");
            this.imageList1.Images.SetKeyName(4, "Salvar.png");
            this.imageList1.Images.SetKeyName(5, "edit.png");
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Image")));
            this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualizar.ImageIndex = -1;
            this.btnVisualizar.ImageList = null;
            this.btnVisualizar.Text = "   Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // cbFiltro
            // 
            this.cbFiltro.Items.AddRange(new object[] {
            "Fisioterapeuta",
            "Paciente",
            "Situação"});
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisa_KeyPress);
            // 
            // btnLiberarSessão
            // 
            btnLiberarSessão.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberarSessão.Image")));
            btnLiberarSessão.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLiberarSessão.Location = new System.Drawing.Point(492, 398);
            btnLiberarSessão.Name = "btnLiberarSessão";
            btnLiberarSessão.Size = new System.Drawing.Size(114, 34);
            btnLiberarSessão.TabIndex = 2;
            btnLiberarSessão.Text = "     Liberar Sessão";
            btnLiberarSessão.UseVisualStyleBackColor = true;
            btnLiberarSessão.Click += new System.EventHandler(this.btnLiberarSessão_Click);
            // 
            // FormSessoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(813, 444);
            this.Controls.Add(btnLiberarSessão);
            this.Name = "FormSessoes";
            this.Text = "Sessões";
            this.Enter += new System.EventHandler(this.FormSessoes_Enter);
            this.Controls.SetChildIndex(btnLiberarSessão, 0);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
