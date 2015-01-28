using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCCKinect1._0.visao.cadastrosBase
{
    public partial class FormBase : Form
    {
        // Verificar o cadastro se esta em modo de inserção , alteração ou navegando para controlar os botoes de crud
        public enum StatusCadastro
        {
            scInserindo, scNavegando, scEditando
        }

        private StatusCadastro sStatus;

        /// <summary>
        /// Varre todos os controles da tela e limpa os controles
        /// </summary>
        /// <param name="formulario">Limpa Controles</param>
        /// <returns>Void</returns>
        private void LimpaControles()
        {
            foreach (Control ctl in this.Controls)
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
            }

        }

        /// <summary>
        /// Analisa formulário em aberto para que somente um de cada esteja aberto
        /// </summary>
        /// <param name="formulario">Identificação do formulário</param>
        /// <returns>Boolean</returns>
        private Boolean formularioEstaAberto(String formulario)
        {
            //Variaveis
            Boolean retorno = false;
            //Percorre formulários abertos
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                //Verifica se algum dos formulários esta aberto e se estiver ativa ele
                if (this.MdiChildren[i].Text.Equals(formulario))
                {
                    //Ativando formulário
                    this.MdiChildren[i].Activate();
                    retorno = true;
                }
            }
            //Retorno
            return retorno;
        }

        private void HabilitaDesabilitaControles(bool bValue)
        {
            //percorre todos os controles de tela e habilita/desabilita
            foreach (Control ctl in this.Controls)
            {
                if (ctl is ToolStrip)
                    continue;

                ctl.Enabled = bValue;
            }

            // habilita os botoes

            // botão cadastrar = vai habilitado somente quando for navegaçação
            btnCadastrar.Enabled = (sStatus == StatusCadastro.scNavegando);

            // botão salvar = vai habilitada somente quando estiver editando ou inserindo
           // btnSalvar.Enabled = (sStatus == StatusCadastro.scEditando || sStatus == StatusCadastro.scInserindo);

            // botaão excluir = vai habilitada somente quando estiver editando 
            btnExcluir.Enabled = (sStatus == StatusCadastro.scEditando);

            //botão visualizar = vai habilitada somente quando estiver navegando
            btnVisualizar.Enabled = (sStatus == StatusCadastro.scNavegando);

        }

        public virtual void Alterar()
        {
        }

        public virtual void Cadastrar()
        {
        }


        public virtual void Excluir()
        {

        }

        public virtual void Visualizar()
        {

        }


        public FormBase()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {   
            Alterar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void dgDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if(e.Value.Equals("Liberada"))
                {
                    e.CellStyle.BackColor = Color.Gold;
                }
                else if (e.Value.Equals("Aguardando"))
                {
                    e.CellStyle.BackColor = Color.Salmon;
                }
                else if (e.Value.Equals("Concluída"))
                {
                    e.CellStyle.BackColor = Color.Chartreuse;
                }
            }
        }
    }
}
