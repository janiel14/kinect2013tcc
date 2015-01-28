using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CaptorKinect.util
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
            catch (MySqlException)
            {
                //Retorna false
            }
            //Retorno 
            return retorno;
        }
    }
}
