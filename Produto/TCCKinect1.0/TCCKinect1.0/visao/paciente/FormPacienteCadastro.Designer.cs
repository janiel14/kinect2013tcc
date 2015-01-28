namespace TCCKinect1._0.visao.paciente
{
    partial class FormPacienteCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPacienteCadastro));
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.gbInformacoes = new System.Windows.Forms.GroupBox();
            this.txtProfissao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataDeNascimento = new System.Windows.Forms.MaskedTextBox();
            this.lblDataDeNascimento = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cbClinica = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.cbUf = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.MaskedTextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbContato = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txaObservacoes = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbClinica = new System.Windows.Forms.GroupBox();
            this.gbInformacoes.SuspendLayout();
            this.gbEndereco.SuspendLayout();
            this.gbContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbClinica.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(12, 22);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(30, 13);
            this.lblCpf.TabIndex = 0;
            this.lblCpf.Text = "CPF:";
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.SystemColors.Window;
            this.txtCPF.Location = new System.Drawing.Point(85, 18);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.PromptChar = ' ';
            this.txtCPF.Size = new System.Drawing.Size(95, 20);
            this.txtCPF.TabIndex = 99;
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCPF.Enter += new System.EventHandler(this.txtCPF_Enter);
            this.txtCPF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyUp);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 48);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(85, 45);
            this.txtNome.MaxLength = 88;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(583, 20);
            this.txtNome.TabIndex = 5;
            // 
            // txtRG
            // 
            this.txtRG.Enabled = false;
            this.txtRG.Location = new System.Drawing.Point(235, 18);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(95, 20);
            this.txtRG.TabIndex = 2;
            this.txtRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Location = new System.Drawing.Point(209, 21);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(26, 13);
            this.lblRG.TabIndex = 6;
            this.lblRG.Text = "RG:";
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.txtProfissao);
            this.gbInformacoes.Controls.Add(this.label5);
            this.gbInformacoes.Controls.Add(this.cbEstadoCivil);
            this.gbInformacoes.Controls.Add(this.label4);
            this.gbInformacoes.Controls.Add(this.txtDataDeNascimento);
            this.gbInformacoes.Controls.Add(this.lblDataDeNascimento);
            this.gbInformacoes.Controls.Add(this.cbSexo);
            this.gbInformacoes.Controls.Add(this.lblSexo);
            this.gbInformacoes.Controls.Add(this.txtCPF);
            this.gbInformacoes.Controls.Add(this.txtNome);
            this.gbInformacoes.Controls.Add(this.txtRG);
            this.gbInformacoes.Controls.Add(this.lblNome);
            this.gbInformacoes.Controls.Add(this.lblRG);
            this.gbInformacoes.Controls.Add(this.lblCpf);
            this.gbInformacoes.Location = new System.Drawing.Point(12, 59);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(694, 106);
            this.gbInformacoes.TabIndex = 7;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações:";
            // 
            // txtProfissao
            // 
            this.txtProfissao.Enabled = false;
            this.txtProfissao.Location = new System.Drawing.Point(392, 71);
            this.txtProfissao.MaxLength = 41;
            this.txtProfissao.Name = "txtProfissao";
            this.txtProfissao.Size = new System.Drawing.Size(276, 20);
            this.txtProfissao.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Profissão:";
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
            this.cbEstadoCivil.Location = new System.Drawing.Point(85, 74);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(95, 21);
            this.cbEstadoCivil.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Estado Civil:";
            // 
            // txtDataDeNascimento
            // 
            this.txtDataDeNascimento.Enabled = false;
            this.txtDataDeNascimento.Location = new System.Drawing.Point(579, 18);
            this.txtDataDeNascimento.Mask = "00/00/0000";
            this.txtDataDeNascimento.Name = "txtDataDeNascimento";
            this.txtDataDeNascimento.PromptChar = ' ';
            this.txtDataDeNascimento.Size = new System.Drawing.Size(89, 20);
            this.txtDataDeNascimento.TabIndex = 4;
            this.txtDataDeNascimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataDeNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // lblDataDeNascimento
            // 
            this.lblDataDeNascimento.AutoSize = true;
            this.lblDataDeNascimento.Location = new System.Drawing.Point(468, 21);
            this.lblDataDeNascimento.Name = "lblDataDeNascimento";
            this.lblDataDeNascimento.Size = new System.Drawing.Size(105, 13);
            this.lblDataDeNascimento.TabIndex = 9;
            this.lblDataDeNascimento.Text = "Data de nascimento:";
            // 
            // cbSexo
            // 
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.Enabled = false;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cbSexo.Location = new System.Drawing.Point(392, 17);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(48, 21);
            this.cbSexo.TabIndex = 3;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(352, 21);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 7;
            this.lblSexo.Text = "Sexo:";
            // 
            // cbClinica
            // 
            this.cbClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClinica.Enabled = false;
            this.cbClinica.FormattingEnabled = true;
            this.cbClinica.Location = new System.Drawing.Point(85, 15);
            this.cbClinica.Name = "cbClinica";
            this.cbClinica.Size = new System.Drawing.Size(583, 21);
            this.cbClinica.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Clínica:";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.cbUf);
            this.gbEndereco.Controls.Add(this.label12);
            this.gbEndereco.Controls.Add(this.txtCidade);
            this.gbEndereco.Controls.Add(this.label11);
            this.gbEndereco.Controls.Add(this.txtCep);
            this.gbEndereco.Controls.Add(this.label10);
            this.gbEndereco.Controls.Add(this.label9);
            this.gbEndereco.Controls.Add(this.txtBairro);
            this.gbEndereco.Controls.Add(this.txtComplemento);
            this.gbEndereco.Controls.Add(this.label8);
            this.gbEndereco.Controls.Add(this.label7);
            this.gbEndereco.Controls.Add(this.txtNumero);
            this.gbEndereco.Controls.Add(this.txtLogradouro);
            this.gbEndereco.Controls.Add(this.label6);
            this.gbEndereco.Location = new System.Drawing.Point(12, 167);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(694, 104);
            this.gbEndereco.TabIndex = 8;
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
            this.cbUf.Location = new System.Drawing.Point(615, 71);
            this.cbUf.Name = "cbUf";
            this.cbUf.Size = new System.Drawing.Size(53, 21);
            this.cbUf.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(585, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "UF:";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(85, 72);
            this.txtCidade.MaxLength = 46;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(245, 20);
            this.txtCidade.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Cidade:";
            // 
            // txtCep
            // 
            this.txtCep.Enabled = false;
            this.txtCep.Location = new System.Drawing.Point(392, 71);
            this.txtCep.Mask = "00,000-000";
            this.txtCep.Name = "txtCep";
            this.txtCep.PromptChar = ' ';
            this.txtCep.Size = new System.Drawing.Size(90, 20);
            this.txtCep.TabIndex = 13;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "CEP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairro.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtBairro, 3);
            this.txtBairro.Location = new System.Drawing.Point(392, 45);
            this.txtBairro.MaxLength = 41;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(276, 20);
            this.txtBairro.TabIndex = 11;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Location = new System.Drawing.Point(85, 45);
            this.txtComplemento.MaxLength = 39;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(245, 20);
            this.txtComplemento.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Complemento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(562, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(615, 19);
            this.txtNumero.Mask = "#####";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PromptChar = ' ';
            this.txtNumero.Size = new System.Drawing.Size(53, 20);
            this.txtNumero.TabIndex = 9;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Location = new System.Drawing.Point(85, 20);
            this.txtLogradouro.MaxLength = 72;
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(457, 20);
            this.txtLogradouro.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Logradouro:";
            // 
            // gbContato
            // 
            this.gbContato.Controls.Add(this.txtEmail);
            this.gbContato.Controls.Add(this.label15);
            this.gbContato.Controls.Add(this.txtCelular);
            this.gbContato.Controls.Add(this.label14);
            this.gbContato.Controls.Add(this.txtTelefone);
            this.gbContato.Controls.Add(this.label13);
            this.gbContato.Location = new System.Drawing.Point(12, 277);
            this.gbContato.Name = "gbContato";
            this.gbContato.Size = new System.Drawing.Size(694, 57);
            this.gbContato.TabIndex = 9;
            this.gbContato.TabStop = false;
            this.gbContato.Text = "Contato:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(392, 22);
            this.txtEmail.MaxLength = 41;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(276, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(348, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "E-mail:";
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(248, 22);
            this.txtCelular.Mask = "(##) ####-####";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PromptChar = ' ';
            this.txtCelular.Size = new System.Drawing.Size(82, 20);
            this.txtCelular.TabIndex = 16;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Celular:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Location = new System.Drawing.Point(85, 22);
            this.txtTelefone.Mask = "(##) ####-####";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.PromptChar = ' ';
            this.txtTelefone.Size = new System.Drawing.Size(82, 20);
            this.txtTelefone.TabIndex = 15;
            this.txtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Telefone:";
            // 
            // txaObservacoes
            // 
            this.txaObservacoes.BackColor = System.Drawing.SystemColors.Window;
            this.txaObservacoes.Enabled = false;
            this.txaObservacoes.Location = new System.Drawing.Point(12, 353);
            this.txaObservacoes.Name = "txaObservacoes";
            this.txaObservacoes.Size = new System.Drawing.Size(694, 58);
            this.txaObservacoes.TabIndex = 18;
            this.txaObservacoes.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 337);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Observações:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = global::TCCKinect1._0.Properties.Resources.Salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(496, 417);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 32);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "       Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(604, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "      Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // gbClinica
            // 
            this.gbClinica.Controls.Add(this.cbClinica);
            this.gbClinica.Controls.Add(this.label1);
            this.gbClinica.Location = new System.Drawing.Point(12, 12);
            this.gbClinica.Name = "gbClinica";
            this.gbClinica.Size = new System.Drawing.Size(694, 45);
            this.gbClinica.TabIndex = 21;
            this.gbClinica.TabStop = false;
            this.gbClinica.Text = "Clínica:";
            // 
            // FormPacienteCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(716, 464);
            this.Controls.Add(this.gbClinica);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.gbContato);
            this.Controls.Add(this.txaObservacoes);
            this.Controls.Add(this.gbEndereco);
            this.Controls.Add(this.gbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPacienteCadastro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paciente";
            this.Load += new System.EventHandler(this.FormPacienteCadastro_Load);
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            this.gbContato.ResumeLayout(false);
            this.gbContato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbClinica.ResumeLayout(false);
            this.gbClinica.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblDataDeNascimento;
        private System.Windows.Forms.MaskedTextBox txtDataDeNascimento;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProfissao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbContato;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox txaObservacoes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbUf;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbClinica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbClinica;
    }
}