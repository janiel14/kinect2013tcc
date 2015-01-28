using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCCKinect1._0.dao;
using TCCKinect1._0.modelo;
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao
{
    public partial class FormClinicaCadastroInicial : Form
    {
        //Globais
        private Boolean parametroVisualizar = false;
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private Clinica nClinica = null;
        private ClinicaDAO daoClinica = null;

        public FormClinicaCadastroInicial(MySqlConnection conn)
        {
            InitializeComponent();
            this.nSessao = new Sessao(conn);
            this.nUtil = new Utils();
            this.nClinica = new Clinica();
            this.daoClinica = new ClinicaDAO(conn);
        }

        private void Salvar()
        {
            //Tratamento de erros
            try
            {
                // Validação
                if (this.nUtil.validaCnpj(this.txtCNPJ.Text) == false)
                {
                    errorProvider1.SetError(txtCNPJ, "CNPJ informado não é válido!");
                    this.txtCNPJ.Focus();
                }
                else if (this.txtRazaoSocial.Text.Length == 0)
                {
                    errorProvider1.SetError(txtRazaoSocial, "Informe a razão social da clinica!");
                    this.txtRazaoSocial.Focus();
                }
                else if (this.txtNomeFantasia.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNomeFantasia, "Informe o nome fantasia da clinica!!");
                    this.txtNomeFantasia.Focus();
                }
                else if (this.txtLogradouro.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtLogradouro, "Informe o logradouro!");
                    this.txtLogradouro.Focus();
                }
                else if (this.txtNumero.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNumero, "Informe o número!");
                    this.txtNumero.Focus();
                }
                else if (this.txtBairro.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtBairro, "Informe o bairro!");
                    this.txtBairro.Focus();
                }
                else if (this.txtCEP.Text.Equals("  .   -"))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCEP, "Informe CEP!");
                    this.txtCEP.Focus();
                }
                else if (this.txtCidade.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCidade, "Informe a cidade!");
                    this.txtCidade.Focus();
                }
                else if (this.txtTelefone.ToString().Length > 0 && this.txtTelefone.ToString().Length < 14)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTelefone, "Telefone inválido!");
                    this.txtTelefone.Focus();
                }
                else if (this.txtCelular.ToString().Length > 0 && this.txtCelular.ToString().Length < 14)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCelular, "Telefone inválido!");
                    this.txtCelular.Focus();
                }
                else if (this.txtEmail.Text.Trim().Length > 0 && this.nUtil.validaEmail(this.txtEmail.Text) == false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtEmail, "E-mail inválido!");
                    this.txtEmail.Focus();
                }
                else
                {
                    //Obtendo dados
                    Clinica tempClinica = new Clinica();

                    tempClinica.id = 0;
                    tempClinica.cnpj = this.txtCNPJ.Text.Trim();
                    tempClinica.razaoSocial = this.txtRazaoSocial.Text.Trim();
                    tempClinica.nomeFantasia = this.txtNomeFantasia.Text.Trim();
                    tempClinica.logradouro = this.txtLogradouro.Text.Trim();
                    tempClinica.numero = Convert.ToInt32(this.txtNumero.Text.Trim());
                    tempClinica.complemento = this.txtComplemento.Text.Trim();
                    tempClinica.bairro = this.txtBairro.Text.Trim();
                    tempClinica.cep = this.txtCEP.Text.Trim();
                    tempClinica.cidade = this.txtCidade.Text.Trim();
                    tempClinica.uf = this.cbUF.SelectedItem.ToString();
                    tempClinica.telefone = this.txtTelefone.Text.Trim();
                    tempClinica.celular = this.txtCelular.Text.Trim();
                    tempClinica.email = this.txtEmail.Text.Trim();

                    //Verificando falsh salvar
                    if (this.nClinica.id == 0 && this.parametroVisualizar == false)
                    {
                        //Salvando
                        if (this.daoClinica.cadastrar(tempClinica))
                        {
                            //Mensagem
                            MessageBox.Show("Clinica cadastrada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Questiona usuário se deseja cadastrar outro
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível cadastrar clinica!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            this.Salvar();
        }

        /// <summary>
        /// Varre todos os controles da tela e limpa os controles
        /// </summary>
        /// <param name="formulario">Limpa Controles</param>
        /// <returns>Void</returns>
        private void LimpaControles()
        {
            foreach (Control ctl in this.gbInformacoes.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Text = "";

                if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = -1;

                if (ctl is ListBox)
                    (ctl as ListBox).SelectedIndex = -1;

                if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = false;

                if (ctl is RadioButton)
                    (ctl as RadioButton).Checked = false;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Text = "";
            }

            foreach (Control ctl in this.gbEndereco.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Text = "";

                if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = -1;

                if (ctl is ListBox)
                    (ctl as ListBox).SelectedIndex = -1;

                if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = false;

                if (ctl is RadioButton)
                    (ctl as RadioButton).Checked = false;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Text = "";
            }

            foreach (Control ctl in this.gbContato.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Text = "";

                if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = -1;

                if (ctl is ListBox)
                    (ctl as ListBox).SelectedIndex = -1;

                if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = false;

                if (ctl is RadioButton)
                    (ctl as RadioButton).Checked = false;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Text = "";
            }
        }

        /// <summary>
        /// Este método hábilita todos controles, se o pâmetro for True
        /// e se for False desabilita
        /// </summary>
        /// <param name="habilitaDesabilita">True ou False</param>
        private void habilitaDesabilitaCampos(Boolean habilitaDesabilita)
        {
            foreach (Control ctl in this.gbInformacoes.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Enabled = habilitaDesabilita;

                if (ctl is ComboBox)
                    (ctl as ComboBox).Enabled = habilitaDesabilita;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Enabled = habilitaDesabilita;
            }

            foreach (Control ctl in this.gbEndereco.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Enabled = habilitaDesabilita;

                if (ctl is ComboBox)
                    (ctl as ComboBox).Enabled = habilitaDesabilita;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Enabled = habilitaDesabilita;
            }

            foreach (Control ctl in this.gbContato.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Enabled = habilitaDesabilita;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Enabled = habilitaDesabilita;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaControles();
            this.Close();
        }

        private void txtCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.nClinica.id == 0) //Verifica se a clinica está cadastrando.
            {
                if (this.nUtil.validaCnpj(this.txtCNPJ.Text)) //Verifica se o CNPJ é válido.
                {
                    if (this.daoClinica.existeClinica(this.txtCNPJ.Text.Trim())) //Verifica se o CNPJ já está cadastrado.
                    {
                        MessageBox.Show("Esta clinica já existe!", "Alerta!", MessageBoxButtons.OK
                            , MessageBoxIcon.Stop);
                        this.txtCNPJ.Clear();
                        this.txtCNPJ.Focus();
                        errorProvider1.Clear();
                    }
                    else
                    {
                        errorProvider1.Clear();
                        this.habilitaDesabilitaCampos(true);
                        this.txtCNPJ.Enabled = false;
                        this.txtRazaoSocial.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCNPJ, "CNPJ inválido!");
                    this.txtCEP.Focus();
                }
            }
            else
            {
                if (this.nUtil.validaCnpj(this.txtCNPJ.Text.Trim())) //Verifica se o CNPJ é válido.
                {
                    if (this.txtCNPJ.Text != this.nClinica.cnpj) //Verifica se o CNPJ digitado ainda é o mesmo.
                    {
                        if (this.daoClinica.existeClinica(this.txtCNPJ.Text.Trim()))  //Verifica se o CNPJ já está cadastrado.
                        {
                            MessageBox.Show("Esta clinica já existe!", "Alerta!", MessageBoxButtons.OK
                               , MessageBoxIcon.Stop);
                            this.txtCNPJ.Clear();
                            this.txtCNPJ.Focus();
                            errorProvider1.Clear();
                        }
                        else
                        {
                            errorProvider1.Clear();
                            this.txtRazaoSocial.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.Clear();
                        this.txtRazaoSocial.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCNPJ, "CNPJ inválido!");
                    this.txtCEP.Focus();
                }
            }
        }
    }
}
