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

namespace TCCKinect1._0.visao.paciente
{
    public partial class FormPacienteCadastro : Form
    {
        private Sessao nSessao = null;
        private Utils utils = null;
        private PacienteDAO pacienteDAO = null;
        private ClinicaDAO clinicaDAO = null;
        private Paciente nPaciente = null;
        private Boolean parametroVisualizar;

        public FormPacienteCadastro(Object sessao, int id, Boolean visualizar, object objPaciente)
        {
            InitializeComponent();
            this.nPaciente = new Paciente();
            this.nPaciente.id = id;
            this.nSessao = (Sessao)sessao;
            this.utils = new Utils();
            this.pacienteDAO = new PacienteDAO(nSessao.connMysql);
            this.parametroVisualizar = visualizar;
            this.clinicaDAO = new ClinicaDAO (nSessao.connMysql);
            if(objPaciente != null)
            {
                this.nPaciente = (Paciente)objPaciente;
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
                this.cbClinica.DataSource = this.clinicaDAO.getDataTable();
                this.cbClinica.DisplayMember = "RAZÃO SOCIAL";
                this.cbClinica.ValueMember = "ID";
                this.cbClinica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPacienteCadastro_Load(object sender, EventArgs e)
        {
            Clinica nClinica;
            //Preencher campos
            try
            {
                //Preenche comboBox Clínica
                this.preencheComboBoxClinica();

                if (this.nPaciente.id > 0)
                {
                    this.btnSalvar.Enabled = true;

                    nClinica = this.nPaciente.clinica;
                    this.cbClinica.SelectedValue = nClinica.id;
                    this.txtCPF.Text = this.nPaciente.cpf;
                    this.txtRG.Text = this.nPaciente.rg;
                    this.cbSexo.SelectedItem = this.nPaciente.sexo;
                    this.txtDataDeNascimento.Text = Convert.ToString(this.nPaciente.dataDeNascimento.ToString()); ;
                    this.txtNome.Text = this.nPaciente.nome;
                    this.cbEstadoCivil.SelectedItem = this.nPaciente.estadoCivil;
                    this.txtProfissao.Text = this.nPaciente.profissao;
                    this.txtLogradouro.Text = this.nPaciente.logradouro;
                    this.txtNumero.Text = Convert.ToString(this.nPaciente.numero);
                    this.txtComplemento.Text = this.nPaciente.complemento;
                    this.txtBairro.Text = this.nPaciente.bairro;
                    this.txtCidade.Text = this.nPaciente.cidade;
                    this.txtCep.Text = this.nPaciente.cep;
                    this.cbUf.SelectedItem = this.nPaciente.uf;
                    this.txtTelefone.Text = this.nPaciente.telefone;
                    this.txtCelular.Text = this.nPaciente.celular;
                    this.txtEmail.Text = this.nPaciente.email;
                    this.txaObservacoes.Text = this.nPaciente.observacao;

                    if(this.parametroVisualizar)
                    {
                        this.txtCPF.Enabled = false;
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
            this.txaObservacoes.Enabled = habilitaDesabilita;
        }

        /// <summary>
        /// Verifica se todos os campos obrigatórios estão preenchidos
        /// </summary>
        private Boolean verificarCampos()
        {
            Boolean retorno = true;
            if (this.cbClinica.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbClinica, "Selecione a clinica do paciente");
                this.cbClinica.Focus();
                retorno = false;
            }
            else if (txtRG.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRG, "Infome o RG do paciente");
                this.txtRG.Focus();
                retorno = false;
            }
            else if (cbSexo.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbSexo, "Selecione o sexo do paciente");
                this.cbSexo.Focus();
                retorno = false;
            }
            else if (this.utils.validaData(txtDataDeNascimento.Text) == false)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDataDeNascimento, "Data de Nascimento Inválida");
                this.txtDataDeNascimento.Focus();
                retorno = false;

            }
            else if (txtNome.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNome, "Informe o nome do paciente");
                this.txtNome.Focus();
                retorno = false;
            }
            else if (cbEstadoCivil.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbEstadoCivil, "Informe o estado civil do paciente");
                this.cbEstadoCivil.Focus();
                retorno = false;
            }
            else if (txtProfissao.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProfissao, "Informe a profissão do paciente");
                this.txtProfissao.Focus();
                retorno = false;
            }
            else if (txtLogradouro.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLogradouro, "Informe o logradouro do paciente");
                this.txtLogradouro.Focus();
                retorno = false;
            }
            else if (txtNumero.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNumero, "Informe o número do logradouro do paciente");
                this.txtNumero.Focus();
                retorno = false;
            }
            else if (txtBairro.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBairro, "Informe o bairro do logradouro do paciente");
                this.txtBairro.Focus();
                retorno = false;
            }
            else if (txtCidade.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCidade, "Informe a cidade do paciente");
                this.txtCidade.Focus();
                retorno = false;
            }
            else if (this.txtCep.Text.Replace(",", "").Replace("-", "").Trim().Length < 9)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCep, "CEP inválido!");
                this.txtCep.Focus();
                retorno = false;
            }
            else if (cbUf.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbUf, "Informe a UF do logradouro do paciente");
                this.cbUf.Focus();
                retorno = false;
            }
            else if (this.txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length > 0 &&
                     this.txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length < 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTelefone, "Telefone inválido!");
                this.txtTelefone.Focus();
                retorno = false;
            }
            else if (this.txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length > 0 &&
                this.txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim().Length < 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCelular, "Celular inválido!");
                this.txtCelular.Focus();
                retorno = false;
            }
            else if (this.txtEmail.Text.Trim().Length > 0 && this.utils.validaEmail(this.txtEmail.Text) == false)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmail, "E-mail inválido!");
                this.txtEmail.Focus();
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Este método limpa todos os campos.
        /// </summary>
        private void limparControles() 
        {
            foreach(Control controle in this.gbInformacoes.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Text = null;

                if (controle is TextBox)
                    (controle as TextBox).Text = null;

                if (controle is ComboBox)
                    (controle as ComboBox).SelectedIndex = -1;
            }
            foreach (Control controle in this.gbEndereco.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Text = null;

                if (controle is TextBox)
                    (controle as TextBox).Text = null;

                if (controle is ComboBox)
                    (controle as ComboBox).SelectedIndex = -1;
            }
            foreach (Control controle in this.gbContato.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Text = null;

                if (controle is TextBox)
                    (controle as TextBox).Text = null;

                if (controle is ComboBox)
                    (controle as ComboBox).SelectedIndex = -1;
            }
            this.txaObservacoes.Text = null;
            this.cbClinica.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limparControles();
            this.Close();    
        }

        /// <summary>
        /// Converte a data no padão YYYY/MM/DD
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String converterTextoEmDate(String data)
        {
            String dataString;
            DateTime date = new DateTime();
            date = Convert.ToDateTime(data);
            dataString = Convert.ToString(date.Year) + "/" + Convert.ToString(date.Month) + "/" + Convert.ToString(date.Day);

            return dataString;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Clinica clinica = new Clinica();
            if (this.verificarCampos())
            {
                try
                {
                    this.errorProvider1.Clear();//Limpa todos os ícones de erros.
                    clinica.id = Convert.ToInt32(this.cbClinica.SelectedValue.ToString());
                    this.nPaciente.clinica = clinica;
                    this.nPaciente.nome = this.txtNome.Text;
                    this.nPaciente.cpf = this.txtCPF.Text;
                    this.nPaciente.rg = this.txtRG.Text;
                    this.nPaciente.sexo = this.cbSexo.Text;
                    this.nPaciente.dataDeNascimento = Convert.ToDateTime(this.converterTextoEmDate(this.txtDataDeNascimento.Text));
                    this.nPaciente.estadoCivil = this.cbEstadoCivil.Text;
                    this.nPaciente.profissao = this.txtProfissao.Text;
                    this.nPaciente.logradouro = this.txtLogradouro.Text;
                    this.nPaciente.numero = Convert.ToInt32(this.txtNumero.Text);
                    this.nPaciente.complemento = this.txtComplemento.Text;
                    this.nPaciente.bairro = this.txtBairro.Text;
                    this.nPaciente.cep = this.txtCep.Text;
                    this.nPaciente.cidade = this.txtCidade.Text;
                    this.nPaciente.uf = this.cbUf.Text;
                    this.nPaciente.telefone = this.txtTelefone.Text;
                    this.nPaciente.celular = this.txtCelular.Text;
                    this.nPaciente.email = this.txtEmail.Text;
                    this.nPaciente.observacao = this.txaObservacoes.Text;
                    this.nPaciente.dataDoCadastro = DateTime.Now;
                    
                    //Se o id for 0 e o parâmetro for false então irá cadastrar,
                    //Se não irá alterar.
                    if (this.nPaciente.id == 0 && this.parametroVisualizar == false)
                    {
                        if (this.pacienteDAO.cadastrar(nPaciente))
                        {
                            DialogResult ds = MessageBox.Show("Paciente cadastrado com sucesso! \n Deseja cadastrar outro paciente?", "Aviso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ds == DialogResult.Yes)
                            {
                                this.txtCPF.Enabled = true;
                                this.limparControles();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            DialogResult ds = MessageBox.Show("Paciente não cadastrado!", "Aviso!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }
                    else if (this.nPaciente.id > 0 && this.parametroVisualizar == false)
                    {
                        if (this.pacienteDAO.alterar(nPaciente))
                        {
                            //Mensagem
                            MessageBox.Show("Paciente alterado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Direcionando para tela principal
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar os dados do paciente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            Utils valida = new Utils();
            if (this.nPaciente.id == 0) //Verifica se o usuário está cadastrando.
            {
                if (valida.validaCpf(this.txtCPF.Text)) //Verifica se o CPF é válido.
                {
                    if (pacienteDAO.existePaciente(this.txtCPF.Text)) //Verifica se o CPF já está cadastrado.
                    {
                        MessageBox.Show("Este paciente já existe!", "Alerta!", MessageBoxButtons.OK
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
                        this.btnSalvar.Enabled = true;
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
                    if (this.txtCPF.Text != this.nPaciente.cpf) //Verifica se o CPF digitado ainda é o mesmo.
                    {
                        if (pacienteDAO.existePaciente(this.txtCPF.Text))  //Verifica se o CPF já está cadastrado.
                        {
                            MessageBox.Show("Este paciente já existe!", "Alerta!", MessageBoxButtons.OK
                               , MessageBoxIcon.Stop);
                            this.txtCPF.Clear();
                            this.txtCPF.Focus();
                            errorProvider1.Clear();   
                        }
                        else
                        {
                            errorProvider1.Clear();
                            this.btnSalvar.Enabled = true;
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
            if (this.nPaciente.id > 0 && this.parametroVisualizar == false)
            {
                this.habilitaEDesabilitaCampos(true);
                this.txtCPF.Enabled = true;
            }
        }
    }
}
