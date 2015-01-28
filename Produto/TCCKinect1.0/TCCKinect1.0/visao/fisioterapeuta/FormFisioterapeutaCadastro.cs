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

namespace TCCKinect1._0.visao.fisioterapeuta
{
    public partial class FormFisioterapeutaCadastro : Form
    {
        //Globais
        private Boolean parametroVisualizar = false;
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private Fisioterapeuta nFisioterapeuta;
        private FisioterapeutaDAO daoFisioterapeuta;
        private Clinica nClinica = null;
        private ClinicaDAO daoClinica = null;
   

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessão</param>
        /// <param name="id">Identificação do cadastro</param>
        /// <param name="Visualizar">Boolean Visualizar</param>
        /// <param name="objCliente">Objeto com dados do fisioterapeuta</param>
        public FormFisioterapeutaCadastro(Object sessao, int id, Boolean visualizar, object objFisioterapeuta)
        {
            InitializeComponent();
            //Globais
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.nFisioterapeuta = new Fisioterapeuta();
            this.nFisioterapeuta.id = id;
            this.daoClinica = new ClinicaDAO(this.nSessao.connMysql);
            this.daoFisioterapeuta = new FisioterapeutaDAO(this.nSessao.connMysql);
            this.parametroVisualizar = visualizar;
            //Checando objeto cliente
            if (objFisioterapeuta != null)
            {
                this.nFisioterapeuta = (Fisioterapeuta)objFisioterapeuta;
            }

        }

        /// <summary>
        /// Preenche combo box clinica
        /// </summary>
        private void preencheComboBoxClinica()
        {
            //Tratamento de erros
            try
            {
                //Obtendo data table
                this.cbClinica.DataSource = this.daoClinica.getDataTable();
                this.cbClinica.DisplayMember = "RAZÃO SOCIAL";
                this.cbClinica.ValueMember = "ID";
                this.cbClinica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (ctl is DateTimePicker)
                    (ctl as DateTimePicker).Text = "";
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

        private void FormFisioterapeutaCadastro_Load(object sender, EventArgs e)
        {
            Clinica clinica;
            //Tratamento de erros
            try
            {
                 this.preencheComboBoxClinica();
                //Verificando se há identificação do cadastro
                if (this.nFisioterapeuta.id > 0)
                {
                    clinica = this.nFisioterapeuta.clinica;
                    this.cbClinica.SelectedValue = clinica.id;
                    this.txtCPF.Text = this.nFisioterapeuta.cpf;
                    this.txtRG.Text = this.nFisioterapeuta.rg;
                    this.txtNome.Text = this.nFisioterapeuta.nome;
                    this.txtCrefito.Text = this.nFisioterapeuta.crefito;
                    this.txtEsp.Text = this.nFisioterapeuta.especializacao;
                    this.cbSexo.SelectedItem = this.nFisioterapeuta.sexo;
                    this.txtNasc.Text = this.nFisioterapeuta.dataDeNascimento.ToString();
                    this.cbEstadoCivil.SelectedItem = this.nFisioterapeuta.estadoCivil;
                    this.txtLogradouro.Text = this.nFisioterapeuta.logradouro;
                    this.txtNumero.Text = this.nFisioterapeuta.numero.ToString();
                    this.txtComplemento.Text = this.nFisioterapeuta.complemento;
                    this.txtBairro.Text = this.nFisioterapeuta.bairro;
                    this.txtCEP.Text = this.nFisioterapeuta.cep;
                    this.txtCidade.Text = this.nFisioterapeuta.cidade;
                    this.cbUf.SelectedItem = this.nFisioterapeuta.uf;
                    this.txtTelefone.Text = this.nFisioterapeuta.telefone;
                    this.txtCelular.Text = this.nFisioterapeuta.celular;
                    this.txtEmail.Text = this.nFisioterapeuta.email;

                    //Checando parametro visualizar
                    if (this.parametroVisualizar == true)
                    {
                        //bloqueando campos para edição. 
                        this.habilitaEDesabilitaCampos(false);
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
            Salvar();
        }

        private void Salvar()
        {
            //Tratamento de erros
            try
            {
                // Validação
                 if (this.cbClinica.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbClinica, "Informe a clinica do fisioterapeuta!");
                    this.cbClinica.Focus();

                }
                else if (this.nUtil.validaCpf(this.txtCPF.Text) == false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCPF, "CPF informado não é válido!");
                    this.txtCPF.Focus();
                }
                else if (this.txtRG.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtRG, "Informe o RG do fisioterapeuta!");
                    this.txtRG.Focus();
                }
                else if (this.cbSexo.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbSexo, "Selecione o sexo do fisioterapeuta!");
                    this.cbSexo.Focus();

                }
                else if (this.nUtil.validaData(this.txtNasc.Text) == false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNasc, "Data inválida!");
                    this.txtNasc.Focus();
                }
                else if (this.txtNome.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNome, "Informe o nome do fisioterapeuta!");
                    this.txtNome.Focus();
                }
                else if (this.cbEstadoCivil.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbEstadoCivil, "Informe o estado civil do fisioterapeuta!");
                    this.cbEstadoCivil.Focus();
                }
                else if (this.txtCrefito.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCrefito, "Informe o crefito do fisioterapeuta!");
                    this.txtCrefito.Focus();
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
                 else if (this.txtCEP.Text.Replace(",", "").Replace("-", "").Trim().Length < 9)
                 {
                     errorProvider1.Clear();
                     errorProvider1.SetError(txtCEP, "CEP inválido!");
                     this.txtCEP.Focus();
                 }
                else if (this.cbUf.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbUf, "Selecione a UF!");
                    this.cbUf.Focus();
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
                    errorProvider1.Clear();
                    //Obtendo dados
                    this.nClinica = new Clinica(this.nUtil.convertStringParaInt(this.cbClinica.SelectedValue.ToString()), null, this.cbClinica.Text,null,null,0,null,null,null,null,null,null,null,null);
                    Fisioterapeuta tempFisioterapeuta = new Fisioterapeuta(0, this.nClinica, this.txtNome.Text, txtCPF.Text, this.txtRG.Text, this.txtCrefito.Text, this.txtEsp.Text, this.cbSexo.Text,nUtil.convertStringParaData(this.txtNasc.Text), this.cbEstadoCivil.SelectedItem.ToString(), this.txtLogradouro.Text,
                        nUtil.convertStringParaInt(this.txtNumero.Text),this.txtComplemento.Text,this.txtBairro.Text,this.txtCEP.Text,this.txtCidade.Text,this.cbUf.SelectedItem.ToString(),this.txtTelefone.Text,this.txtCelular.Text,this.txtEmail.Text);

                    //Verificando falsh salvar
                    if (this.nFisioterapeuta.id == 0 && this.parametroVisualizar == false)
                    {
                        //Salvando
                        if (this.daoFisioterapeuta.cadastrar(tempFisioterapeuta))
                        {
                            //Mensagem
                            MessageBox.Show("Fisioterapeuta cadastrado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Questiona usuário se deseja cadastrar outro
                            DialogResult dr = MessageBox.Show("Deseja cadastrar outro fisioterapeuta?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            //Verifica decisão
                            if (dr == DialogResult.Yes)
                            {
                                //Limpando cadastro
                                this.LimpaControles();
                                this.habilitaEDesabilitaCampos(false);
                                this.txtCPF.Enabled = true;
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível cadastrar o fisioterapeuta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (this.nFisioterapeuta.id > 0 && this.parametroVisualizar == false)
                    {
                        //Obtendo id
                        tempFisioterapeuta.id = this.nFisioterapeuta.id;
                        //Atualizando o fisioterapeuta
                        if (this.daoFisioterapeuta.alterar(tempFisioterapeuta))
                        {
                            //Mensagem
                            MessageBox.Show("Fisioterapeuta alterado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Direcionando para tela principal
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar o fisioterapeuta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Este método hábilita todos controles, se o pâmetro for True
        /// e se for False desabilita
        /// </summary>
        /// <param name="habilitaDesabilita">True ou False</param>
        private void habilitaEDesabilitaCampos(Boolean habilitaDesabilita)
        {
            foreach (Control controle in this.gbClinica.Controls)
            {
                if (controle is ComboBox)
                    (controle as ComboBox).Enabled = habilitaDesabilita;
            }

            foreach (Control controle in this.gbInformacoes.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Enabled = habilitaDesabilita;

                if (controle is TextBox)
                    (controle as TextBox).Enabled = habilitaDesabilita;

                if (controle is ComboBox)
                    (controle as ComboBox).Enabled = habilitaDesabilita;
            }
            foreach (Control controle in this.gbEndereco.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Enabled = habilitaDesabilita;

                if (controle is TextBox)
                    (controle as TextBox).Enabled = habilitaDesabilita;

                if (controle is ComboBox)
                    (controle as ComboBox).Enabled = habilitaDesabilita;
            }
            foreach (Control controle in this.gbContato.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Enabled = habilitaDesabilita;

                if (controle is TextBox)
                    (controle as TextBox).Enabled = habilitaDesabilita;

                if (controle is ComboBox)
                    (controle as ComboBox).Enabled = habilitaDesabilita;
            }
            this.cbClinica.SelectedIndex = -1;
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            Utils valida = new Utils();
            if (this.nFisioterapeuta.id == 0) //Verifica se o usuário está cadastrando.
            {
                if (valida.validaCpf(this.txtCPF.Text)) //Verifica se o CPF é válido.
                {
                    if (daoFisioterapeuta.existeFisioterapeuta(this.txtCPF.Text)) //Verifica se o CPF já está cadastrado.
                    {
                        MessageBox.Show("Este Fisioterapeuta já existe!", "Alerta!", MessageBoxButtons.OK
                            , MessageBoxIcon.Stop);
                        this.txtCPF.Clear();
                        this.txtCPF.Focus();
                        errorProvider1.Clear();
                    }
                    else
                    {
                        errorProvider1.Clear();
                        this.habilitaEDesabilitaCampos(true);
                        this.txtCPF.Enabled = false;
                        this.cbClinica.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCPF, "CPF inválido!");
                    this.txtCPF.Focus();
                }
            }
            else
            {
                if (valida.validaCpf(this.txtCPF.Text)) //Verifica se o CPF é válido.
                {
                    if (this.txtCPF.Text != this.nFisioterapeuta.cpf) //Verifica se o CPF digitado ainda é o mesmo.
                    {
                        if (daoFisioterapeuta.existeFisioterapeuta(this.txtCPF.Text))  //Verifica se o CPF já está cadastrado.
                        {
                            MessageBox.Show("Este fisioterapeuta já existe!", "Alerta!", MessageBoxButtons.OK
                               , MessageBoxIcon.Stop);
                            this.txtCPF.Clear();
                            this.txtCPF.Focus();
                            errorProvider1.Clear();
                        }
                        else
                        {
                            errorProvider1.Clear();
                            this.cbClinica.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.Clear();
                        this.cbClinica.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCPF, "CPF inválido!");
                    this.txtCPF.Focus();
                }
            }
        }

        private void txtCPF_Enter(object sender, EventArgs e)
        {
            if (this.nFisioterapeuta.id > 0 && this.parametroVisualizar == false)
            {
                this.habilitaEDesabilitaCampos(true);
                this.txtCPF.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaControles();
            this.Close();
        }
    }
}
