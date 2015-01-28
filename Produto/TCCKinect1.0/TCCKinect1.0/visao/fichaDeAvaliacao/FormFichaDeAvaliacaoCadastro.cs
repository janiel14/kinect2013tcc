using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCCKinect1._0.util;
using TCCKinect1._0.modelo;
using TCCKinect1._0.dao;

namespace TCCKinect1._0.visao.fichaDeAvaliacao
{
    public partial class FormFichaDeAvaliacaoCadastro : Form
    {
        //Globais
        private Boolean parametroVisualizar = false;
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private FichaDeAvaliacao nFichaDeAvaliacao;
        private FichaDeAvaliacaoDAO daoFichaDeAvaliacao;
        private Paciente nPaciente = null;
        private PacienteDAO daoPaciente = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessão</param>
        /// <param name="id">Identificação do cadastro</param>
        /// <param name="Visualizar">Boolean Visualizar</param>
        /// <param name="objCliente">Objeto com dados da ficha de avaliacao/param>
        public FormFichaDeAvaliacaoCadastro(Object sessao, int id, Boolean visualizar, object objFichaDeAvaliacao)
        {
            InitializeComponent();
            //Globais
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.nFichaDeAvaliacao = new FichaDeAvaliacao();
            this.nFichaDeAvaliacao.id = id;
            this.daoPaciente = new PacienteDAO(this.nSessao.connMysql);
            this.daoFichaDeAvaliacao = new FichaDeAvaliacaoDAO(this.nSessao.connMysql);
            this.txtDataAvaliacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.nPaciente = new Paciente();
            this.parametroVisualizar = visualizar;
            //Checando objeto cliente
            if (objFichaDeAvaliacao!= null)
            {
                this.nFichaDeAvaliacao = (FichaDeAvaliacao)objFichaDeAvaliacao;
            }
        }

        /// <summary>
        /// Preenche combo box Paciente
        /// </summary>
        private void preencheComboBoxPaciente()
        {
            //Tratamento de erros
            try
            {
                //Obtendo data table
                this.cbPaciente.DataSource = this.daoPaciente.getDataTable();
                this.cbPaciente.DisplayMember = "NOME";
                this.cbPaciente.ValueMember = "ID";
                this.cbPaciente.SelectedIndex = -1;
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
            }
        }

        /// <summary>
        /// Habilita ou desabilita todos os campos
        /// </summary>
        private void habilitaDesabilitaCampos(Boolean habilitaDesabilita)
        {
            foreach (Control ctl in this.gbInformacoes.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Enabled = habilitaDesabilita;

                if (ctl is ComboBox)
                    (ctl as ComboBox).Enabled = habilitaDesabilita;

                if (ctl is ListBox)
                    (ctl as ListBox).Enabled = habilitaDesabilita;

                if (ctl is CheckBox)
                    (ctl as CheckBox).Enabled = habilitaDesabilita;

                if (ctl is RadioButton)
                    (ctl as RadioButton).Enabled = habilitaDesabilita;

                if (ctl is MaskedTextBox)
                    (ctl as MaskedTextBox).Enabled = habilitaDesabilita;
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
                if (this.cbPaciente.SelectedIndex == -1)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cbPaciente, "Informe o paciente da ficha de avaliação!");
                    this.cbPaciente.Focus();

                }
                else if (nUtil.validaData(this.txtDataAvaliacao.Text)== false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDataAvaliacao, "Data inválida!");
                    this.txtDataAvaliacao.Focus();
                }
                else if (nUtil.validaData(this.txtDataVencimento.Text)== false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDataVencimento, "Data inválida!");
                    this.txtDataVencimento.Focus();
                }
                else if (this.txtDataProximaAvaliacao.Text.Replace("/","").Trim().Length > 0 && 
                    this.nUtil.validaData(this.txtDataProximaAvaliacao.Text) == false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDataProximaAvaliacao, "Data inválida!");
                    this.txtDataProximaAvaliacao.Focus();
                }
                else if (this.txtDiagnostico.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDiagnostico, "Informe os dados do diagnostico do paciente!");
                    this.txtDiagnostico.Focus();
                }
                else if (this.txtObjetivo.Text.Length == 0 )
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtObjetivo, "Informe os objetivos do tratamento!");
                    this.txtObjetivo.Focus();
                }
                else if (this.txtConduta.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtConduta, "Informe a conduta do paciente!");
                    this.txtConduta.Focus();
                }                
                else
                {
                    errorProvider1.Clear();
                    //Obtendo dados
                    FichaDeAvaliacao tempFichaDeAvaliacao = new FichaDeAvaliacao();

                    this.nPaciente.id = Convert.ToInt32(this.cbPaciente.SelectedValue.ToString());
                    tempFichaDeAvaliacao.paciente = this.nPaciente;
                    tempFichaDeAvaliacao.dataDaAvaliacao = Convert.ToDateTime(this.txtDataAvaliacao.Text);
                    if (this.txtDataProximaAvaliacao.Text.Replace("/", "").Trim().Length == 0)
                    {
                        tempFichaDeAvaliacao.dataProxAvaliacao = Convert.ToDateTime(null);
                    }
                    else
                    {
                        tempFichaDeAvaliacao.dataProxAvaliacao = Convert.ToDateTime(this.txtDataProximaAvaliacao.Text);
                    }
                    tempFichaDeAvaliacao.diasDeAula = this.txtDiasDeAula.Text;
                    tempFichaDeAvaliacao.dataDeVencimento = Convert.ToDateTime(this.txtDataVencimento.Text);
                    tempFichaDeAvaliacao.diagnostico = this.txtDiagnostico.Text;
                    tempFichaDeAvaliacao.objetivo = this.txtObjetivo.Text;
                    tempFichaDeAvaliacao.conduta = this.txtConduta.Text;

                    //Verificando falsh salvar
                    if (this.nFichaDeAvaliacao.id == 0 && this.parametroVisualizar == false)
                    {
                        //Salvando
                        if (this.daoFichaDeAvaliacao.cadastrar(tempFichaDeAvaliacao))
                        {

                            //Mensagem
                            MessageBox.Show("Ficha de avaliação cadastrada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Questiona usuário se deseja cadastrar outro
                            DialogResult dr = MessageBox.Show("Deseja cadastrar outra ficha de avaliação?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            //Verifica decisão
                            if (dr == DialogResult.Yes)
                            {
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
                            MessageBox.Show("Não foi possível cadastrar a ficha de avaliação!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (this.nFichaDeAvaliacao.id > 0 && this.parametroVisualizar == false)
                    {
                        //Obtendo id
                        tempFichaDeAvaliacao.id = this.nFichaDeAvaliacao.id;
                        //Atualizando o fisioterapeuta
                        if (this.daoFichaDeAvaliacao.alterar(tempFichaDeAvaliacao))
                        {
                            //Mensagem
                            MessageBox.Show("Ficha de avaliação alterada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Direcionando para tela principal
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar a ficha de avaliação!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormFichaDeAvaliacaoCadastro_Load(object sender, EventArgs e)
        {
            //Tratamento de erros
            try
            {
                this.preencheComboBoxPaciente();
                //Verificando se há identificação do cadastro
                if (this.nFichaDeAvaliacao.id > 0)
                {
                    this.cbPaciente.SelectedValue = this.nFichaDeAvaliacao.paciente.id;
                    this.txtDataAvaliacao.Text = this.nFichaDeAvaliacao.dataDaAvaliacao.ToString();
                    if (!this.nFichaDeAvaliacao.dataProxAvaliacao.Equals("01/01/0001"))
                    {
                    }
                    else
                    {
                        this.txtDataProximaAvaliacao.Text = this.nFichaDeAvaliacao.dataProxAvaliacao.ToString();
                    }
                    this.txtDiasDeAula.Text = this.nFichaDeAvaliacao.diasDeAula;
                    this.txtDataVencimento.Text = this.nFichaDeAvaliacao.dataDeVencimento.ToString();
                    this.txtDiagnostico.Text = this.nFichaDeAvaliacao.diagnostico;
                    this.txtObjetivo.Text = this.nFichaDeAvaliacao.objetivo;
                    this.txtConduta.Text = this.nFichaDeAvaliacao.conduta;
                   
                    //Checando parametro visualizar
                    if (this.parametroVisualizar == true)
                    {
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.LimpaControles();
            this.Close();
        }




    }
}
