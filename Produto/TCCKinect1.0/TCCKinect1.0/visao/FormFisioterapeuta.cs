using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCCKinect1._0.util;
using TCCKinect1._0.dao;
using TCCKinect1._0.modelo;
using MySql.Data.MySqlClient;



namespace TCCKinect1._0.visao
{
    public partial class FormFisioterapeuta : TCCKinect1._0.visao.cadastrosBase.FormBase
    {


        //Globais
        private Sessao nSessao = null;
        private MySqlConnection conn = null;
        private Utils nUtil = null;
     //   private  nFisioterapeuta = null;
      //  private FisioterapeutaDAO daoClinica = null;

        public FormFisioterapeuta(Object sessao)
        {
            InitializeComponent();
            this.nSessao = (Sessao)sessao;
            this.conn = this.nSessao.connMysql;
        // this.daoFisio = new ClinicaDAO(this.conn);
            this.nUtil = new Utils();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}
