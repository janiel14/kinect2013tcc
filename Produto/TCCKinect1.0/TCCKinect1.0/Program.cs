using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCCKinect1._0.visao;
using TCCKinect1._0.util;
using MySql.Data.MySqlClient;

namespace TCCKinect1._0
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Configurando aplicação.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuracao nConfiguracao = new Configuracao();
            ConexaoDataBase nConexaoDataBase;
            MySqlConnection connMysql;
            Sessao nSessao = null;
            FormConfiguracoes formConfiguracoes = new FormConfiguracoes();
            //Tratamento de erros
            try
            {
                
                //Verifica se existe configuração
                if (nConfiguracao.existeConfiguracao())
                {
                    //Lendo configurações
                    nConfiguracao.lerConfiguracoes();
                    //Obtendo conexão com banco.
                    nConexaoDataBase = new ConexaoDataBase(nConfiguracao.host, nConfiguracao.usuario, nConfiguracao.senha);
                    connMysql = nConexaoDataBase.getConnectionMysql();
                    //Verifica se exite banco
                    if (nConexaoDataBase.bancoExiste() == false)
                    {
                        //Criando banco
                        nConexaoDataBase.executaScriptSql();
                    }
                    //Verifica se existe uma empresa cadastrada
                    if (nConexaoDataBase.existeClinica() == false)
                    {
                        //Direciona para tela de cadastro da empresa
                       FormClinicaCadastroInicial formClicaCadastroInicial = new FormClinicaCadastroInicial(connMysql);
                       //Verifica resultado do cadastro
                       if (formClicaCadastroInicial.ShowDialog() == DialogResult.OK)
                       {
                            Application.Run(new FormMain(nSessao));
                        }
                        else
                        {
                            //Fecha aplicação
                            Application.Exit();
                        }
                    }
                    else
                    {
                        nSessao = new Sessao();
                        nSessao.connMysql = connMysql; //Recebendo string de conexão
                        //Iniciando aplicação
                        Application.Run(new FormMain(nSessao)); 
                    }                 
                }
                else
                {
                    //Verificando configurações
                    if (formConfiguracoes.ShowDialog() == DialogResult.OK)
                    {
                        //Lendo configurações
                        nConfiguracao.lerConfiguracoes();
                        //Obtendo conexão com banco.
                        nConexaoDataBase = new ConexaoDataBase(nConfiguracao.host, nConfiguracao.usuario, nConfiguracao.senha);
                        connMysql = nConexaoDataBase.getConnectionMysql();
                        //Verifica se exite banco
                        if (nConexaoDataBase.bancoExiste() == false)
                        {
                            //Criando banco
                            nConexaoDataBase.executaScriptSql();
                        }
                        //Verifica se existe uma empresa cadastrada
                        if (nConexaoDataBase.existeClinica() == false)
                        {
                            //Direciona para tela de cadastro da empresa
                            FormClinicaCadastroInicial formClinicaCadInicial = new FormClinicaCadastroInicial(connMysql);
                            //Verifica resultado do cadastro
                            if (formClinicaCadInicial.ShowDialog() == DialogResult.OK)
                            {   
                                //obtendo sessão
                                nSessao = new Sessao();
                                nSessao.connMysql = connMysql; //Recebendo string de conexão
                                //Iniciando aplicação
                                Application.Run(new FormMain(nSessao));
                            }
                            else
                            {
                                //Fecha a app
                                Application.Exit();
                            }
                        }
                        else
                        {
                            nSessao = new Sessao();
                            nSessao.connMysql = connMysql; //Recebendo string de conexão
                            //Iniciando aplicação
                            Application.Run(new FormMain(nSessao));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar o aplicativo! Erro: " + ex.Message,
                    "Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
