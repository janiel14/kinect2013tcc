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

namespace TCCKinect1._0.visao.sessoes
{
    public partial class FormSessoes : TCCKinect1._0.visao.cadastrosBase.FormBase
    {
        //Globais
        private Sessao nSessao = null;
        private Utils nUtils = null;
        private Sessoes nSessoes = null;
        private SessoesDAO sessoesDao = null;
        private Paciente nPaciente = null;
        private Fisioterapeuta nFisioterapeuta = null;
        private Clinica nClinica = null;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="sessao"></param>
        public FormSessoes(Object sessao)
        {
            InitializeComponent();
            this.nSessao = (Sessao)sessao;
            this.nUtils = new Utils();
            this.sessoesDao = new SessoesDAO(nSessao.connMysql);
            this.nSessoes = new Sessoes();
            this.nPaciente = new Paciente();
            this.nFisioterapeuta = new Fisioterapeuta();
            this.nClinica = new Clinica();
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
            
            this.dgDados.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Alinha cabeçalho do data grid
            this.dgDados.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Definir largura das colunas
            this.dgDados.Columns[4].Width = 225;
            this.dgDados.Columns[5].Width = 225;
            this.dgDados.Columns[6].Width = 225;
            this.dgDados.Columns[7].Width = 89;
            this.dgDados.AllowUserToResizeColumns = false; //Fixa a largura da coluna            
            this.dgDados.AllowUserToResizeRows = false; //Fixa a altura da linha

            //Ocultando colunas. Somente as colunas 1, 2, 3 e 5 que estão visíveis.
            this.dgDados.Columns[0].Visible = false;
            this.dgDados.Columns[1].Visible = false;
            this.dgDados.Columns[2].Visible = false;
            this.dgDados.Columns[3].Visible = false;
            this.dgDados.Columns[8].Visible = false;
            this.dgDados.Columns[9].Visible = false;
            this.dgDados.Columns[10].Visible = false;
        }

        /// <summary>
        /// Preenche o DataGrid
        /// </summary>
        private void preencherGrid()
        {
            //Tratamento de erros
            try
            {
                //Obtento dados da Tabela Fisioterapeuta
                this.dgDados.DataSource = this.sessoesDao.getDataTable();
                this.configuraDataGrid();
                this.dgDados.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSessoes_Enter(object sender, EventArgs e)
        {
            this.preencherGrid();
        }

        /// <summary>
        /// Este método exclui uma sessão.
        /// </summary>
        public override void Excluir()
        {
            this.txtPesquisa.Clear();
            //Foca no grid
            this.dgDados.Focus();
            //Verifica se há linha no data gride
            if (this.dgDados.RowCount > 0)
            {
                //Verifica se há alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected |
                    this.dgDados.CurrentRow.Cells[6].Selected | this.dgDados.CurrentRow.Cells[7].Selected)
                {
                    //Pede confirmação ao usuário 
                    DialogResult dr = MessageBox.Show("Deseja realmente excluir esta sessão?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //Verifica o resultado da confirmação
                    if (dr == DialogResult.Yes)
                    {
                        //Tratamento de exceções
                        try
                        {
                            //Excluindo
                            if (this.sessoesDao.excluir(Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                //Atualizar grid
                                this.preencherGrid();

                                MessageBox.Show("Sessão excluida com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível excluir a sessão!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Nenhuma sessão selecionada!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há sessões cadastradas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void Cadastrar()
        {
            this.txtPesquisa.Clear();
            //Direcionando para tela de cadastro Object sessao, int id, Boolean visualizar, object objFisioterapeuta
            FormSessaoCadastrar form = new FormSessaoCadastrar(nSessao, 0, false, null);
            form.ShowDialog();
            //Atualiza grid
            this.preencherGrid();
        }

        /// <summary>
        /// Este método recebe os dados do Data Grid para um objeto
        /// do tipo Sessoes para o Formulário que será aberto.
        /// </summary>
        public override void Alterar()
        {
            this.txtPesquisa.Clear();
            //Verifica se o Data grid possui linha
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica de sé alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected |
                    this.dgDados.CurrentRow.Cells[6].Selected | this.dgDados.CurrentRow.Cells[7].Selected)
                {
                    //Tratamento de exceções
                    try
                    {
                        this.nSessoes.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        this.nClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nSessoes.clinica = this.nClinica;
                        this.nFisioterapeuta.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[2].Value.ToString());
                        this.nSessoes.fisioterapeuta = this.nFisioterapeuta;
                        this.nPaciente.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[3].Value.ToString());
                        this.nSessoes.paciente = this.nPaciente;
                        this.nSessoes.situacao = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nSessoes.data = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[8].Value.ToString());
                        this.nSessoes.hora = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[9].Value.ToString());
                        this.nSessoes.observacao = this.dgDados.CurrentRow.Cells[10].Value.ToString();

                        //Verifica se o usuário quer alterar uma sessão concluída
                        if (this.dgDados.CurrentRow.Cells[7].Value.ToString() == "Concluída")
                        {
                            //Pergunta se deseja visualizar a sessão, pois, não é possível alterar
                            DialogResult ds = MessageBox.Show("Não é possível alterar uma sessão concluída. \n "+
                                "Deseja visualizá-la?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ds == DialogResult.Yes)
                            {
                                FormSessaoCadastrar form = new FormSessaoCadastrar(this.nSessao, this.nSessoes.id,
                                   true, this.nSessoes);
                                form.ShowDialog();   
                            }
                        }//Se não ele pode alterar normalmente.
                        else
                        {
                            //Inserindo dados da grid no objeto nSessoes.
                                FormSessaoCadastrar form = new FormSessaoCadastrar(this.nSessao, this.nSessoes.id,
                                false, this.nSessoes);
                            form.ShowDialog();
                        }
                        //Atualiza a grid
                        this.preencherGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma sessão selecionada.", "Aviso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há sessões cadastradas!", "Aviso!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica se o filtro foi selecionado
            if (this.cbFiltro.SelectedIndex > -1)
            {
                //Variáveis
                String filtro = null;

                if (this.cbFiltro.SelectedItem.Equals("Situação"))
                {
                    filtro = "ses.situacao";
                }
                else if (this.cbFiltro.SelectedItem.Equals("Fisioterapeuta"))
                {
                    filtro = "fis.nome";
                }
                else if (this.cbFiltro.SelectedItem.Equals("Paciente"))
                {
                    filtro = "pac.nome";
                }

                //Tratamento de exceções
                try
                {
                    this.dgDados.DataSource = this.sessoesDao.getDataTable(filtro, this.txtPesquisa.Text.ToString().Trim());
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
                this.txtPesquisa.Text = null;
                this.cbFiltro.Focus();
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            this.txtPesquisa.Clear();
            //Verifica se o Data grid possui linha
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica de sé alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected |
                    this.dgDados.CurrentRow.Cells[6].Selected | this.dgDados.CurrentRow.Cells[7].Selected)
                {
                    //Tratamento de exceções
                    try
                    {
                        //Inserindo dados da grid no objeto nSessoes.
                        this.nSessoes.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        this.nClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nSessoes.clinica = this.nClinica;
                        this.nFisioterapeuta.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[2].Value.ToString());
                        this.nSessoes.fisioterapeuta = this.nFisioterapeuta;
                        this.nPaciente.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[3].Value.ToString());
                        this.nSessoes.paciente = this.nPaciente;
                        this.nSessoes.situacao = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nSessoes.data = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[8].Value.ToString());
                        this.nSessoes.hora = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[9].Value.ToString());
                        this.nSessoes.observacao = this.dgDados.CurrentRow.Cells[10].Value.ToString();

                        FormSessaoCadastrar form = new FormSessaoCadastrar(this.nSessao, this.nSessoes.id,
                            true, this.nSessoes);
                        form.ShowDialog();

                        //Atualiza a grid
                        this.preencherGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma sessão selecionada.", "Aviso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há sessões cadastradas!", "Aviso!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLiberarSessão_Click(object sender, EventArgs e)
        {
            this.txtPesquisa.Clear();
            if (this.sessoesDao.verificaSessao())
            {
                MessageBox.Show("Já existe uma sessão liberada!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (this.dgDados.CurrentRow.Cells[7].Value.ToString() == "Concluida")
            {
                MessageBox.Show("Não é possível liberar uma sessão concluída.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (this.dgDados.Rows.Count > 0)
                {
                    //Verifica de sé alguma linha selecionada
                    if (this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected |
                        this.dgDados.CurrentRow.Cells[6].Selected | this.dgDados.CurrentRow.Cells[7].Selected)
                    {
                        //Tratamento de exceções
                        try
                        {
                            if (this.sessoesDao.liberaSessao(Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                MessageBox.Show("Sessão liberada com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Atualiza a grid
                                this.preencherGrid();
                            }
                            else
                            {
                                MessageBox.Show("Sessão não liberada!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma sessão selecionada.", "Aviso!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Não há sessões cadastradas!", "Aviso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
