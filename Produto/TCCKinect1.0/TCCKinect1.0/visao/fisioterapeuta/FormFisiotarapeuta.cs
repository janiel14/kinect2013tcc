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

namespace TCCKinect1._0.visao.fisioterapeuta
{
    public partial class FormFisiotarapeuta : TCCKinect1._0.visao.cadastrosBase.FormBase
    {
        //Globais
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private Fisioterapeuta nFisioterapeuta = null;
        private FisioterapeutaDAO daoFisioterapeuta = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessão</param>
        public FormFisiotarapeuta(Object sessao)
        {
            InitializeComponent();
            //Globais
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.daoFisioterapeuta = new FisioterapeutaDAO(this.nSessao.connMysql);
            this.nFisioterapeuta = new Fisioterapeuta();
        }

        private void preencherGrid()
        {
            //Tratamento de erros
            try
            {
                //Obtento dados da Tabela Fisioterapeuta
                this.dgDados.DataSource = this.daoFisioterapeuta.getDataTable();
                this.configuraDataGrid();
                this.dgDados.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configuraDataGrid()
        {
            //Tratamento de erros
            try
            {
                //Definir a altura do cabeçalho
                this.dgDados.RowHeadersWidth = 25;
                this.dgDados.ColumnHeadersHeight = 30;

                //Alinha cabeçalho do data grid
                this.dgDados.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgDados.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgDados.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgDados.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Configurando colunas
                this.dgDados.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgDados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgDados.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgDados.Columns[2].Width = 461;
                this.dgDados.Columns[3].Width = 101;
                this.dgDados.Columns[4].Width = 101;
                this.dgDados.Columns[5].Width = 101;
                this.dgDados.AllowUserToResizeColumns = false; //Fixa a largura da coluna            
                this.dgDados.AllowUserToResizeRows = false; //Fixa a altura da linha
                
                //Ocultando colunas
                this.dgDados.Columns[0].Visible = false;
                this.dgDados.Columns[1].Visible = false;
                this.dgDados.Columns[6].Visible = false;
                this.dgDados.Columns[7].Visible = false;
                this.dgDados.Columns[8].Visible = false;
                this.dgDados.Columns[9].Visible = false;
                this.dgDados.Columns[10].Visible = false;
                this.dgDados.Columns[11].Visible = false;
                this.dgDados.Columns[12].Visible = false;
                this.dgDados.Columns[13].Visible = false;
                this.dgDados.Columns[14].Visible = false;
                this.dgDados.Columns[15].Visible = false;
                this.dgDados.Columns[16].Visible = false;
                this.dgDados.Columns[17].Visible = false;
                this.dgDados.Columns[18].Visible = false;
                this.dgDados.Columns[19].Visible = false;
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
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        Clinica tempClinica = new Clinica();
                        this.nFisioterapeuta.id = Convert.ToInt32(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString()));
                        tempClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nFisioterapeuta.clinica = tempClinica;
                        this.nFisioterapeuta.nome = this.dgDados.CurrentRow.Cells[2].Value.ToString();
                        this.nFisioterapeuta.cpf = this.dgDados.CurrentRow.Cells[3].Value.ToString();
                        this.nFisioterapeuta.rg = this.dgDados.CurrentRow.Cells[4].Value.ToString();
                        this.nFisioterapeuta.crefito = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nFisioterapeuta.especializacao = this.dgDados.CurrentRow.Cells[6].Value.ToString();
                        this.nFisioterapeuta.sexo = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nFisioterapeuta.dataDeNascimento = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[8].Value.ToString());
                        this.nFisioterapeuta.estadoCivil = this.dgDados.CurrentRow.Cells[9].Value.ToString();
                        this.nFisioterapeuta.logradouro = this.dgDados.CurrentRow.Cells[10].Value.ToString();
                        this.nFisioterapeuta.numero = Convert.ToInt32(this.dgDados.CurrentRow.Cells[11].Value.ToString());
                        this.nFisioterapeuta.complemento = this.dgDados.CurrentRow.Cells[12].Value.ToString();
                        this.nFisioterapeuta.bairro = this.dgDados.CurrentRow.Cells[13].Value.ToString();
                        this.nFisioterapeuta.cep = this.dgDados.CurrentRow.Cells[14].Value.ToString();
                        this.nFisioterapeuta.cidade = this.dgDados.CurrentRow.Cells[15].Value.ToString();
                        this.nFisioterapeuta.uf = this.dgDados.CurrentRow.Cells[16].Value.ToString();
                        this.nFisioterapeuta.telefone = this.dgDados.CurrentRow.Cells[17].Value.ToString();
                        this.nFisioterapeuta.celular = this.dgDados.CurrentRow.Cells[18].Value.ToString();
                        this.nFisioterapeuta.email = this.dgDados.CurrentRow.Cells[19].Value.ToString();

                        //Direcionando
                        FormFisioterapeutaCadastro form = new FormFisioterapeutaCadastro(this.nSessao, this.nFisioterapeuta.id, false, this.nFisioterapeuta);
                        form.ShowDialog(this);
                        this.preencherGrid();
                        this.configuraDataGrid();
                    }
                        //Atualiza grid
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o fisioterapeuta que deseja alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há fisioterapeutas cadastrados para alterar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Alterar();
        }

        public override void Cadastrar()
        {
            this.txtPesquisa.Clear();
            //Direcionando para tela de cadastro
            FormFisioterapeutaCadastro form = new FormFisioterapeutaCadastro(this.nSessao, 0, false, null);
            form.ShowDialog();
            //Atualiza grid
            this.preencherGrid();
            this.configuraDataGrid();
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
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected)
                {
                    //Pergunta qual a clinica deseja excluir
                    DialogResult dr = MessageBox.Show("Deseja realmente excluir este fisioterapeuta?", "Questão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Verifica decisão
                    if (dr == DialogResult.Yes)
                    {
                        //Tratamento de erros
                        try
                        {
                            //Excluindo
                            if (this.daoFisioterapeuta.excluir(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                //Preenche grid
                                this.preencherGrid();
                                this.configuraDataGrid();

                                //Avisa
                                MessageBox.Show("Fisioterapeuta excluido com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível excluir o fisioterapeuta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Selecione o fisioterapeuta que deseja excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há fisioterapeutas cadastrados para excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.dgDados.CurrentRow.Cells[4].Selected | this.dgDados.CurrentRow.Cells[5].Selected)
                {
                    //Tratamento de erros
                    try
                    {
                        Clinica tempClinica = new Clinica();
                        this.nFisioterapeuta.id = Convert.ToInt32(this.nUtil.convertStringParaInt(this.dgDados.CurrentRow.Cells[0].Value.ToString()));
                        tempClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nFisioterapeuta.clinica = tempClinica;
                        this.nFisioterapeuta.nome = this.dgDados.CurrentRow.Cells[2].Value.ToString();
                        this.nFisioterapeuta.cpf = this.dgDados.CurrentRow.Cells[3].Value.ToString();
                        this.nFisioterapeuta.rg = this.dgDados.CurrentRow.Cells[4].Value.ToString();
                        this.nFisioterapeuta.crefito = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nFisioterapeuta.especializacao = this.dgDados.CurrentRow.Cells[6].Value.ToString();
                        this.nFisioterapeuta.sexo = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nFisioterapeuta.dataDeNascimento = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[8].Value.ToString());
                        this.nFisioterapeuta.estadoCivil = this.dgDados.CurrentRow.Cells[9].Value.ToString();
                        this.nFisioterapeuta.logradouro = this.dgDados.CurrentRow.Cells[10].Value.ToString();
                        this.nFisioterapeuta.numero =  Convert.ToInt32(this.dgDados.CurrentRow.Cells[11].Value.ToString());
                        this.nFisioterapeuta.complemento = this.dgDados.CurrentRow.Cells[12].Value.ToString();
                        this.nFisioterapeuta.bairro = this.dgDados.CurrentRow.Cells[13].Value.ToString();
                        this.nFisioterapeuta.cep = this.dgDados.CurrentRow.Cells[14].Value.ToString();
                        this.nFisioterapeuta.cidade= this.dgDados.CurrentRow.Cells[15].Value.ToString();
                        this.nFisioterapeuta.uf = this.dgDados.CurrentRow.Cells[16].Value.ToString();
                        this.nFisioterapeuta.telefone = this.dgDados.CurrentRow.Cells[17].Value.ToString();
                        this.nFisioterapeuta.celular = this.dgDados.CurrentRow.Cells[18].Value.ToString();
                        this.nFisioterapeuta.email = this.dgDados.CurrentRow.Cells[19].Value.ToString();

                        //Direcionando
                        FormFisioterapeutaCadastro form = new FormFisioterapeutaCadastro(this.nSessao, this.nFisioterapeuta.id, true, this.nFisioterapeuta);
                        form.ShowDialog(this);
                        this.preencherGrid();
                        this.configuraDataGrid();
                    }
                    //Atualiza grid
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o fisioterapeuta que deseja visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há fisioterapeutas cadastrados para visualizar!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.Alterar();
        }

        private void cbFiltro_DropDownClosed(object sender, EventArgs e)
        {
            //Limpando campo
            this.txtPesquisa.Clear();
            this.txtPesquisa.Focus();
        }

        private void FormFisiotarapeuta_Load(object sender, EventArgs e)
        {
            this.preencherGrid();
            this.configuraDataGrid();
        }

        private void txtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            //Verifica se foi selecionado um filtro
            if (this.cbFiltro.SelectedIndex > -1)
            {
                //Variaveis
                String filtro = null;
                //Verificando filtro selecionado

                if (this.cbFiltro.Text.Equals("Nome"))
                {
                    filtro = "fisioterapeuta.nome";
                }

                //Tratamento de erros
                try
                {
                    //Obtendo dados
                    this.dgDados.DataSource = this.daoFisioterapeuta.getDataTable(filtro, this.txtPesquisa.Text);

                    //Configurando colunas
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

