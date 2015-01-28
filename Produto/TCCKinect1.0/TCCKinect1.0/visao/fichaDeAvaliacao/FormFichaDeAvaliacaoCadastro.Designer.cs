namespace TCCKinect1._0.visao.fichaDeAvaliacao
{
    partial class FormFichaDeAvaliacaoCadastro
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
            this.txtDiasDeAula = new System.Windows.Forms.TextBox();
            this.txtConduta = new System.Windows.Forms.TextBox();
            this.txtObjetivo = new System.Windows.Forms.TextBox();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.txtDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.txtDataProximaAvaliacao = new System.Windows.Forms.MaskedTextBox();
            this.txtDataAvaliacao = new System.Windows.Forms.MaskedTextBox();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gbInformacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.txtDiasDeAula);
            this.gbInformacoes.Controls.Add(this.txtConduta);
            this.gbInformacoes.Controls.Add(this.txtObjetivo);
            this.gbInformacoes.Controls.Add(this.txtDiagnostico);
            this.gbInformacoes.Controls.Add(this.txtDataVencimento);
            this.gbInformacoes.Controls.Add(this.txtDataProximaAvaliacao);
            this.gbInformacoes.Controls.Add(this.txtDataAvaliacao);
            this.gbInformacoes.Controls.Add(this.cbPaciente);
            this.gbInformacoes.Controls.Add(this.label8);
            this.gbInformacoes.Controls.Add(this.label7);
            this.gbInformacoes.Controls.Add(this.label6);
            this.gbInformacoes.Controls.Add(this.label5);
            this.gbInformacoes.Controls.Add(this.label4);
            this.gbInformacoes.Controls.Add(this.label3);
            this.gbInformacoes.Controls.Add(this.label2);
            this.gbInformacoes.Controls.Add(this.label1);
            this.gbInformacoes.Location = new System.Drawing.Point(12, 12);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(707, 452);
            this.gbInformacoes.TabIndex = 1;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações:";
            // 
            // txtDiasDeAula
            // 
            this.txtDiasDeAula.Location = new System.Drawing.Point(85, 46);
            this.txtDiasDeAula.Name = "txtDiasDeAula";
            this.txtDiasDeAula.Size = new System.Drawing.Size(194, 20);
            this.txtDiasDeAula.TabIndex = 3;
            // 
            // txtConduta
            // 
            this.txtConduta.Location = new System.Drawing.Point(11, 337);
            this.txtConduta.Multiline = true;
            this.txtConduta.Name = "txtConduta";
            this.txtConduta.Size = new System.Drawing.Size(665, 100);
            this.txtConduta.TabIndex = 8;
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.Location = new System.Drawing.Point(11, 217);
            this.txtObjetivo.Multiline = true;
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.Size = new System.Drawing.Size(665, 100);
            this.txtObjetivo.TabIndex = 7;
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(11, 96);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(665, 100);
            this.txtDiagnostico.TabIndex = 6;
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.Location = new System.Drawing.Point(371, 46);
            this.txtDataVencimento.Mask = "00/00/0000";
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.PromptChar = ' ';
            this.txtDataVencimento.Size = new System.Drawing.Size(86, 20);
            this.txtDataVencimento.TabIndex = 4;
            this.txtDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataProximaAvaliacao
            // 
            this.txtDataProximaAvaliacao.Location = new System.Drawing.Point(587, 46);
            this.txtDataProximaAvaliacao.Mask = "00/00/0000";
            this.txtDataProximaAvaliacao.Name = "txtDataProximaAvaliacao";
            this.txtDataProximaAvaliacao.PromptChar = ' ';
            this.txtDataProximaAvaliacao.Size = new System.Drawing.Size(89, 20);
            this.txtDataProximaAvaliacao.TabIndex = 5;
            this.txtDataProximaAvaliacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataProximaAvaliacao.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataAvaliacao
            // 
            this.txtDataAvaliacao.Location = new System.Drawing.Point(587, 19);
            this.txtDataAvaliacao.Mask = "00/00/0000";
            this.txtDataAvaliacao.Name = "txtDataAvaliacao";
            this.txtDataAvaliacao.PromptChar = ' ';
            this.txtDataAvaliacao.Size = new System.Drawing.Size(89, 20);
            this.txtDataAvaliacao.TabIndex = 2;
            this.txtDataAvaliacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataAvaliacao.ValidatingType = typeof(System.DateTime);
            // 
            // cbPaciente
            // 
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.FormattingEnabled = true;
            this.cbPaciente.Location = new System.Drawing.Point(85, 18);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(372, 21);
            this.cbPaciente.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Conduta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Obejtivo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Diagnostico:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vencimento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dias de Aula:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Próxima Avaliação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data da Avaliação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paciente:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::TCCKinect1._0.Properties.Resources.Salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(509, 470);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 32);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "    Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Image = global::TCCKinect1._0.Properties.Resources.Fechar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(617, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "     Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormFichaDeAvaliacaoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFichaDeAvaliacaoCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha de Avaliação";
            this.Load += new System.EventHandler(this.FormFichaDeAvaliacaoCadastro_Load);
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtConduta;
        private System.Windows.Forms.TextBox txtObjetivo;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.MaskedTextBox txtDataVencimento;
        private System.Windows.Forms.MaskedTextBox txtDataProximaAvaliacao;
        private System.Windows.Forms.MaskedTextBox txtDataAvaliacao;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDiasDeAula;
    }
}