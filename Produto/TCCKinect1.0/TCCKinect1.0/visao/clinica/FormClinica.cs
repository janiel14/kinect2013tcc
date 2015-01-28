using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCCKinect1._0.dao;
using TCCKinect1._0.modelo;
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao
{
    public partial class FormClinica : TCCKinect1._0.visao.cadastrosBase.FormBase
    {
        //Globais
        private Sessao nSessao = null;
        private MySqlConnection conn = null;
        private Utils nUtil = null;
        private Clinica nClinica = null;
        private ClinicaDAO daoClinica = null;

        public FormClinica(Object conn)
        {
            this.conn = (MySqlConnection)conn;
            InitializeComponent();
            this.daoClinica = new ClinicaDAO(this.conn);
            this.nUtil = new Utils();
            nSessao = new Sessao();
            nSessao.connMysql = (MySqlConnection)conn; //Recebendo string de conexão
        }

        private void configuraDataGrid()
        {
            //Definir a altura do cabeçalho
            this.dgDados.RowHeadersWidth = 25;
            this.dgDados.ColumnHeadersHeight = 30;

            //Alinha cabeçalho do data grid
            this.dgDados.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Configurando colunas
            this.dgDados.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //Definir largura das colunas
            this.dgDados.Columns[1].Width = 121;
            this.dgDados.Columns[3].Width = 230;
            this.dgDados.Columns[11].Width = 92;
            this.dgDados.Columns[12].Width = 91;
            this.dgDados.Columns[13].Width = 230;
            this.dgDados.AllowUserToResizeColumns = false; //Fixa a largura da coluna            
            this.dgDados.AllowUserToResizeRows = false; //Fixa a altura da linha

            //Ocultando colunas
            this.dgDados.Columns[0].Visible = false;
            this.dgDados.Columns[2].Visible = false;
            this.dgDados.Columns[4].Visible = false;
            this.dgDados.Columns[5].Visible = false;
            this.dgDados.Columns[6].Visible = false;
            this.dgDados.Columns[7].Visible = false;
            this.dgDados.Columns[8].Visible = false;
            this.dgDados.Columns[9].Visible = false;
            this.dgDados.Columns[10].Visible = false;
        }

        private void preencheGrid()
        {
            //Tratamento de erros
            try
            {
                //Obtendo dados
                this.dgDados.DataSource = this.daoClinica.getDataTable();
                this.configuraDataGrid();
                this.dgDados.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherComboPesquisa()
        {
            cbFiltro.Items.Clear();
            DataTable dt = this.daoClinica.getDataTable();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cbFiltro.Items.Add(dt.Columns[i].ColumnName.ToString());
            }
            cbFiltro.Items.Remove(dt.Columns[0].ColumnName.ToString());
        }



        private void FormClinica_Enter(object sender, EventArgs e)
        {
            this.preencheGrid();
            this.dgDados.Focus();
            
        }

        public override void Alterar()
        {
            this.txtPesquisa.Clear();
            //Foca grid
            this.dgDados.Focus();
            //Verifica se há linhas na grid
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica se a linha esta selecionada
                if (this.dgDados.CurrentRow.Cells[1].Selected | this.dgDados.CurrentRow.Cells[3].Selected | 
                    this.dgDados.CurrentRow.Cells[11].Selected | this.dgDados.CurrentRow.Cells[12].Selected | 
                    this.dgDados.CurrentRow.Cells[13].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        //Obtendo dados da clinica
                        this.nClinica = new Clinica(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString()),
                            this.dgDados.CurrentRow.Cells[1].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[2].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[3].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[4].Value.ToString(),
                            this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[5].Value.ToString()),
                            this.dgDados.CurrentRow.Cells[6].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[7].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[8].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[9].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[10].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[11].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[12].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[13].Value.ToString());
                        //Direcionando
                        FormClinicaCadastro form = new FormClinicaCadastro(this.nSessao, this.nClinica.id, false, this.nClinica);
                        form.ShowDialog(this);
                        //Atualiza grid
                        this.preencheGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o clinica que deseja alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há clinicas cadastradas para alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Alterar();
        }

        public override void Cadastrar()
        {
            this.txtPesquisa.Clear();
            //Direcionando para tela de cadastro
            FormClinicaCadastro form = new FormClinicaCadastro(this.nSessao, 0, false, null);
            form.ShowDialog();
            //Atualiza grid
            this.preencheGrid();
            //base.Cadastrar();
        }

        public override void Excluir()
        {
            this.txtPesquisa.Clear();
            //Focando no grid
            this.dgDados.Focus();
            //Verifica se há linhas na grid
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica se a linha esta selecionada
                if (this.dgDados.CurrentRow.Cells[1].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[11].Selected | this.dgDados.CurrentRow.Cells[12].Selected |
                    this.dgDados.CurrentRow.Cells[13].Selected)
                {
                    //Pergunta qual a clinica deseja excluir
                    DialogResult dr = MessageBox.Show("Deseja realmente excluir esta clinica?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Verifica decisão
                    if (dr == DialogResult.Yes)
                    {
                        //Tratamento de erros
                        try
                        {
                            //Excluindo
                            if (this.daoClinica.excluir(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                //Preenche grid
                                this.preencheGrid();

                                //Avisa
                                MessageBox.Show("Clinica excluida com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível excluir clinica!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o clinica que deseja excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há clinicas cadastradas para excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void Visualizar()
        {
            this.txtPesquisa.Clear();
            //Foca grid
            this.dgDados.Focus();
            //Verifica se há linhas na grid
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica se a linha esta selecionada
                if (this.dgDados.CurrentRow.Cells[1].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[11].Selected | this.dgDados.CurrentRow.Cells[12].Selected |
                    this.dgDados.CurrentRow.Cells[13].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        //Obtendo dados da clinica
                        this.nClinica = new Clinica(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString()),
                            this.dgDados.CurrentRow.Cells[1].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[2].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[3].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[4].Value.ToString(),
                            this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[5].Value.ToString()),
                            this.dgDados.CurrentRow.Cells[6].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[7].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[8].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[9].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[10].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[11].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[12].Value.ToString(),
                            this.dgDados.CurrentRow.Cells[13].Value.ToString());
                        //Direcionando
                        FormClinicaCadastro form = new FormClinicaCadastro(this.nSessao, this.nClinica.id, true, this.nClinica);
                        form.ShowDialog(this);
                        //Atualiza grid
                        this.preencheGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o clinica que deseja visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há clinicas cadastradas para visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Visualizar();
        }

        private void FormClinica_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void cbFiltro_DropDownClosed(object sender, EventArgs e)
        {
            //Limpando campo
            this.txtPesquisa.Clear();
            this.txtPesquisa.Focus();
        }

        private void txtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            //Verifica se foi selecionado um filtro
            if (this.cbFiltro.SelectedIndex > -1)
            {
                //Variaveis
                String filtro = null;
                //Verificando filtro selecionado

                if (this.cbFiltro.Text.Equals("CNPJ"))
                {
                    filtro = "clinica.cnpj";
                }

                else if (this.cbFiltro.Text.Equals("Nome Fantasia"))
                {
                    filtro = "clinica.nome_fantasia";
                }

                //Tratamento de erros
                try
                {
                    //Obtendo dados
                    this.dgDados.DataSource = this.daoClinica.getDataTable(filtro, this.txtPesquisa.Text);
                    this.configuraDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione o filtro antes de pesquisar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPesquisa.Clear();
            }
        }


    }
}
