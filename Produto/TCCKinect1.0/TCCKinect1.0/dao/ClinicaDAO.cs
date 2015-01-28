using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCKinect1._0.modelo;

namespace TCCKinect1._0.dao
{
    class ClinicaDAO
    {
        //Atributos
        private MySqlConnection connMysql;
        private MySqlTransaction transacaoMysql;
        private MySqlCommand comandoMysql;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="conn"></param>
        public ClinicaDAO(MySqlConnection conn)
        {
            this.connMysql = conn;
        }

        /// <summary>
        /// Este método verifica através do cnpj se a clinica já foi cadastrada.
        /// </summary>
        /// <returns>True e False</returns>
        public Boolean existeClinica(String cnpj)
        {
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            try
            {
                this.comandoMysql.CommandText = "SELECT * FROM " + Clinica.entidade + " WHERE cnpj = '" + cnpj + "';";
                this.comandoMysql.ExecuteNonQuery(); //Executa o comando.
                this.transacaoMysql.Commit(); //Comitando transação

                MySqlDataReader dr = comandoMysql.ExecuteReader();
                if (dr.HasRows)
                {
                    retorno = true;
                }
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Rertornando ao ponto inicial.
                throw new Exception("Não foi possível realizar esta consulta!", ex);
            }
            finally
            {
                this.connMysql.Close(); //Fecha a conexão
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Método cadastrar clinica.
        /// </summary>
        /// <param name="clinica">Objeto com dados</param>
        /// <returns>Retorna True se a clínica for cadastrada se não false.</returns>
        public Boolean cadastrar(Clinica clinica)
        {
            //Obtendo dados para conexão
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;
            //Tratamento de erros
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "INSERT INTO " + Clinica.entidade +
                    "(id, cnpj, razao_social, nome_fantasia, logradouro, numero, complemento, bairro, cep, cidade, uf, " +
                    "telefone, celular, email) VALUES (" + clinica.id + ", '" + clinica.cnpj + "', '" + clinica.razaoSocial +
                    "', '" + clinica.nomeFantasia + "', '" + clinica.logradouro + "', " + clinica.numero + ", '" + clinica.complemento +
                    "', '" + clinica.bairro + "', '" + clinica.cep + "', '" + clinica.cidade + "', '" + clinica.uf + "', '" + clinica.telefone +
                    "', '" + clinica.celular + "', '" + clinica.email + "');";

                //Executando SQL
                this.comandoMysql.ExecuteNonQuery();

                //Commitando transação
                this.transacaoMysql.Commit();

                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                //Retornando ao ponto inicial
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível realizar o cadastro!", ex);
            }

            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }

            //Retorno 
            return retorno;
        }

        /// <summary>
        /// Método alterar clinica.
        /// </summary>
        /// <param name="clinica">Objeto com dados</param>
        /// <returns>Retorna True se a clínica foi cadastrasda se não false.</returns>
        public Boolean alterar(Clinica clinica)
        {
            //Obtendo dados para conexão
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;
            //Tratamento de erros
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "UPDATE " + Clinica.entidade + " SET " + "cnpj='" + clinica.cnpj + "', " +
                    "razao_social='" + clinica.razaoSocial + "', " + "nome_fantasia='" + clinica.nomeFantasia + "', " +
                    "logradouro='" + clinica.logradouro + "', " + "numero=" + clinica.numero + ", " +
                    "complemento='" + clinica.complemento + "', " + "bairro='" + clinica.bairro + "', " +
                    "cep='" + clinica.cep + "', " + "cidade='" + clinica.cidade + "', " + "uf='" + clinica.uf + "', " +
                    "telefone='" + clinica.telefone + "', " + "celular='" + clinica.celular + "', " +
                    "email='" + clinica.email + "' WHERE id = " + clinica.id;
                //Executando SQL
                this.comandoMysql.ExecuteNonQuery();
                //Commitando transação
                this.transacaoMysql.Commit();
                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                //Retornando ao ponto inicial
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível alterar o cadastro!", ex);
            }

            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }

            //Retorno 
            return retorno;
        }

        /// <summary>
        /// Método excluir clinica.
        /// </summary>
        /// <param name="id">Chave primária da tabela clinica</param>
        /// <returns> Retorna True se a clínica foi cadastrasda se não false.</returns>
        public Boolean excluir(int id)
        {
            //Obtendo dados para conexão
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;
            //Tratamento de erros
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "DELETE FROM " + Clinica.entidade + " WHERE id = " + id;
                //Executando SQL
                this.comandoMysql.ExecuteNonQuery();
                //Commitando transação
                this.transacaoMysql.Commit();
                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    this.transacaoMysql.Rollback();//Retornando ao ponto inicial.    
                    throw new Exception("Esta clinica não pode ser excluida, pois, possui dados vinculados a ela no sistema.", ex);
                }
                //Retornando ao ponto inicial
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível excluir o cadastro!", ex);
            }

            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }

            //Retorno 
            return retorno;
        }

        /// <summary>
        /// Retorna tabela de dados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable getDataTable()
        {
            //Obtendo dados para conexão
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de erros
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "SELECT id as ID, cnpj AS CNPJ, razao_social AS 'RAZÃO SOCIAL', nome_fantasia AS 'NOME FANTASIA'," +
                    " logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, cep AS CEP," +
                    " cidade AS CIDADE, uf AS UF, telefone AS TELEFONE, celular AS CELULAR, email AS 'E-MAIL' FROM " +
                    Clinica.entidade + " ORDER BY nome_fantasia ASC";
                //Executando SQL
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);
                //Commitando transação
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                //Retornando ao ponto inicial
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível obter dados!", ex);
            }

            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }

            //Retorno 
            return retorno;
        }

        public DataTable getDataTable(String Filtro , String Pesquisa)
        {
            //Obtendo dados para conexão
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de erros
            try
            {
                //Montando SQL
               this.comandoMysql.CommandText = "SELECT id as ID, cnpj AS CNPJ, razao_social AS 'RAZÃO SOCIAL', nome_fantasia AS 'NOME FANTASIA'," +
                    " logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, cep AS CEP," +
                    " cidade AS CIDADE, uf AS UF, telefone AS TELEFONE, celular AS CELULAR, email AS 'E-MAIL' FROM " +
                    Clinica.entidade + " WHERE " + Filtro + " LIKE" + " '%"+Pesquisa+"%'"+  " ORDER BY nome_fantasia ASC";
                //Executando SQL
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);
                //Commitando transação
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                //Retornando ao ponto inicial
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível obter dados!", ex);
            }

            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }

            //Retorno 
            return retorno;
        }
    }

    
}
