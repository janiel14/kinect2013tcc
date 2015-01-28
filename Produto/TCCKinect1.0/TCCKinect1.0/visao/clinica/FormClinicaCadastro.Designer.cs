namespace TCCKinect1._0.visao
{
    partial class FormClinicaCadastro
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
            this.txtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.MaskedTextBox();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.gbContato = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbInformacoes.SuspendLayout();
            this.gbEndereco.SuspendLayout();
            this.gbContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.txtCNPJ);
            this.gbInformacoes.Controls.Add(this.txtNomeFantasia);
            this.gbInformacoes.Controls.Add(this.txtRazaoSocial);
            this.gbInformacoes.Controls.Add(this.label3);
            this.gbInformacoes.Controls.Add(this.label2);
            this.gbInformacoes.Controls.Add(this.label1);
            this.gbInformacoes.Location = new System.Drawing.Point(12, 12);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(638, 112);
            this.gbInformacoes.TabIndex = 0;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(90, 22);
            this.txtCNPJ.Mask = "##,###,###/####-##";
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.PromptChar = ' ';
            this.txtCNPJ.Size = new System.Drawing.Size(115, 20);
            this.txtCNPJ.TabIndex = 1;
            this.txtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCNPJ.Enter += new System.EventHandler(this.txtCNPJ_Enter);
            this.txtCNPJ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCNPJ_KeyUp);
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.Enabled = false;
            this.txtNomeFantasia.Location = new System.Drawing.Point(90, 74);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(523, 20);
            this.txtNomeFantasia.TabIndex = 3;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Enabled = false;
            this.txtRazaoSocial.Location = new System.Drawing.Point(90, 48);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(523, 20);
            this.txtRazaoSocial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome Fantasia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razão Social:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CNPJ:";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.cbUF);
            this.gbEndereco.Controls.Add(this.txtNumero);
            this.gbEndereco.Controls.Add(this.txtCEP);
            this.gbEndereco.Controls.Add(this.label10);
            this.gbEndereco.Controls.Add(this.label9);
            this.gbEndereco.Controls.Add(this.label8);
            this.gbEndereco.Controls.Add(this.label7);
            this.gbEndereco.Controls.Add(this.label6);
            this.gbEndereco.Controls.Add(this.label5);
            this.gbEndereco.Controls.Add(this.label4);
            this.gbEndereco.Controls.Add(this.txtCidade);
            this.gbEndereco.Controls.Add(this.txtBairro);
            this.gbEndereco.Controls.Add(this.txtComplemento);
            this.gbEndereco.Controls.Add(this.txtLogradouro);
            this.gbEndereco.Location = new System.Drawing.Point(12, 126);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(638, 112);
            this.gbEndereco.TabIndex = 1;
            this.gbEndereco.TabStop = false;
            this.gbEndereco.Text = "Endereço:";
            // 
            // cbUF
            // 
            this.cbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUF.Enabled = false;
            this.cbUF.FormattingEnabled = true;
            this.cbUF.Items.AddRange(new object[] {
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cbUF.Location = new System.Drawing.Point(558, 71);
            this.cbUF.Name = "cbUF";
            this.cbUF.Size = new System.Drawing.Size(55, 21);
            this.cbUF.TabIndex = 10;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(558, 20);
            this.txtNumero.Mask = "000000";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PromptChar = ' ';
            this.txtNumero.Size = new System.Drawing.Size(55, 20);
            this.txtNumero.TabIndex = 5;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumero.ValidatingType = typeof(int);
            // 
            // txtCEP
            // 
            this.txtCEP.Enabled = false;
            this.txtCEP.Location = new System.Drawing.Point(380, 71);
            this.txtCEP.Mask = "00,000-000";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.PromptChar = ' ';
            this.txtCEP.Size = new System.Drawing.Size(104, 20);
            this.txtCEP.TabIndex = 9;
            this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(528, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "UF:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Cidade:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "CEP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(339, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bairro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Complemento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numero:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Logradouro:";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(90, 71);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(225, 20);
            this.txtCidade.TabIndex = 8;
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Location = new System.Drawing.Point(380, 45);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(233, 20);
            this.txtBairro.TabIndex = 7;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Location = new System.Drawing.Point(90, 45);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(225, 20);
            this.txtComplemento.TabIndex = 6;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Location = new System.Drawing.Point(90, 19);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(394, 20);
            this.txtLogradouro.TabIndex = 4;
            // 
            // gbContato
            // 
            this.gbContato.Controls.Add(this.txtEmail);
            this.gbContato.Controls.Add(this.txtCelular);
            this.gbContato.Controls.Add(this.txtTelefone);
            this.gbContato.Controls.Add(this.label13);
            this.gbContato.Controls.Add(this.label12);
            this.gbContato.Controls.Add(this.label11);
            this.gbContato.Location = new System.Drawing.Point(12, 240);
            this.gbContato.Name = "gbContato";
            this.gbContato.Size = new System.Drawing.Size(638, 59);
            this.gbContato.TabIndex = 2;
            this.gbContato.TabStop = false;
            this.gbContato.Text = "Contato:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(380, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(233, 24);
            this.txtCelular.Mask = "(00) 0000-0000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PromptChar = ' ';
            this.txtCelular.Size = new System.Drawing.Size(82, 20);
            this.txtCelular.TabIndex = 12;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Location = new System.Drawing.Point(90, 24);
            this.txtTelefone.Mask = "(00) 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.PromptChar = ' ';
            this.txtTelefone.Size = new System.Drawing.Size(82, 20);
            this.txtTelefone.TabIndex = 11;
            this.txtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(338, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "E-mail:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Celular:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Telefone:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::TCCKinect1._0.Properties.Resources.Salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(440, 305);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 32);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "       Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::TCCKinect1._0.Properties.Resources.Fechar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(548, 305);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 31);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "      Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormClinicaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 347);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbContato);
            this.Controls.Add(this.gbEndereco);
            this.Controls.Add(this.gbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClinicaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica";
            this.Load += new System.EventHandler(this.FormClinicaCadastro_Load);
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            this.gbContato.ResumeLayout(false);
            this.gbContato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCNPJ;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private System.Windows.Forms.GroupBox gbContato;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbUF;
    }
}