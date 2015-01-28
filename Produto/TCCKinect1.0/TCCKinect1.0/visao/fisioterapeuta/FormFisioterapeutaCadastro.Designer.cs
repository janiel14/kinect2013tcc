namespace TCCKinect1._0.visao.fisioterapeuta
{
    partial class FormFisioterapeutaCadastro
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gbContato = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.cbUf = new System.Windows.Forms.ComboBox();
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
            this.gbInformacoes = new System.Windows.Forms.GroupBox();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.txtNasc = new System.Windows.Forms.MaskedTextBox();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.txtEsp = new System.Windows.Forms.TextBox();
            this.txtCrefito = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClinica = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbClinica = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbContato.SuspendLayout();
            this.gbEndereco.SuspendLayout();
            this.gbInformacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbClinica.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::TCCKinect1._0.Properties.Resources.Salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(488, 341);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 32);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "     Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // gbContato
            // 
            this.gbContato.Controls.Add(this.txtEmail);
            this.gbContato.Controls.Add(this.txtCelular);
            this.gbContato.Controls.Add(this.txtTelefone);
            this.gbContato.Controls.Add(this.label13);
            this.gbContato.Controls.Add(this.label12);
            this.gbContato.Controls.Add(this.label11);
            this.gbContato.Location = new System.Drawing.Point(12, 281);
            this.gbContato.Name = "gbContato";
            this.gbContato.Size = new System.Drawing.Size(686, 56);
            this.gbContato.TabIndex = 6;
            this.gbContato.TabStop = false;
            this.gbContato.Text = "Contato:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(406, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(253, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(241, 24);
            this.txtCelular.Mask = "(00) 0000-0000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PromptChar = ' ';
            this.txtCelular.Size = new System.Drawing.Size(95, 20);
            this.txtCelular.TabIndex = 17;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Location = new System.Drawing.Point(86, 24);
            this.txtTelefone.Mask = "(00) 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.PromptChar = ' ';
            this.txtTelefone.Size = new System.Drawing.Size(95, 20);
            this.txtTelefone.TabIndex = 16;
            this.txtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(362, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "E-mail:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(197, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Celular:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Telefone:";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.cbUf);
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
            this.gbEndereco.Location = new System.Drawing.Point(12, 167);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(686, 112);
            this.gbEndereco.TabIndex = 5;
            this.gbEndereco.TabStop = false;
            this.gbEndereco.Text = "Endereço:";
            // 
            // cbUf
            // 
            this.cbUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUf.Enabled = false;
            this.cbUf.FormattingEnabled = true;
            this.cbUf.Items.AddRange(new object[] {
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
            this.cbUf.Location = new System.Drawing.Point(606, 71);
            this.cbUf.Name = "cbUf";
            this.cbUf.Size = new System.Drawing.Size(53, 21);
            this.cbUf.TabIndex = 15;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(606, 19);
            this.txtNumero.Mask = "000000";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PromptChar = ' ';
            this.txtNumero.Size = new System.Drawing.Size(53, 20);
            this.txtNumero.TabIndex = 10;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCEP
            // 
            this.txtCEP.Enabled = false;
            this.txtCEP.Location = new System.Drawing.Point(406, 71);
            this.txtCEP.Mask = "00,000-000";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.PromptChar = ' ';
            this.txtCEP.Size = new System.Drawing.Size(90, 20);
            this.txtCEP.TabIndex = 14;
            this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(576, 74);
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
            this.label8.Location = new System.Drawing.Point(369, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "CEP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bairro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Complemento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numero:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Logradouro:";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(86, 71);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(254, 20);
            this.txtCidade.TabIndex = 13;
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Location = new System.Drawing.Point(406, 46);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(253, 20);
            this.txtBairro.TabIndex = 12;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Location = new System.Drawing.Point(86, 46);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(254, 20);
            this.txtComplemento.TabIndex = 11;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Location = new System.Drawing.Point(86, 19);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(447, 20);
            this.txtLogradouro.TabIndex = 9;
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.cbEstadoCivil);
            this.gbInformacoes.Controls.Add(this.txtNasc);
            this.gbInformacoes.Controls.Add(this.cbSexo);
            this.gbInformacoes.Controls.Add(this.txtEsp);
            this.gbInformacoes.Controls.Add(this.txtCrefito);
            this.gbInformacoes.Controls.Add(this.label19);
            this.gbInformacoes.Controls.Add(this.label18);
            this.gbInformacoes.Controls.Add(this.label17);
            this.gbInformacoes.Controls.Add(this.label16);
            this.gbInformacoes.Controls.Add(this.label15);
            this.gbInformacoes.Controls.Add(this.txtCPF);
            this.gbInformacoes.Controls.Add(this.txtRG);
            this.gbInformacoes.Controls.Add(this.txtNome);
            this.gbInformacoes.Controls.Add(this.label3);
            this.gbInformacoes.Controls.Add(this.label2);
            this.gbInformacoes.Controls.Add(this.label1);
            this.gbInformacoes.Location = new System.Drawing.Point(12, 55);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(686, 110);
            this.gbInformacoes.TabIndex = 4;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações:";
            // 
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoCivil.Enabled = false;
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Items.AddRange(new object[] {
            "Solteiro",
            "Casado",
            "Viúvo",
            "Divorciado"});
            this.cbEstadoCivil.Location = new System.Drawing.Point(86, 75);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(95, 21);
            this.cbEstadoCivil.TabIndex = 6;
            // 
            // txtNasc
            // 
            this.txtNasc.Enabled = false;
            this.txtNasc.Location = new System.Drawing.Point(583, 22);
            this.txtNasc.Mask = "00/00/0000";
            this.txtNasc.Name = "txtNasc";
            this.txtNasc.PromptChar = ' ';
            this.txtNasc.Size = new System.Drawing.Size(76, 20);
            this.txtNasc.TabIndex = 4;
            this.txtNasc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNasc.ValidatingType = typeof(System.DateTime);
            // 
            // cbSexo
            // 
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.Enabled = false;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cbSexo.Location = new System.Drawing.Point(406, 21);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(48, 21);
            this.cbSexo.TabIndex = 3;
            // 
            // txtEsp
            // 
            this.txtEsp.Enabled = false;
            this.txtEsp.Location = new System.Drawing.Point(455, 75);
            this.txtEsp.Name = "txtEsp";
            this.txtEsp.Size = new System.Drawing.Size(204, 20);
            this.txtEsp.TabIndex = 8;
            // 
            // txtCrefito
            // 
            this.txtCrefito.Enabled = false;
            this.txtCrefito.Location = new System.Drawing.Point(241, 75);
            this.txtCrefito.Name = "txtCrefito";
            this.txtCrefito.Size = new System.Drawing.Size(99, 20);
            this.txtCrefito.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Estado Civil:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(470, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Data de Nascimento:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(366, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Sexo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(368, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Especialização:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(203, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Crefito:";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(86, 22);
            this.txtCPF.Mask = "###.###.###-##";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.PromptChar = ' ';
            this.txtCPF.Size = new System.Drawing.Size(95, 20);
            this.txtCPF.TabIndex = 99;
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCPF.Enter += new System.EventHandler(this.txtCPF_Enter);
            this.txtCPF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyUp);
            // 
            // txtRG
            // 
            this.txtRG.Enabled = false;
            this.txtRG.Location = new System.Drawing.Point(241, 22);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(99, 20);
            this.txtRG.TabIndex = 2;
            this.txtRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(86, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(573, 20);
            this.txtNome.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "RG:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CPF:";
            // 
            // cbClinica
            // 
            this.cbClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClinica.Enabled = false;
            this.cbClinica.FormattingEnabled = true;
            this.cbClinica.Location = new System.Drawing.Point(86, 14);
            this.cbClinica.Name = "cbClinica";
            this.cbClinica.Size = new System.Drawing.Size(573, 21);
            this.cbClinica.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Clínica:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbClinica
            // 
            this.gbClinica.Controls.Add(this.label14);
            this.gbClinica.Controls.Add(this.cbClinica);
            this.gbClinica.Location = new System.Drawing.Point(12, 6);
            this.gbClinica.Name = "gbClinica";
            this.gbClinica.Size = new System.Drawing.Size(686, 45);
            this.gbClinica.TabIndex = 8;
            this.gbClinica.TabStop = false;
            this.gbClinica.Text = "Clínica:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::TCCKinect1._0.Properties.Resources.Fechar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(596, 343);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 31);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormFisioterapeutaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 385);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbClinica);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbContato);
            this.Controls.Add(this.gbEndereco);
            this.Controls.Add(this.gbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFisioterapeutaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fisioterapeuta";
            this.Load += new System.EventHandler(this.FormFisioterapeutaCadastro_Load);
            this.gbContato.ResumeLayout(false);
            this.gbContato.PerformLayout();
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbClinica.ResumeLayout(false);
            this.gbClinica.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox gbContato;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.MaskedTextBox txtCEP;
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
        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClinica;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.TextBox txtEsp;
        private System.Windows.Forms.TextBox txtCrefito;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtNasc;
        private System.Windows.Forms.GroupBox gbClinica;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.ComboBox cbUf;
    }
}