using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCCKinect1._0.dao;
using TCCKinect1._0.modelo;
using TCCKinect1._0.util;
using TCCKinect1._0.visao.fisioterapeuta;

namespace TCCKinect1._0.visao.paciente
{
    public partial class FormPaciente : TCCKinect1._0.visao.cadastrosBase.FormBase
    {
        //Globais
        private Sessao nSessao = null;
        private Utils nUtil = null;
        private PacienteDAO daoPaciente = null;
        private Paciente nPaciente = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sessao">Objeto sessao</param>
        public FormPaciente(object sessao)
        {
            InitializeComponent();
            //Globais
            this.nSessao = (Sessao)sessao;
            this.nUtil = new Utils();
            this.daoPaciente = new PacienteDAO(this.nSessao.connMysql);
            this.nPaciente = new Paciente();
        }

        public override void Cadastrar()
        {
            this.txtPesquisa.Clear();
            //Direcionando para tela de cadastro Object sessao, int id, Boolean visualizar, object objFisioterapeuta
            FormPacienteCadastro form = new FormPacienteCadastro(nSessao, 0, false, null);
            form.ShowDialog();
            //Atualiza grid
            this.preencherGrid();
        }


        /// <summary>
        /// Este método recebe os dados do Data Grid para um objeto
        /// do tipo Paciente para o Formulário que será aberto.
        /// </summary>
        public override void Alterar()
        {
            //Verifica se o Data grid possui linha
            this.txtPesquisa.Clear();
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica de sé alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected)
                {
                   //Tratamento de exceções
                    try
                    {
                        Clinica nClinica = new Clinica();

                        //Inserindo dados da grid no objeto nPaciente.
                        this.nPaciente.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        nClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nPaciente.clinica = nClinica;
                        this.nPaciente.nome = this.dgDados.CurrentRow.Cells[2].Value.ToString();
                        this.nPaciente.cpf = this.dgDados.CurrentRow.Cells[3].Value.ToString();
                        this.nPaciente.rg = this.dgDados.CurrentRow.Cells[4].Value.ToString();
                        this.nPaciente.sexo = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nPaciente.dataDeNascimento = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[6].Value.ToString());
                        this.nPaciente.estadoCivil = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nPaciente.profissao = this.dgDados.CurrentRow.Cells[8].Value.ToString();
                        this.nPaciente.logradouro = this.dgDados.CurrentRow.Cells[9].Value.ToString();
                        this.nPaciente.numero = Convert.ToInt32(this.dgDados.CurrentRow.Cells[10].Value.ToString());
                        this.nPaciente.complemento = this.dgDados.CurrentRow.Cells[11].Value.ToString();
                        this.nPaciente.bairro = this.dgDados.CurrentRow.Cells[12].Value.ToString();
                        this.nPaciente.cep = this.dgDados.CurrentRow.Cells[13].Value.ToString();
                        this.nPaciente.cidade = this.dgDados.CurrentRow.Cells[14].Value.ToString();
                        this.nPaciente.uf = this.dgDados.CurrentRow.Cells[15].Value.ToString();
                        this.nPaciente.telefone = this.dgDados.CurrentRow.Cells[16].Value.ToString();
                        this.nPaciente.celular = this.dgDados.CurrentRow.Cells[17].Value.ToString();
                        this.nPaciente.email = this.dgDados.CurrentRow.Cells[18].Value.ToString();
                        this.nPaciente.observacao = this.dgDados.CurrentRow.Cells[19].Value.ToString();
                        this.nPaciente.dataDoCadastro = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[20].Value.ToString());

                        FormPacienteCadastro formPaciente = new FormPacienteCadastro(nSessao, this.nPaciente.id, false,
                            this.nPaciente);
                        formPaciente.ShowDialog();

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
                    MessageBox.Show("Nenhum paciente selecionado. Para alterar selecione uma linha!", "Aviso!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há pacientes cadastrados!", "Aviso!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.preencherGrid();
            }
        }

        public override void Visualizar()
        {
            this.txtPesquisa.Clear();
            //Verifica se o Data grid possui linha
            if (this.dgDados.Rows.Count > 0)
            {
                //Verifica de sé alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected)
                {
                    //Tratamento de exceções
                    try
                    {
                        Clinica nClinica = new Clinica();

                        //Inserindo dados da grid no objeto nPaciente.
                        this.nPaciente.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString());
                        nClinica.id = Convert.ToInt32(this.dgDados.CurrentRow.Cells[1].Value.ToString());
                        this.nPaciente.clinica = nClinica;
                        this.nPaciente.nome = this.dgDados.CurrentRow.Cells[2].Value.ToString();
                        this.nPaciente.cpf = this.dgDados.CurrentRow.Cells[3].Value.ToString();
                        this.nPaciente.rg = this.dgDados.CurrentRow.Cells[4].Value.ToString();
                        this.nPaciente.sexo = this.dgDados.CurrentRow.Cells[5].Value.ToString();
                        this.nPaciente.dataDeNascimento = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[6].Value.ToString());
                        this.nPaciente.estadoCivil = this.dgDados.CurrentRow.Cells[7].Value.ToString();
                        this.nPaciente.profissao = this.dgDados.CurrentRow.Cells[8].Value.ToString();
                        this.nPaciente.logradouro = this.dgDados.CurrentRow.Cells[9].Value.ToString();
                        this.nPaciente.numero = Convert.ToInt32(this.dgDados.CurrentRow.Cells[10].Value.ToString());
                        this.nPaciente.complemento = this.dgDados.CurrentRow.Cells[11].Value.ToString();
                        this.nPaciente.bairro = this.dgDados.CurrentRow.Cells[12].Value.ToString();
                        this.nPaciente.cep = this.dgDados.CurrentRow.Cells[13].Value.ToString();
                        this.nPaciente.cidade = this.dgDados.CurrentRow.Cells[14].Value.ToString();
                        this.nPaciente.uf = this.dgDados.CurrentRow.Cells[15].Value.ToString();
                        this.nPaciente.telefone = this.dgDados.CurrentRow.Cells[16].Value.ToString();
                        this.nPaciente.celular = this.dgDados.CurrentRow.Cells[17].Value.ToString();
                        this.nPaciente.email = this.dgDados.CurrentRow.Cells[18].Value.ToString();
                        this.nPaciente.observacao = this.dgDados.CurrentRow.Cells[19].Value.ToString();
                        this.nPaciente.dataDoCadastro = Convert.ToDateTime(this.dgDados.CurrentRow.Cells[20].Value.ToString());

                        FormPacienteCadastro formPaciente = new FormPacienteCadastro(nSessao, this.nPaciente.id, true,
                            this.nPaciente);
                        formPaciente.ShowDialog();

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
                    MessageBox.Show("Nenhum paciente selecionado. Para visualizar selecione uma linha!", "Aviso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.preencherGrid();
                }
            }
            else
            {
                MessageBox.Show("Não há pacientes cadastrados!", "Aviso!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.preencherGrid();
            }
        }

        public override void Excluir()
        {
            this.txtPesquisa.Clear();
            //Foca no grid
            this.dgDados.Focus();
            //Verifica se há linha no data gride
            if (this.dgDados.RowCount > 0)
            {
                //Verifica se há alguma linha selecionada
                if (this.dgDados.CurrentRow.Cells[2].Selected | this.dgDados.CurrentRow.Cells[3].Selected |
                    this.dgDados.CurrentRow.Cells[4].Selected)
                {
                    //Pede confirmação ao usuário 
                    DialogResult dr = MessageBox.Show("Deseja realmente excluir este paciente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    //Verifica o resultado da confirmação
                    if (dr == DialogResult.Yes)
                    { 
                        //Tratamento de exceções
                        try
                        {
                            //Excluindo
                            if (this.daoPaciente.excluir(Convert.ToInt32(this.dgDados.CurrentRow.Cells[0].Value.ToString())))
                            {
                                //Atualizar grid
                                this.preencherGrid();

                                MessageBox.Show("Paciente excluido com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else 
                            {
                                MessageBox.Show("Não foi possível excluir o paciente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Nenhum paciente selecionado. Para excluir selecione uma linha!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não há pacientes cadastrados!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.preencherGrid();
            }
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

            //Alinha cabeçalho do data grid
            this.dgDados.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDados.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Definir largura das colunas
            this.dgDados.Columns[2].Width = 500;
            this.dgDados.Columns[3].Width = 132;
            this.dgDados.Columns[4].Width = 132;
            this.dgDados.AllowUserToResizeColumns = false; //Fixa a largura da coluna            
            this.dgDados.AllowUserToResizeRows = false; //Fixa a altura da linha

            //Ocultando colunas. Somente as colunas 2, 16, 17 e 18 que estão visíveis.
            this.dgDados.Columns[0].Visible = false;
            this.dgDados.Columns[1].Visible = false;
            this.dgDados.Columns[5].Visible = false;
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
            this.dgDados.Columns[20].Visible = false;
        }

        private void preencherGrid()
        {
            //Tratamento de erros
            try
            {
               //Obtento dados da Tabela Fisioterapeuta
                this.dgDados.DataSource = this.daoPaciente.getDataTable();
                this.configuraDataGrid();
                this.dgDados.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPaciente_Enter(object sender, EventArgs e)
        {
            this.preencherGrid();
        }

        private void txtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            //Verifica se o filtro foi selecionado
            if (this.cbFiltro.SelectedIndex > -1)
            {
                //Variáveis
                String filtro = null;

                if (this.cbFiltro.SelectedItem.Equals("Nome"))
                {
                    filtro = "paciente.nome";
                }

                //Tratamento de exceções
                try
                {
                    this.dgDados.DataSource = this.daoPaciente.getDataTable(filtro, this.txtPesquisa.Text);
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
                this.cbFiltro.Focus();
            }
        }

        private void cbFiltro_DropDownClosed(object sender, EventArgs e)
        {
            this.txtPesquisa.Clear();
            this.preencherGrid();
            this.txtPesquisa.Focus();
        }
    }
}
