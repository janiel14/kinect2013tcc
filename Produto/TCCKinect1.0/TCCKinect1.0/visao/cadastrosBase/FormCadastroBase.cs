using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCCKinect1._0.util;

namespace TCCKinect1._0.visao.cadastrosBase
{
    public partial class FormCadastroBase : Form
    {
 

        // Verificar o cadastro se esta em modo de inserção , alteração ou navegando para controlar os botoes de crud
        public enum StatusCadastro
        {
            scInserindo, scNavegando, scEditando
        }

        private StatusCadastro sStatus;

     
        public FormCadastroBase()
        {
            InitializeComponent();
        }

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

        public virtual bool Salvar()
        {
            return false;
        }

        public virtual bool Consultar()
        {
            return false;
        }

        public virtual bool Excluir()
        {
            return false;
        }

        public virtual void CarregaValores()
        {

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

            // botão novo = vai habilitado somente quando for navegaçação
            btnNovo.Enabled = (sStatus == StatusCadastro.scNavegando);

            // botão salvar = vai habilitada somente quando estiver editando ou inserindo
            btnSalvar.Enabled = (sStatus == StatusCadastro.scEditando || sStatus == StatusCadastro.scInserindo);

            // botaão excluir = vai habilitada somente quando estiver editando 
            btnExcluir.Enabled = (sStatus == StatusCadastro.scEditando);

            //botão consultar = vai habilitada somente quando estiver navegando
            btnConsultar.Enabled = (sStatus == StatusCadastro.scNavegando);

            //botão fechar =  sempre habilitado
            btnFechar.Enabled = true;
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCadastroBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)            
                Close();           
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Salvar())
            {
                sStatus = StatusCadastro.scNavegando;
                LimpaControles();
                HabilitaDesabilitaControles(false);
                MessageBox.Show("Registro salvo com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Excluir())
            {
                sStatus = StatusCadastro.scNavegando;
                LimpaControles();
                HabilitaDesabilitaControles(false);
                MessageBox.Show("Registro excluído com sucesso!", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            sStatus = StatusCadastro.scInserindo;
            LimpaControles();
            HabilitaDesabilitaControles(true);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (Consultar())
            {
                sStatus = StatusCadastro.scEditando;
                HabilitaDesabilitaControles(true);
                CarregaValores();

            }
        }

        private void FormCadastroBase_Load(object sender, EventArgs e)
        {
            sStatus = StatusCadastro.scNavegando;
            LimpaControles();
            HabilitaDesabilitaControles(false);
        }
    }
}
