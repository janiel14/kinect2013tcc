namespace TCCKinect1._0.visao
{
    partial class FormFisioterapeuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFisioterapeuta));
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
            // btnCadastrar
            // 
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // FormFisioterapeuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(820, 444);
            this.Name = "FormFisioterapeuta";
            this.Text = "Fisioterapeuta";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
