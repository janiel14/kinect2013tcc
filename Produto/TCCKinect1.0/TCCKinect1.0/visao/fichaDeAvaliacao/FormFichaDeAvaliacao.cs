using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCCKinect1._0.util;
using TCCKinect1._0.modelo;
using TCCKinect1._0.dao;

namespace TCCKinect1._0.visao.fichaDeAvaliacao
{
    public partial class FormFichaDeAvaliacao : TCCKinect1._0.visao.cadastrosBase.FormBase
    {
        //Globais
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private FichaDeAvaliacao nFichaDeAvaliacao = null;
        private FichaDeAvaliacaoDAO daoFichaDeAvaliacao = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessão</param>
        public FormFichaDeAvaliacao(Object sessao)
        {
            //Globais
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.daoFichaDeAvaliacao= new FichaDeAvaliacaoDAO(this.nSessao.connMysql);
            InitializeComponent();
        }

        /// <summary>
        /// Este método configura o DataGrid, colunas e linhas
        /// </summary>
        private void configuraDataGrid()
        {
            //Definir a altura do cabeçalho
            this.dgDados.RowHeadersWidth = 25;
            this.dgDados.ColumnHeadersHeight = 30;

            //Configura o alinhamento das colunas
            this.dgDados.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Alinha cabeçalho do data grid
            this.dgDados.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Definir largura das colunas
            this.dgDados.Columns[2].Width = 311;
            this.dgDados.Columns[3].Width = 151;
            this.dgDados.Columns[4].Width = 151;
            this.dgDados.Columns[6].Width = 151;
            this.dgDados.AllowUserToResizeColumns = false; //Fixa a largura da coluna            
            this.dgDados.AllowUserToResizeRows = false; //Fixa a altura da linha            

            this.dgDados.Columns[0].Visible = false;
            this.dgDados.Columns[1].Visible = false;
            this.dgDados.Columns[5].Visible = false;
            this.dgDados.Columns[7].Visible = false;
            this.dgDados.Columns[8].Visible = false;
            this.dgDados.Columns[9].Visible = false;
        }

        private void preencheGrid()
        {
            //Tratamento de erros
            try
            {
                //Obtendo dados
                this.dgDados.DataSource = this.daoFichaDeAvaliacao.getDataTable();
                this.configuraDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[6].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        //Obtendo dados da ficha de avaliacao
                        this.nFichaDeAvaliacao = new FichaDeAvaliacao();

                        Paciente pacienteTemp = new Paciente();
                        this.nFichaDeAvaliacao.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        pacienteTemp.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nFichaDeAvaliacao.paciente = pacienteTemp;
                        this.nFichaDeAvaliacao.dataDaAvaliacao = 
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[3].Value.ToString());
                        this.nFichaDeAvaliacao.dataProxAvaliacao = 
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[4].Value.ToString());
                        this.nFichaDeAvaliacao.diasDeAula = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nFichaDeAvaliacao.dataDeVencimento = 
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[6].Value.ToString());
                        this.nFichaDeAvaliacao.diagnostico = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nFichaDeAvaliacao.objetivo = this.dgDados.CurrentRow.Cells[8].Value.ToString();
                        this.nFichaDeAvaliacao.conduta = this.dgDados.CurrentRow.Cells[9].Value.ToString();

                        //Ocultando colunas
                        this.dgDados.Columns[0].Visible = false;
                        this.dgDados.Columns[1].Visible = false;

                        //Direcionando
                        FormFichaDeAvaliacaoCadastro form = new FormFichaDeAvaliacaoCadastro(this.nSessao, this.nFichaDeAvaliacao.id, false, this.nFichaDeAvaliacao);
                        form.ShowDialog(this);
                        this.preencheGrid();
                    }
                    //Atualiza grid
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a ficha de avaliação que deseja alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há ficha de avaliação cadastradas para alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Alterar();
        }

        public override void Cadastrar()
        {
            this.txtPesquisa.Clear();
            //Direcionando para tela de cadastro
            FormFichaDeAvaliacaoCadastro form = new FormFichaDeAvaliacaoCadastro(this.nSessao, 0, false, null);
            form.ShowDialog();
            //Atualiza grid
            this.preencheGrid();
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
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[6].Selected)
                {
                    //Pergunta qual a clinica deseja excluir
                    DialogResult dr = MessageBox.Show("Deseja realmente excluir esta ficha de avaliação?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Verifica decisão
                    if (dr == DialogResult.Yes)
                    {
                        //Tratamento de erros
                        try
                        {
                            //Excluindo
                            if (this.daoFichaDeAvaliacao.excluir(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                //Preenche grid
                                this.preencheGrid();

                                //Avisa
                                MessageBox.Show("Ficha de avaliação excluida com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível excluir a ficha de avaliação!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Selecione a ficha de avaliação que deseja excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há ficha de avaliação cadastradas para excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[6].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        //Obtendo dados da ficha de avaliacao
                        this.nFichaDeAvaliacao = new FichaDeAvaliacao();

                        Paciente pacienteTemp = new Paciente();
                        this.nFichaDeAvaliacao.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        pacienteTemp.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nFichaDeAvaliacao.paciente = pacienteTemp;
                        this.nFichaDeAvaliacao.dataDaAvaliacao =
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[3].Value.ToString());
                        this.nFichaDeAvaliacao.dataProxAvaliacao =
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[4].Value.ToString());
                        this.nFichaDeAvaliacao.diasDeAula = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nFichaDeAvaliacao.dataDeVencimento =
                            Convert.ToDateTime(this.dgDados.CurrentRow.Cells[6].Value.ToString());
                        this.nFichaDeAvaliacao.diagnostico = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nFichaDeAvaliacao.objetivo = this.dgDados.CurrentRow.Cells[8].Value.ToString();
                        this.nFichaDeAvaliacao.conduta = this.dgDados.CurrentRow.Cells[9].Value.ToString();

                        //Direcionando
                        FormFichaDeAvaliacaoCadastro form = new FormFichaDeAvaliacaoCadastro(this.nSessao, this.nFichaDeAvaliacao.id, true, this.nFichaDeAvaliacao);
                        form.ShowDialog(this);
                        this.preencheGrid();
                    }
                    //Atualiza grid
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a ficha de avaliação que deseja visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há ficha de avaliação cadastradas para visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Alterar();
        }

        private void FormFichaDeAvaliacao_Enter(object sender, EventArgs e)
        {
            this.preencheGrid();
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

                if (this.cbFiltro.Text.Equals("Paciente"))
                {
                    filtro = "paciente.nome";
                }

                //Tratamento de erros
                try
                {
                    //Obtendo dados
                    this.dgDados.DataSource = this.daoFichaDeAvaliacao.getDataTable(filtro, this.txtPesquisa.Text);
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
