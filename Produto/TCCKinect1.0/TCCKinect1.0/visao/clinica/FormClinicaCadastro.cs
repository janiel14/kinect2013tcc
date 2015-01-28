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
    public partial class FormClinicaCadastro : Form
    {
        //Globais
        private Boolean parametroVisualizar = false;
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private Clinica nClinica = null;
        private ClinicaDAO daoClinica = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessão</param>
        /// <param name="id">Identificação do cadastro</param>
        /// <param name="Visualizar">Boolean Visualizar</param>
        /// <param name="objCliente">Objeto com dados da Clinica</param>
        public FormClinicaCadastro(Object sessao, int id, Boolean visualizar, object objClinica)
        {
            InitializeComponent();
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.nClinica = new Clinica (id, null, null, null, null, 0, null, null, null, null, null, null, null, null);
            this.daoClinica = new ClinicaDAO (this.nSessao.connMysql);
            this.parametroVisualizar = visualizar;
            //Checando objeto cliente
            if (objClinica != null)
            {
                this.nClinica = (Clinica)objClinica;
            }
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
                    errorProvider1.SetError(txtRazaoSocial, "Informe a razão social da clínica!");
                    this.txtRazaoSocial.Focus();
                }                    
                else if (this.txtNomeFantasia.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNomeFantasia, "Informe o nome fantasia da clínica!!");
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
                else if (this.txtCidade.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCidade, "Informe a cidade!");
                    this.txtCidade.Focus();
                }
                else if (this.txtCEP.Text.Replace(".", "").Replace("-", "").Trim().Length < 9)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCEP, "CEP inválido!");
                    this.txtCEP.Focus();
                }
                else if (this.cbUF.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbUF, "Selecione a UF.");
                    this.cbUF.Focus();
                }
                else if (this.txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length > 0 &&
                    this.txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length < 11)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTelefone, "Telefone inválido!");
                    this.txtTelefone.Focus();
                }
                else if (this.txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length > 0 &&
                    this.txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length < 11)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCelular, "Celular inválido!");
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
                            MessageBox.Show("Clínica cadastrada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Questiona usuário se deseja cadastrar outro
                            DialogResult dr = MessageBox.Show("Deseja cadastrar outra clínica?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            //Verifica decisão
                            if (dr == DialogResult.Yes)
                            {
                                this.habilitaDesabilitaCampos(false);
                                this.txtCNPJ.Enabled = true;
                                //Limpando cadastro
                                this.LimpaControles();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível cadastrar clínica!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (this.nClinica.id > 0 && this.parametroVisualizar == false)
                    {
                        //Obtendo id
                        tempClinica.id = this.nClinica.id;
                        //Atualizando cliente
                        if (this.daoClinica.alterar(tempClinica))
                        {

                            //Mensagem
                            MessageBox.Show("Clínica alterada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Direcionando para tela principal
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar clinica!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormClinicaCadastro_Load(object sender, EventArgs e)
        {
        //Tratamento de erros
            try
            {
                //Verificando se há identificação do cadastro
                if (this.nClinica.id > 0)
                {
                    this.txtCNPJ.Text = this.nClinica.cnpj;
                    this.txtRazaoSocial.Text = this.nClinica.razaoSocial;
                    this.txtNomeFantasia.Text = this.nClinica.nomeFantasia;
                    this.txtLogradouro.Text = this.nClinica.logradouro;
                    this.txtNumero.Text = this.nClinica.numero.ToString();
                    this.txtComplemento.Text = this.nClinica.complemento;
                    this.txtBairro.Text = this.nClinica.bairro;
                    this.txtCEP.Text = this.nClinica.cep;
                    this.txtCidade.Text = this.nClinica.cidade;
                    this.cbUF.SelectedItem = this.nClinica.uf;
                    this.txtTelefone.Text = this.nClinica.telefone;
                    this.txtCelular.Text = this.nClinica.celular;
                    this.txtEmail.Text = this.nClinica.email;

                    //Checando parametro visualizar
                    if (this.parametroVisualizar)
                    {
                        //bloqueando campos para edição.                      
                        this.habilitaDesabilitaCampos(false);
                        this.btnSalvar.Visible = false;
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
            errorProvider1.Clear();
            Salvar();
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

                if (ctl is ListBox)
                    (ctl as ListBox).Enabled = habilitaDesabilita;

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
                        MessageBox.Show("Esta clínica já existe!", "Alerta!", MessageBoxButtons.OK
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
                            MessageBox.Show("Esta clínica já existe!", "Alerta!", MessageBoxButtons.OK
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

        private void txtCNPJ_Enter(object sender, EventArgs e)
        {
            if (this.nClinica.id > 0 && this.parametroVisualizar == false)
            {
                this.habilitaDesabilitaCampos(true);
                this.txtCNPJ.Enabled = true;
            }
        }

    }
}
    

