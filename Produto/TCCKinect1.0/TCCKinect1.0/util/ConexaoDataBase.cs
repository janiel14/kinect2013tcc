using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using TCCKinect1._0.Properties;
using TCCKinect1._0.modelo;

namespace TCCKinect1._0.util
{
    /**
     * Class Conexao
     * Retorna conexão com o banco.
     * Autor: Janiel Madureira Oliveira
     * ATENÇÃO: NÃO ALTERAR ESSA CLASSE!
     */
    class ConexaoDataBase
    {
        //Variaveis !!! NUNCA ALTERAR ESSES DADOS !!!
        private String usuario;
        private String senha;
        private const String banco = "kinectdb";
        private String host;
        private MySqlConnection connMysql = null;

        /// <summary>
        /// Construtor
        /// </summary>
        public ConexaoDataBase()
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="host">Endereço de conexão</param>
        /// <param name="usuario">Usuário para conexão</param>
        /// <param name="senha">Senha para conexão</param>
        public ConexaoDataBase(String host, String usuario, String senha)
        {
            this.host = host;
            this.usuario = usuario;
            this.senha = senha;
        }
        /// <summary>
        /// Obtem String de conexão
        /// </summary>
        /// <returns>MysqlConnection</returns>
        public MySqlConnection getConnectionMysql()
        {
            //String Conexão
            this.connMysql = new MySqlConnection(@"Server=" + host + ";Database=" + banco + ";Uid=" + usuario + ";Pwd='" + senha + "';");
            //Retorna conexão
            return this.connMysql;
        }
        /// <summary>
        /// Verifica se banco existe
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean bancoExiste()
        {
            //Variaveis
            Boolean retorno = false;
            MySqlConnection connMysql = null;
            //Tratamento de erros
            try
            {
                //Conexão com MYSQL
                connMysql = new MySqlConnection(@"Server=" + host + ";Database=" + banco + ";Uid=" + usuario + ";Pwd='" + senha + "';");
                //Abre conexão
                connMysql.Open();
                //Retorno
                retorno = true;
                //Fecha conexão
                connMysql.Close();
            }
            catch (MySqlException)
            {
                //Retorna false
            }
            //Retorno 
            return retorno;
        }
        /// <summary>
        /// Verifica conexão com o banco
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean verificaConexao()
        {
            //Variaveis
            Boolean retorno = false;
            MySqlConnection connMysql = null;
            //Tratamento de erros
            try
            {
                //Conexão com MYSQL
                connMysql = new MySqlConnection(@"Server=" + host + ";Uid=" + usuario + ";Pwd='" + senha + "';");
                //Abre conexão
                connMysql.Open();
                //Retorno
                retorno = true;
                //Fecha conexão
                connMysql.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042)
                {
                    throw new Exception("Host incorreto.");
                } 
                else if (ex.Number == 0)
                {
                    throw new Exception("Usuário e/ou senha está(ão) incorreto(s).");
                }
            }
            //Retorno 
            return retorno;
        }
        /// <summary>
        /// Executa script sqlMembro para criação do banco de dados.
        /// </summary>
        public void executaScriptSql()
        {
            //Variaveis
            MySqlConnection connMysql = null;
            MySqlCommand comando = null;
            MySqlTransaction transacao = null;
            //Tratamento de erros
            try
            {
                //Conexão com MYSQL
                connMysql = new MySqlConnection(@"Server=" + host + ";Uid=" + usuario + ";Pwd='" + senha + "';");
                //Abre conexão
                connMysql.Open();
                //Transacao
                transacao = connMysql.BeginTransaction();
                //Comando
                comando = connMysql.CreateCommand();
                //Inciando
                comando.Transaction = transacao;
                comando.Connection = connMysql;
                //Executa arquivo sqlMembro
                comando.CommandText = Resources.scriptsql;
                comando.ExecuteNonQuery();
                //Finaliznado transação
                transacao.Commit();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    throw new Exception("Host, Usuário ou senha está(ão) incorreto(s).");
                    transacao.Rollback();
                }
                else
                {
                    //Retorna false
                    throw new Exception("Problemas com criação do banco de dados!", ex);
                    transacao.Rollback();
                }
            }
            finally
            {
                //Fecha conexão
                connMysql.Close();
            }
        }
        /// <summary>
        /// Verifica se existe pela menos uma empresa cadastrada
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean existeClinica()
        {
            //Variaveis
            Boolean retorno = false;
            MySqlConnection connMysql = null;
            MySqlCommand comando = null;
            MySqlTransaction transacao = null;
            //Tratamento de erros
            try
            {
                //Conexão com MYSQL
                connMysql = new MySqlConnection(@"Server=" + host + ";Database=" + banco + ";Uid=" + usuario + ";Pwd='" + senha + "';");
                //Abre conexão
                connMysql.Open();
                //Transacao
                transacao = connMysql.BeginTransaction();
                //Comando
                comando = connMysql.CreateCommand();
                //Inciando
                comando.Transaction = transacao;
                comando.Connection = connMysql;
                //Sql
                comando.CommandText = "SELECT id FROM " + Clinica.entidade;
                MySqlDataReader rd = comando.ExecuteReader();
                //Verifica se há resultado
                if (rd.HasRows)
                {
                    retorno = true;
                }
                //Fecha result set
                rd.Close();
                //Finaliznado transação
                transacao.Commit();
            }
            catch (MySqlException ex)
            {
                //Retorna false
                transacao.Rollback();
                throw new Exception("Problemas com verificação de clinica!", ex);
            }
            finally
            {
                //Fecha conexão
                connMysql.Close();
            }  
            //Retorno
            return retorno;
        }
    }
}
