namespace TCCKinect1._0.visao.relatorio
{
    partial class FormRelatorioGrafico
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
            this.gbSelSessao = new System.Windows.Forms.GroupBox();
            this.cbSessao = new System.Windows.Forms.ComboBox();
            this.lbSessao = new System.Windows.Forms.Label();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.lbPaciente = new System.Windows.Forms.Label();
            this.gbSelJuntas = new System.Windows.Forms.GroupBox();
            this.chListJuntas = new System.Windows.Forms.CheckedListBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.gbSelSessao.SuspendLayout();
            this.gbSelJuntas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelSessao
            // 
            this.gbSelSessao.Controls.Add(this.cbSessao);
            this.gbSelSessao.Controls.Add(this.lbSessao);
            this.gbSelSessao.Controls.Add(this.cbPaciente);
            this.gbSelSessao.Controls.Add(this.lbPaciente);
            this.gbSelSessao.Location = new System.Drawing.Point(13, 13);
            this.gbSelSessao.Name = "gbSelSessao";
            this.gbSelSessao.Size = new System.Drawing.Size(463, 85);
            this.gbSelSessao.TabIndex = 0;
            this.gbSelSessao.TabStop = false;
            this.gbSelSessao.Text = "Selecionando sessão:";
            // 
            // cbSessao
            // 
            this.cbSessao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSessao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSessao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSessao.FormattingEnabled = true;
            this.cbSessao.Location = new System.Drawing.Point(64, 46);
            this.cbSessao.Name = "cbSessao";
            this.cbSessao.Size = new System.Drawing.Size(393, 21);
            this.cbSessao.TabIndex = 3;
            // 
            // lbSessao
            // 
            this.lbSessao.AutoSize = true;
            this.lbSessao.Location = new System.Drawing.Point(6, 49);
            this.lbSessao.Name = "lbSessao";
            this.lbSessao.Size = new System.Drawing.Size(45, 13);
            this.lbSessao.TabIndex = 2;
            this.lbSessao.Text = "Sessão:";
            // 
            // cbPaciente
            // 
            this.cbPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.FormattingEnabled = true;
            this.cbPaciente.Location = new System.Drawing.Point(64, 19);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(393, 21);
            this.cbPaciente.TabIndex = 1;
            this.cbPaciente.DropDownClosed += new System.EventHandler(this.cbPaciente_DropDownClosed);
            // 
            // lbPaciente
            // 
            this.lbPaciente.AutoSize = true;
            this.lbPaciente.Location = new System.Drawing.Point(6, 22);
            this.lbPaciente.Name = "lbPaciente";
            this.lbPaciente.Size = new System.Drawing.Size(52, 13);
            this.lbPaciente.TabIndex = 0;
            this.lbPaciente.Text = "Paciente:";
            // 
            // gbSelJuntas
            // 
            this.gbSelJuntas.Controls.Add(this.chListJuntas);
            this.gbSelJuntas.Location = new System.Drawing.Point(13, 105);
            this.gbSelJuntas.Name = "gbSelJuntas";
            this.gbSelJuntas.Size = new System.Drawing.Size(463, 222);
            this.gbSelJuntas.TabIndex = 1;
            this.gbSelJuntas.TabStop = false;
            this.gbSelJuntas.Text = "Selecionando membros:";
            // 
            // chListJuntas
            // 
            this.chListJuntas.CheckOnClick = true;
            this.chListJuntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chListJuntas.Items.AddRange(new object[] {
            "Cabeça",
            "Ombro centro",
            "Ombro direito",
            "Cotovelo direito",
            "Pulso direito",
            "Mão direita",
            "Ombro esquerdo",
            "Cotovelo esquerdo",
            "Pulso esquerdo",
            "Mão esquerda",
            "Coluna",
            "Quadril centro",
            "Quadril direito",
            "Joelho direito",
            "Tornozelo direito",
            "Pé direito",
            "Quadril esquerdo",
            "Joelho esquerdo",
            "Tornozelo esquerdo",
            "Pé esquerdo"});
            this.chListJuntas.Location = new System.Drawing.Point(3, 16);
            this.chListJuntas.MultiColumn = true;
            this.chListJuntas.Name = "chListJuntas";
            this.chListJuntas.Size = new System.Drawing.Size(457, 203);
            this.chListJuntas.TabIndex = 0;
            this.chListJuntas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chListJuntas_ItemCheck);
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(401, 333);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 3;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // FormRelatorioGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 364);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.gbSelJuntas);
            this.Controls.Add(this.gbSelSessao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioGrafico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar relatório de sessões";
            this.gbSelSessao.ResumeLayout(false);
            this.gbSelSessao.PerformLayout();
            this.gbSelJuntas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelSessao;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.Label lbPaciente;
        private System.Windows.Forms.ComboBox cbSessao;
        private System.Windows.Forms.Label lbSessao;
        private System.Windows.Forms.GroupBox gbSelJuntas;
        private System.Windows.Forms.CheckedListBox chListJuntas;
        private System.Windows.Forms.Button btnGerar;
    }
}