namespace TCCKinect1._0.visao.cadastrosBase
{
    partial class FormBase
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbPesquisar = new System.Windows.Forms.GroupBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbPesquisar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbPesquisar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 66);
            this.panel1.TabIndex = 0;
            // 
            // gbPesquisar
            // 
            this.gbPesquisar.Controls.Add(this.txtPesquisa);
            this.gbPesquisar.Controls.Add(this.cbFiltro);
            this.gbPesquisar.Location = new System.Drawing.Point(12, 8);
            this.gbPesquisar.Name = "gbPesquisar";
            this.gbPesquisar.Size = new System.Drawing.Size(791, 50);
            this.gbPesquisar.TabIndex = 0;
            this.gbPesquisar.TabStop = false;
            this.gbPesquisar.Text = "Pesquisa:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(217, 20);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(564, 20);
            this.txtPesquisa.TabIndex = 1;
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(6, 19);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(205, 21);
            this.cbFiltro.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgDados);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 378);
            this.panel2.TabIndex = 1;
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDados.ColumnHeadersHeight = 25;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDados.Location = new System.Drawing.Point(12, 0);
            this.dgDados.MultiSelect = false;
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgDados.RowHeadersWidth = 30;
            this.dgDados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgDados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDados.RowTemplate.Height = 25;
            this.dgDados.Size = new System.Drawing.Size(791, 326);
            this.dgDados.TabIndex = 2;
            this.dgDados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgDados_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExcluir);
            this.panel3.Controls.Add(this.btnVisualizar);
            this.panel3.Controls.Add(this.btnAlterar);
            this.panel3.Controls.Add(this.btnCadastrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 326);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 52);
            this.panel3.TabIndex = 0;
            // 
            // btnExcluir
            // 
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImageIndex = 1;
            this.btnExcluir.ImageList = this.imageList1;
            this.btnExcluir.Location = new System.Drawing.Point(372, 6);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(114, 34);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Consultar.png");
            this.imageList1.Images.SetKeyName(1, "Deletar.png");
            this.imageList1.Images.SetKeyName(2, "Fechar.png");
            this.imageList1.Images.SetKeyName(3, "Novo.png");
            this.imageList1.Images.SetKeyName(4, "Salvar.png");
            this.imageList1.Images.SetKeyName(5, "edit.png");
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVisualizar.ImageIndex = 0;
            this.btnVisualizar.ImageList = this.imageList1;
            this.btnVisualizar.Location = new System.Drawing.Point(252, 6);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(114, 34);
            this.btnVisualizar.TabIndex = 5;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.ImageIndex = 5;
            this.btnAlterar.ImageList = this.imageList1;
            this.btnAlterar.Location = new System.Drawing.Point(132, 6);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(114, 34);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.ImageIndex = 3;
            this.btnCadastrar.ImageList = this.imageList1;
            this.btnCadastrar.Location = new System.Drawing.Point(12, 6);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(114, 34);
            this.btnCadastrar.TabIndex = 3;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBase";
            this.panel1.ResumeLayout(false);
            this.gbPesquisar.ResumeLayout(false);
            this.gbPesquisar.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbPesquisar;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button btnVisualizar;
        public System.Windows.Forms.Button btnAlterar;
        public System.Windows.Forms.Button btnCadastrar;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.DataGridView dgDados;
        public System.Windows.Forms.ComboBox cbFiltro;
        public System.Windows.Forms.TextBox txtPesquisa;
    }
}