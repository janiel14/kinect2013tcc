namespace TCCKinect1._0.visao.sessoes
{
    partial class FormSessaoCadastrar
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
            this.gbInformacoes = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkPaciente = new System.Windows.Forms.LinkLabel();
            this.linkLblClinica = new System.Windows.Forms.LinkLabel();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.cbFisioterapeuta = new System.Windows.Forms.ComboBox();
            this.cbClinica = new System.Windows.Forms.ComboBox();
            this.gbDataHora = new System.Windows.Forms.GroupBox();
            this.mtxtHora = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxtData = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txaObservacao = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbInformacoes.SuspendLayout();
            this.gbDataHora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.linkLabel2);
            this.gbInformacoes.Controls.Add(this.linkPaciente);
            this.gbInformacoes.Controls.Add(this.linkLblClinica);
            this.gbInformacoes.Controls.Add(this.cbPaciente);
            this.gbInformacoes.Controls.Add(this.cbFisioterapeuta);
            this.gbInformacoes.Controls.Add(this.cbClinica);
            this.gbInformacoes.Location = new System.Drawing.Point(13, 75);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(451, 113);
            this.gbInformacoes.TabIndex = 1;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(6, 53);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(76, 13);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Fisioterapeuta:";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkPaciente
            // 
            this.linkPaciente.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkPaciente.AutoSize = true;
            this.linkPaciente.LinkColor = System.Drawing.Color.Black;
            this.linkPaciente.Location = new System.Drawing.Point(6, 80);
            this.linkPaciente.Name = "linkPaciente";
            this.linkPaciente.Size = new System.Drawing.Size(52, 13);
            this.linkPaciente.TabIndex = 3;
            this.linkPaciente.TabStop = true;
            this.linkPaciente.Text = "Paciente:";
            this.linkPaciente.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkPaciente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPaciente_LinkClicked);
            // 
            // linkLblClinica
            // 
            this.linkLblClinica.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLblClinica.AutoSize = true;
            this.linkLblClinica.LinkColor = System.Drawing.Color.Black;
            this.linkLblClinica.Location = new System.Drawing.Point(6, 26);
            this.linkLblClinica.Name = "linkLblClinica";
            this.linkLblClinica.Size = new System.Drawing.Size(43, 13);
            this.linkLblClinica.TabIndex = 3;
            this.linkLblClinica.TabStop = true;
            this.linkLblClinica.Text = "Clínica:";
            this.linkLblClinica.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblClinica_LinkClicked);
            // 
            // cbPaciente
            // 
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.FormattingEnabled = true;
            this.cbPaciente.Location = new System.Drawing.Point(87, 77);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(333, 21);
            this.cbPaciente.TabIndex = 5;
            // 
            // cbFisioterapeuta
            // 
            this.cbFisioterapeuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFisioterapeuta.FormattingEnabled = true;
            this.cbFisioterapeuta.Location = new System.Drawing.Point(87, 50);
            this.cbFisioterapeuta.Name = "cbFisioterapeuta";
            this.cbFisioterapeuta.Size = new System.Drawing.Size(333, 21);
            this.cbFisioterapeuta.TabIndex = 4;
            // 
            // cbClinica
            // 
            this.cbClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClinica.FormattingEnabled = true;
            this.cbClinica.Location = new System.Drawing.Point(87, 23);
            this.cbClinica.Name = "cbClinica";
            this.cbClinica.Size = new System.Drawing.Size(333, 21);
            this.cbClinica.TabIndex = 3;
            // 
            // gbDataHora
            // 
            this.gbDataHora.Controls.Add(this.mtxtHora);
            this.gbDataHora.Controls.Add(this.label5);
            this.gbDataHora.Controls.Add(this.mtxtData);
            this.gbDataHora.Controls.Add(this.label4);
            this.gbDataHora.Location = new System.Drawing.Point(12, 12);
            this.gbDataHora.Name = "gbDataHora";
            this.gbDataHora.Size = new System.Drawing.Size(452, 57);
            this.gbDataHora.TabIndex = 0;
            this.gbDataHora.TabStop = false;
            this.gbDataHora.Text = "Data e hora:";
            // 
            // mtxtHora
            // 
            this.mtxtHora.Location = new System.Drawing.Point(361, 23);
            this.mtxtHora.Mask = "00:00";
            this.mtxtHora.Name = "mtxtHora";
            this.mtxtHora.PromptChar = ' ';
            this.mtxtHora.Size = new System.Drawing.Size(60, 20);
            this.mtxtHora.TabIndex = 2;
            this.mtxtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHora.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hora:";
            // 
            // mtxtData
            // 
            this.mtxtData.Location = new System.Drawing.Point(87, 23);
            this.mtxtData.Mask = "00/00/0000";
            this.mtxtData.Name = "mtxtData";
            this.mtxtData.PromptChar = ' ';
            this.mtxtData.Size = new System.Drawing.Size(89, 20);
            this.mtxtData.TabIndex = 1;
            this.mtxtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtData.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data:";
            // 
            // txaObservacao
            // 
            this.txaObservacao.Location = new System.Drawing.Point(12, 210);
            this.txaObservacao.Name = "txaObservacao";
            this.txaObservacao.Size = new System.Drawing.Size(452, 58);
            this.txaObservacao.TabIndex = 6;
            this.txaObservacao.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Observação:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::TCCKinect1._0.Properties.Resources.Fechar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(362, 275);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 32);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "      Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::TCCKinect1._0.Properties.Resources.Salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(254, 275);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 32);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSessaoCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 319);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txaObservacao);
            this.Controls.Add(this.gbDataHora);
            this.Controls.Add(this.gbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSessaoCadastrar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sessões";
            this.Load += new System.EventHandler(this.FormSessaoCadastrar_Load);
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            this.gbDataHora.ResumeLayout(false);
            this.gbDataHora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.ComboBox cbFisioterapeuta;
        private System.Windows.Forms.ComboBox cbClinica;
        private System.Windows.Forms.GroupBox gbDataHora;
        private System.Windows.Forms.MaskedTextBox mtxtHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtxtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txaObservacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel linkPaciente;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLblClinica;
    }
}