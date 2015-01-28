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
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao.relatorio
{
    public partial class FormRelatorioGrafico : Form
    {
        //Globais
        private Sessao nSessao = null;
        private PacienteDAO daoPaciente = null;
        private SessoesDAO daoSessao = null;
        private List<String> listaMembro = new List<string>();

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao"></param>
        public FormRelatorioGrafico(object sessao)
        {
            InitializeComponent();
            this.nSessao = (Sessao)sessao;
            this.daoPaciente = new PacienteDAO(this.nSessao.connMysql);
            this.daoSessao = new SessoesDAO(this.nSessao.connMysql);
            //Tratamento de erros
            try
            {
                //Obtendo dados de pacientes
                this.cbPaciente.DataSource = this.daoPaciente.getDataTable();
                this.cbPaciente.DisplayMember = "NOME";
                this.cbPaciente.ValueMember = "ID";
                this.cbPaciente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento ao selecionar paciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPaciente_DropDownClosed(object sender, EventArgs e)
        {
            //Verifica seleciona
            if (this.cbPaciente.SelectedIndex > -1)
            {
                //Tratamento de erros
                try
                {
                    //Obtendo sessões
                    this.cbSessao.DataSource = this.daoSessao.getDataTable(Convert.ToInt32(this.cbPaciente.SelectedValue.ToString()));
                    this.cbSessao.DisplayMember = "SESSAO";
                    this.cbSessao.ValueMember = "ID";
                    this.cbSessao.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Evento para geração do relatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGerar_Click(object sender, EventArgs e)
        {
            //Validação
            if (this.cbPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o paciente!","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.cbPaciente.Focus();
            }
            else if (this.cbSessao.SelectedIndex == -1)
            {
                MessageBox.Show("Informe a sessão!","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.cbSessao.Focus();
            }
            else if (this.listaMembro.Count == 0)
            {
                MessageBox.Show("Selecione um membro!","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.chListJuntas.Focus();
            }
            else
            {
                //Tratamento de erros
                try
                {
                    //Obtendo dados
                    String sqlCorpo = "SELECT * FROM body WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    //Abrindo gráfico
                    FormGrafico form = new FormGrafico(this.nSessao, this.cbPaciente.Text,
                        this.cbSessao.Text, this.listaMembro[0].ToString(), this.getSql(), sqlCorpo);
                    form.Show(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Evento ao selecionar item na ista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chListJuntas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                //Verifica há itens na lista
                if (this.listaMembro.Count > 0)
                {
                    //Desmarcando anteriores
                    for (int i = 0; i < this.chListJuntas.Items.Count; i++)
                    {
                        //Desmarcando
                        this.chListJuntas.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    //Marcando a atual
                    this.listaMembro.Add(this.chListJuntas.SelectedItem.ToString());
                }
                else
                {
                    //Adiciona a lista
                    this.listaMembro.Add(this.chListJuntas.SelectedItem.ToString());
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                //Remove da lista
                this.listaMembro.Clear();
            }
        }
        /// <summary>
        /// Verifica qual será a consulta e retorno sqlMembro
        /// </summary>
        /// <returns></returns>
        public String getSql()
        { 
            //Variaveis
            String sql = null;
            //Verifica qual membro foi selecionado
            switch (this.listaMembro[0].ToString())
            {
                case "Cabeça":
                    sql = "SELECT * FROM head WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Ombro centro":
                    sql = "SELECT * FROM shoulder_center WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Ombro direito":
                    sql = "SELECT * FROM shoulder_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Cotovelo direito":
                    sql = "SELECT * FROM elbow_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Pulso direito":
                    sql = "SELECT * FROM wrist_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Mão direita":
                    sql = "SELECT * FROM hand_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Ombro esquerdo":
                    sql = "SELECT * FROM shoulder_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Cotovelo esquerdo":
                    sql = "SELECT * FROM elbow_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Pulso esquerdo":
                    sql = "SELECT * FROM wrist_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Mão esquerda":
                    sql = "SELECT * FROM hand_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Coluna":
                    sql = "SELECT * FROM spine WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Quadril centro":
                    sql = "SELECT * FROM hip_center WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Quadril direito":
                    sql = "SELECT * FROM hip_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Joelho direito":
                    sql = "SELECT * FROM knee_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Tornozelo direito":
                    sql = "SELECT * FROM ankle_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Pé direito":
                    sql = "SELECT * FROM foot_right WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Quadril esquerdo":
                    sql = "SELECT * FROM hip_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Joelho esquerdo":
                    sql = "SELECT * FROM knee_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Tornozelo esquerdo":
                    sql = "SELECT * FROM ankle_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                case "Pé esquerdo":
                    sql = "SELECT * FROM foot_left WHERE sessao_id=" + this.cbSessao.SelectedValue.ToString() + " ORDER BY id ASC";
                    break;
                default:
                    break;
            }
            //Retorno 
            return sql;
        }
    }
}
