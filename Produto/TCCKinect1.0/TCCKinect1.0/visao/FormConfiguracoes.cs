using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao
{
    public partial class FormConfiguracoes : Form
    {
        ErrorProvider errorProvider2;

        public FormConfiguracoes()
        {            
            InitializeComponent();
            errorProvider2 = new ErrorProvider();
        }

        protected bool ValidateNull()
        {
            //se TextBox vazio
            if (this.txtHost.Text == "")
            {
                errorProvider1.SetError(txtHost, "Campo obrigatório!");
                txtHost.Focus();
                return false;
            }
            else if (this.txtUsuario.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUsuario, "Campo obrigatório!");
                txtUsuario.Focus();
                return false;
            }
            else if (this.txtSenha.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSenha, "Campo obrigatório!");
                txtSenha.Focus();
                return false;
            }
            return true;
        }       
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            //Tratamento de exceções
            try
            {
                //Verifica se os campos não são nulos
                if (ValidateNull())
                {
                    Configuracao conf = new Configuracao();
                    ConexaoDataBase conexaoDB = new ConexaoDataBase(txtHost.Text, txtUsuario.Text, txtSenha.Text);
                    //conexaoDB.executaScriptSql();
                    if (conexaoDB.verificaConexao())
                    {
                        conf.gravarConfiguracoes(txtHost.Text, txtUsuario.Text, txtSenha.Text);
                        MessageBox.Show("Conexão realizada com sucesso.",
                                "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao inicializar o aplicativo!",
                        "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message,
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHost.Clear();
                this.txtUsuario.Clear();
                this.txtSenha.Clear();
            }
        }

        private void btnTesteConexao_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            //Tratamento de exceções
            try
            {
                //Verifica se os campos não são nulos
                if (ValidateNull())
                {
                    Configuracao conf = new Configuracao();
                    ConexaoDataBase conexaoDB = new ConexaoDataBase(txtHost.Text, txtUsuario.Text, txtSenha.Text);
                    //conexaoDB.executaScriptSql();
                    if (conexaoDB.verificaConexao())
                    {
                        MessageBox.Show("Os parâmetros da conexão estão corretos.",
                                "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnOk.Enabled = true;
                        this.btnTesteConexao.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao inicializar o aplicativo!",
                        "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Host incorreto."))
                {
                    this.errorProvider1.Clear();
                    errorProvider1.SetError(this.txtHost, "Host incorreto.");
                }
                else if (ex.Message.Equals("Usuário e/ou senha está(ão) incorreto(s)."))
                {
                    this.errorProvider1.Clear();
                    errorProvider1.SetError(this.txtUsuario, "Usuário e/ou senha está(ão) incorreto(s).");
                    errorProvider2.SetError(this.txtSenha, "Usuário e/ou senha está(ão) incorreto(s).");
                }
                else
                {
                    MessageBox.Show("Erro: " + ex.Message,
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txtHost.Clear();
            this.txtUsuario.Clear();
            this.txtSenha.Clear();
            this.Close();
        }

        private void txtHost_KeyUp(object sender, KeyEventArgs e)
        {
            this.errorProvider1.Clear();
            this.errorProvider2.Clear();
            this.btnOk.Enabled = false;
            this.btnTesteConexao.Enabled = true;
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            this.errorProvider1.Clear();
            this.errorProvider2.Clear();
            this.btnOk.Enabled = false;
            this.btnTesteConexao.Enabled = true;
        }

        private void txtSenha_KeyUp_1(object sender, KeyEventArgs e)
        {
            this.errorProvider1.Clear();
            this.errorProvider2.Clear();
            this.btnOk.Enabled = false;
            this.btnTesteConexao.Enabled = true;
        }
    }
}
