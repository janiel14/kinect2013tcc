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
    class FichaDeAvaliacaoDAO
    {
        //Globais
        private MySqlConnection connMysql;
        private MySqlTransaction transacaoMysql;
        private MySqlCommand comandoMysql;


        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="conn"></param>
        public FichaDeAvaliacaoDAO(MySqlConnection conn)
        {
            this.connMysql = conn;
        }

        /// <summary>
        /// Cadastrar ficha de avaliação.
        /// </summary>
        /// <param name="ficha">Objeto com dados</param>
        /// <returns>Retorna true se a Ficha de avalicao for cadastrada se não false.</returns>
        public Boolean cadastrar(FichaDeAvaliacao ficha)
        {
            //Obtendo dados para conexao
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes
            try
            {
                this.comandoMysql.CommandText = "INSERT INTO " + FichaDeAvaliacao.entidade + "(paciente_id, data_da_avaliacao, " +
                    "data_prox_avaliacao, dias_de_aula, data_de_vencimento, diagnostico, objetivo, conduta) VALUES(" +
                    ficha.paciente.id + ", '" + ficha.dataDaAvaliacao.ToString("yyyy/MM/dd") + "', '" + ficha.dataProxAvaliacao.ToString("yyyy/MM/dd") + "', '" + ficha.diasDeAula +
                    "', '" + ficha.dataDeVencimento.ToString("yyyy/MM/dd") + "', '" + ficha.diagnostico + "', '" + ficha.objetivo +
                    "', '" + ficha.conduta + "');";

                //Executando o comando.
                this.comandoMysql.ExecuteNonQuery();

                //Comitando a trasacao.
                this.transacaoMysql.Commit();

                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial;
                throw new Exception("Não possível realizar o cadastro!", ex);
            }
            finally
            {
                //Finaliza operacao.
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Alterar ficha de avaliacao.
        /// </summary>
        /// <param name="ficha">Objeto com dados.</param>
        /// <returns>Retorna true se a ficha foi alterada se não false.</returns>
        public Boolean alterar(FichaDeAvaliacao ficha)
        {
            //Obtendo dados para conexao
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes.
            try
            {
                this.comandoMysql.CommandText = "UPDATE " + FichaDeAvaliacao.entidade + " SET paciente_id = " + ficha.paciente.id +
                    ", data_da_avaliacao = '" + ficha.dataDaAvaliacao.ToString("yyyy/MM/dd") + "', data_prox_avaliacao = '" + ficha.dataProxAvaliacao.ToString("yyyy/MM/dd") +
                    "', dias_de_aula = '" + ficha.diasDeAula + "', data_de_vencimento = '" + ficha.dataDeVencimento.ToString("yyyy/MM/dd") +
                    "', diagnostico = '" + ficha.diagnostico + "', objetivo = '" + ficha.objetivo + "', conduta = '" + ficha.conduta +
                    "' WHERE id = " + ficha.id + ";";

                //Executando comando SQL.
                this.comandoMysql.ExecuteNonQuery();

                //Comitando transacao.
                this.transacaoMysql.Commit();

                //Retorno.
                retorno = true;
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback();//Retorna ao ponto inicial
                throw new Exception("Não foi possível alterar o cadastro!", ex);
            }
            finally
            {
                //Finalizando operacao.
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Excluir ficha de avaliacao.
        /// </summary>
        /// <param name="id">Chave primária da tabela Ficha de Avalicao.</param>
        /// <returns>Retorna true se a ficha foi excluida se não false.</returns>
        public Boolean excluir(int id)
        {
            //Obtendo dados para conexao.
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes
            try
            {
                //Montando o SQL.
                this.comandoMysql.CommandText = "DELETE FROM " + FichaDeAvaliacao.entidade + " WHERE id = " + id;

                //Executando comando.
                this.comandoMysql.ExecuteNonQuery();

                //Comitando transacao.
                this.transacaoMysql.Commit();

                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    this.transacaoMysql.Rollback();//Retornando ao ponto inicial.    
                    throw new Exception("Esta ficha da avaliação não pode ser excluida, pois, possui dados vinculados a ela no sistema.", ex);
                }
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não possíveil excluir o cadastro!", ex);
            }
            finally
            {
                //Finalizando transacao.
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;

            }
            return retorno;
        }

        /// <summary>
        /// Retorna tabela de dados.
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            //Obtendo dados para conexao.
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes.
            try
            {
                this.comandoMysql.CommandText = "SELECT ficha_de_avaliacao.id AS ID, paciente_id AS 'ID DO PACIENTE', paciente.nome AS 'NOME DO PACIENTE',"+
                    " data_da_avaliacao AS 'DATA DA AVALIAÇÃO', " +
                    "data_prox_avaliacao AS 'PRÓXIMA AVALIACÃO', dias_de_aula AS 'DIAS DE AULA', data_de_vencimento AS " +
                    "'VENCIMENTO', diagnostico AS 'DIAGNÓSTICO', objetivo AS OBJETIVO, conduta AS CONDUTA FROM " +
                    FichaDeAvaliacao.entidade + " INNER JOIN PACIENTE ON(PACIENTE.ID = ficha_de_avaliacao.paciente_id)" +
                    " ORDER BY data_da_avaliacao ASC;";

                //Executando o comando
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);

                //Comitando transacao.
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não possível obter dados!", ex);
            }
            finally
            {
                //Finalizando operacao.
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }


            return retorno;
        }

        public DataTable getDataTable(String Filtro , String Pesquisa)
        {
            //Obtendo dados para conexao.
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes.
            try
            {
                this.comandoMysql.CommandText = "SELECT ficha_de_avaliacao.id AS ID, paciente_id AS 'ID DO PACIENTE', paciente.nome AS 'NOME DO PACIENTE', data_da_avaliacao AS 'DATA DA AVALIAÇÃO', " +
                    "data_prox_avaliacao AS 'PRÓXIMA AVALIAÇÃO', dias_de_aula AS 'DIAS DE AULA', data_de_vencimento AS " +
                    "'VENCIMENTO', diagnostico AS DIAGNOSTICO, objetivo AS OBJETIVO, conduta AS CONDUTA FROM " +
                    FichaDeAvaliacao.entidade + " INNER JOIN PACIENTE ON (PACIENTE.ID = ficha_de_avaliacao.paciente_id)" + " WHERE " + Filtro + " LIKE" + " '%"+Pesquisa+"%'"+" ORDER BY data_da_avaliacao ASC;";

                //Executando o comando
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);

                //Comitando transacao.
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não possível obter dados!", ex);
            }
            finally
            {
                //Finalizando operacao.
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }


            return retorno;
        }


    }
}
