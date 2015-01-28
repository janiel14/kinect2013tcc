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
using TCCKinect1._0.visao.fisioterapeuta;
using TCCKinect1._0.visao.fichaDeAvaliacao;
using TCCKinect1._0.visao.paciente;
using TCCKinect1._0.modelo;
using TCCKinect1._0.dao;
using TCCKinect1._0.visao.sessoes;
using TCCKinect1._0.visao.relatorio;

namespace TCCKinect1._0.visao
{
    public partial class FormMain : Form
    {
        //Globais
        private Sessao nSessao = null;
        
        

        public FormMain(Object sessao)
        {
            InitializeComponent();
            this.nSessao = (Sessao)sessao;
         
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




        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Questionando usuário se ele deseja realmente sair do sistema
            DialogResult dr = MessageBox.Show("Deseja realmente sair do aplicativo?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Verifica opção do usuário
            if (dr == DialogResult.Yes)
            {
                //Fecha aplicação
                this.Close();
            }
        }

        private void fisioterapeutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormFisiotarapeuta form = new FormFisiotarapeuta(this.nSessao);
            //Verifica se formulário esta aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                //Abrindo formulário
                form.MdiParent = this;
                form.Show();
            }
        }

       

    
        private void fichaDeAvaliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormFichaDeAvaliacao form  = new FormFichaDeAvaliacao(this.nSessao);
            //Verifica se formulário esta aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                //Abrindo formulário
                form.MdiParent = this;
                form.Show();
            } 

        }

        private void clinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormClinica form = new FormClinica(this.nSessao.connMysql);
            //Verifica se formulário esta aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                //Abrindo formulário
                form.MdiParent = this;
                form.Show();
            }  
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormPaciente form = new FormPaciente(this.nSessao);
            //Verifica se o formulá já está aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void sessoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void SessaoStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormSessoes form = new FormSessoes(this.nSessao);
            //Verifica se formulário esta aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                //Abrindo formulário
                form.MdiParent = this;
                form.Show();
            }
        }
        /// <summary>
        /// Evento para abrir gerador de relatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sessoesRelatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Variaveis
            FormRelatorioGrafico form = new FormRelatorioGrafico(this.nSessao);
            //Verifica se formulário esta aberto
            if (this.formularioEstaAberto(form.Text) == false)
            {
                //Abrindo formulário
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}
