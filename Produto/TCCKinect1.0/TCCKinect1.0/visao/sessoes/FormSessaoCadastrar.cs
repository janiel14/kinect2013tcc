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
using TCCKinect1._0.visao.fisioterapeuta;
using TCCKinect1._0.visao.paciente;

namespace TCCKinect1._0.visao.sessoes
{
    public partial class FormSessaoCadastrar : Form
    {
        private Boolean paramentroVisualizar;
        private Sessao nSessao = null;
        private Utils nUtils = null;
        private PacienteDAO pacienteDAO = null;
        private Paciente nPaciente = null;
        private ClinicaDAO clinicaDAO = null;
        private Clinica nClinica = null;
        private FisioterapeutaDAO fisioterapeutaDAO = null;
        private Fisioterapeuta nFisioterapeuta = null;
        private SessoesDAO sessoesDAO = null;
        private Sessoes nSessoes = null;

        public FormSessaoCadastrar(Object sessao, int id, Boolean visualizar, object objSessoes)
        {
            InitializeComponent();
            this.paramentroVisualizar = visualizar;
            this.nUtils = new Utils();
            this.nSessao = (Sessao)sessao;
            this.pacienteDAO = new PacienteDAO(nSessao.connMysql);
            this.nPaciente = new Paciente();
            this.clinicaDAO = new ClinicaDAO(nSessao.connMysql);
            this.nClinica = new Clinica();
            this.fisioterapeutaDAO = new FisioterapeutaDAO(nSessao.connMysql);
            this.nFisioterapeuta = new Fisioterapeuta();
            this.sessoesDAO = new SessoesDAO(nSessao.connMysql);
            this.nSessoes = new Sessoes();
            this.nSessoes.id = id;
            if (objSessoes != null)
            {
                this.nSessoes = (Sessoes)objSessoes;
            }
            if(id == 0)
            {
                this.mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.mtxtHora.Text = DateTime.Now.ToString("HH:mm");
            }
        }

        /// <summary>
        /// Verifica se os campos obrigatórios estão preenchidos.
        /// </summary>
        /// <returns>True se os campos estão preenchido e false se não estiverem.</returns>
        public Boolean verificaCampos()
        {
            DateTime data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime hora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                DateTime.Now.Hour, DateTime.Now.Minute, 0);
            Boolean retorno = true;

            if (this.mtxtData.Text.Length == 10 && Convert.ToDateTime(this.mtxtData.Text) < data)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(mtxtData, "Data anterior a atual.");
                this.mtxtData.Focus();
                retorno = false;
            } 
            else if(this.nUtils.validaData(this.mtxtData.Text) == false)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(mtxtData, "Data Inválida.");
                this.mtxtData.Focus();
                retorno = false;
            } 
            else if (this.mtxtHora.Text.Replace(":", "").Trim().Length < 4)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(mtxtHora, "Hora inválida.");
                this.mtxtHora.Focus();
                retorno = false;
            }
            else if (this.mtxtData.Text.Length == 10 && Convert.ToDateTime(this.mtxtData.Text) == data
            && Convert.ToDateTime(this.mtxtHora.Text) < hora)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(mtxtHora, "Hora anterior a atual.");
                this.mtxtHora.Focus();
                retorno = false;
            } 
            else if (this.cbClinica.SelectedIndex == -1)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(cbClinica, "Selecione a clínica da presente sessão.");
                this.cbClinica.Focus();
                retorno = false;
            }
            else if (this.cbFisioterapeuta.SelectedIndex == -1)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(cbFisioterapeuta, "Selecione o fisioterapeuta da sessão.");
                this.cbFisioterapeuta.Focus();
                retorno = false;
            }
            else if (this.cbPaciente.SelectedIndex == -1)
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(cbPaciente, "Selecione o paciente da sessão.");
                this.cbPaciente.Focus();
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Preenche os combo box clinica
        /// </summary>
        private void preencheComboBoxClinica()
        {
            //Tratamento de erros
            try
            {
                //Obtendo data table para o comboBox Clinica
                this.cbClinica.DataSource = this.clinicaDAO.getDataTable();
                this.cbClinica.DisplayMember = "Nome Fantasia";
                this.cbClinica.ValueMember = "ID";
                this.cbClinica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Preenche os combo box fisioterapeuta
        /// </summary>
        private void preencheComboBoxFisioterapeuta()
        {
            //Tratamento de erros
            try
            {
                //Obtendo data table para o camboBox Fisioterapeuta
                this.cbFisioterapeuta.DataSource = this.fisioterapeutaDAO.getDataTable();
                this.cbFisioterapeuta.DisplayMember = "NOME";
                this.cbFisioterapeuta.ValueMember = "ID";
                this.cbFisioterapeuta.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Preenche os combo box paciente
        /// </summary>
        private void preencheComboBoxPaciente()
        {
            //Tratamento de erros
            try
            {
                //Obtendo data table para o comboBox Paciente
                this.cbPaciente.DataSource = this.pacienteDAO.getDataTable();
                this.cbPaciente.DisplayMember = "NOME";
                this.cbPaciente.ValueMember = "ID";
                this.cbPaciente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSessaoCadastrar_Load(object sender, EventArgs e)
        {
            try
            {
                this.preencheComboBoxClinica();
                this.preencheComboBoxFisioterapeuta();
                this.preencheComboBoxPaciente();
                if (this.nSessoes.id > 0)
                {
                    if (this.paramentroVisualizar == true)
                    {
                        this.habilitaDesabilitaCampos(false);
                        this.btnSalvar.Visible = false;
                    }
                    this.mtxtData.Text = this.nSessoes.data.ToString();
                    this.mtxtHora.Text = this.nSessoes.hora.ToString("HH:mm");
                    this.cbClinica.SelectedValue = this.nSessoes.clinica.id;
                    this.cbFisioterapeuta.SelectedValue = this.nSessoes.fisioterapeuta.id;
                    this.cbPaciente.SelectedValue = this.nSessoes.paciente.id;
                    this.txaObservacao.Text = this.nSessoes.observacao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Verifica se os campos estão preenchidos
            if(this.verificaCampos())
            {
                try
                {
                    this.errorProvider1.Clear();//Limpa todos os ícones de erros.
                    this.nClinica.id = Convert.ToInt32(this.cbClinica.SelectedValue.ToString());
                    this.nSessoes.clinica = this.nClinica;
                    this.nFisioterapeuta.id = Convert.ToInt32(this.cbFisioterapeuta.SelectedValue.ToString());
                    this.nSessoes.fisioterapeuta = this.nFisioterapeuta;
                    this.nPaciente.id = Convert.ToInt32(this.cbPaciente.SelectedValue.ToString());
                    this.nSessoes.paciente = this.nPaciente;
                    this.nSessoes.data = Convert.ToDateTime(this.mtxtData.Text.ToString());
                    this.nSessoes.hora = Convert.ToDateTime(this.mtxtHora.Text.ToString());
                    this.nSessoes.observacao = this.txaObservacao.Text;
                    this.nSessoes.situacao = "Aguardando";

                    if (this.nSessoes.id == 0)
                    {
                        if (this.sessoesDAO.cadastrar(this.nSessoes))
                        {
                            DialogResult ds = MessageBox.Show("Sessão cadastrada com sucesso! \n Deseja cadastrar outra sessão?", "Aviso",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ds == DialogResult.Yes)
                            {
                                this.limpaControles();
                                this.mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                                this.mtxtHora.Text = DateTime.Now.ToString("HH:mm");
                            }
                            else
                            {
                                this.Close();
                            }
                        }

                        else
                        {
                            DialogResult ds = MessageBox.Show("Sessão não cadastrada!", "Aviso!",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }
                    else if (this.nPaciente.id > 0)
                    {
                        if (this.sessoesDAO.alterar(this.nSessoes))
                        {
                            DialogResult ds = MessageBox.Show("Sessão alterada com sucesso!", "Aviso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                        else
                        {
                            DialogResult ds = MessageBox.Show("Sessão não Alterada!", "Aviso!",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Habilita e desabilita todos os campos do formulário.
        /// </summary>
        private void habilitaDesabilitaCampos(Boolean habilitaDesabilita)
        {
            foreach (Control controle in this.gbDataHora.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Enabled = habilitaDesabilita;
            }
            foreach (Control controle in this.gbInformacoes.Controls)
            {
                if (controle is ComboBox)
                    (controle as ComboBox).Enabled = habilitaDesabilita;
                
                if (controle is LinkLabel)
                    (controle as LinkLabel).Enabled = habilitaDesabilita;
            }
            this.txaObservacao.Enabled = habilitaDesabilita;
        }

        /// <summary>
        /// Limpa todos os campos do formulário.
        /// </summary>
        private void limpaControles()
        {
            foreach (Control controle in this.gbDataHora.Controls)
            {
                if (controle is MaskedTextBox)
                    (controle as MaskedTextBox).Text = null;
            }
            foreach (Control controle in this.gbInformacoes.Controls)
            {
                if (controle is ComboBox)
                    (controle as ComboBox).SelectedIndex = -1;
            }
            this.txaObservacao.Text = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpaControles();
            this.Close();
        }

        private void linkPaciente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPacienteCadastro form = new FormPacienteCadastro(this.nSessao, 0, false, null);
            if (form.ShowDialog() != DialogResult.OK)
            {
                this.preencheComboBoxPaciente();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormFisioterapeutaCadastro form = new FormFisioterapeutaCadastro(this.nSessao, 0, false, null);
            if (form.ShowDialog() != DialogResult.OK)
            {
                this.preencheComboBoxFisioterapeuta();
            }
        }

        private void linkLblClinica_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormClinicaCadastro form = new FormClinicaCadastro(this.nSessao, 0, false, null);
            if (form.ShowDialog() != DialogResult.OK)
            {
                this.preencheComboBoxClinica();
            }
        }
    }
}
