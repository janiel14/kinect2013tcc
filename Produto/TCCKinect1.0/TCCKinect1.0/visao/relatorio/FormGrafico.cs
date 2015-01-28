using Microsoft.Reporting.WinForms;
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
using TCCKinect1._0.modelo;
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao.relatorio
{
    public partial class FormGrafico : Form
    {
        //Globais
        private Sessao nSessao = null;
        private String sqlMembro = null;
        private String sqlCorpo = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao"></param>
        /// <param name="paciente"></param>
        /// <param name="dataHoraDaSessao"></param>
        /// <param name="membroTitulo"></param>
        /// <param name="sqlMembro"></param>
        public FormGrafico(object sessao, String paciente, String dataHoraDaSessao, String membroTitulo, String sqlMembro, String sqlCorpo)
        {
            InitializeComponent();
            //Report View Parametros
            this.nSessao = (Sessao)sessao;
            this.sqlMembro = sqlMembro;
            this.sqlCorpo = sqlCorpo;
            this.rvGrafico.LocalReport.SetParameters(new ReportParameter("rpClinica", this.nSessao.clinica));
            this.rvGrafico.LocalReport.SetParameters(new ReportParameter("rpPaciente", paciente));
            this.rvGrafico.LocalReport.SetParameters(new ReportParameter("rpSessao", dataHoraDaSessao));
            this.rvGrafico.LocalReport.SetParameters(new ReportParameter("rpMembro1", membroTitulo));
        }

        /// <summary>
        /// Evento de carregamento do relatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGrafico_Load(object sender, EventArgs e)
        {
            //Preenchedados
            this.getDataSet();
            //Atualiza dados
            this.rvGrafico.RefreshReport();
        }

        /// <summary>
        /// Obtem dados
        /// </summary>
        private void getDataSet()
        {
            //Variaveis
            MySqlConnection Conexao = this.nSessao.connMysql;
            Conexao.Open(); //Abre Conexão
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            MySqlCommand Comando = Conexao.CreateCommand();
            Comando.Transaction = Transacao;
            Comando.Connection = Conexao;

            //Processo
            try
            {
                //Instancia Report View
                Comando.CommandText = this.sqlMembro;
                MySqlDataAdapter DataMembro1= new MySqlDataAdapter(Comando);
                DataTable TabMembro1 = new DataTable();
                DataMembro1.Fill(TabMembro1);
                ReportDataSource membro1 = new ReportDataSource("Membro1", TabMembro1);

                //Instancia Report View
                Comando.CommandText = this.sqlCorpo;
                MySqlDataAdapter DataCorpo = new MySqlDataAdapter(Comando);
                DataTable TabCorpo = new DataTable();
                DataCorpo.Fill(TabCorpo);
                ReportDataSource corpo = new ReportDataSource("Corpo", TabCorpo);

                //Adicionando relatórios
                this.rvGrafico.LocalReport.DataSources.Add(membro1);
                this.rvGrafico.LocalReport.DataSources.Add(corpo);
                //Transacao
                Transacao.Commit();
            }
            catch (MySqlException ErroMysql)
            {
                //RollBack
                Transacao.Rollback();
                MessageBox.Show(ErroMysql.Message, "ERRO MYSQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Conexao.Close();
            }
        }
    }
}
