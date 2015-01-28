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
    class FisioterapeutaDAO
    {
        //globais
        private MySqlConnection connMysql;
        private MySqlTransaction transacaoMysql;
        private MySqlCommand comandoMysql;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="conn"></param>
        public FisioterapeutaDAO(MySqlConnection conn)
        {
            this.connMysql = conn;
        }

        /// <summary>
        /// Este método verifica através do cpf se o fisioterapeuta já foi cadastrado.
        /// </summary>
        /// <returns>True e False</returns>
        public Boolean existeFisioterapeuta(String cpf)
        {
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            try
            {
                this.comandoMysql.CommandText = "SELECT * FROM " + Fisioterapeuta.entidade + " WHERE cpf = '" + cpf + "';";
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
        /// Cadastrar Fisioterapeuta
        /// </summary>
        /// <param name="fisioterapeuta">Ojeto com dados</param>
        /// <returns>Retorna True se o fisioterapeuta for cadastrado se não false.</returns>
        public Boolean cadastrar(Fisioterapeuta fisioterapeuta)
        {
            //Obtendo dados para Conexao
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "INSERT INTO " + Fisioterapeuta.entidade + "(clinica_id, nome, cpf, rg, crefito, " +
                    "especializacao, sexo, data_de_nasc, estado_civil, logradouro, numero, complemento, bairro, cep, cidade, uf, telefone, " +
                    "celular, email) VALUES (" + fisioterapeuta.clinica.id + ", '" + fisioterapeuta.nome + "', '" + fisioterapeuta.cpf + 
                    "', '" + fisioterapeuta.rg + "', '" + fisioterapeuta.crefito  + "', '" + fisioterapeuta.especializacao + 
                    "', '" + fisioterapeuta.sexo +"', '" + fisioterapeuta.dataDeNascimento.ToString("yyyy/MM/dd") +"', '" + fisioterapeuta.estadoCivil + 
                    "', '" + fisioterapeuta.logradouro + "', " + fisioterapeuta.numero + ", '" + fisioterapeuta.complemento  +
                    "', '" + fisioterapeuta.bairro + "', '" + fisioterapeuta.cep  + "', '" + fisioterapeuta.cidade + "', '" + fisioterapeuta.uf +
                    "', '" + fisioterapeuta.telefone + "', '" + fisioterapeuta.celular  +"', '" + fisioterapeuta.email + "');";

                //Executando o SQL.
                this.comandoMysql.ExecuteNonQuery();

                //Comintando a transação.
                this.transacaoMysql.Commit();

                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Volta ao ponto inicial
                throw new Exception("Não possível realizar o cadastro!", ex);
            }
            finally 
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Método alterar fisioterapeuta
        /// </summary>
        /// <param name="fisioterapeura">Objeto com dados</param>
        /// <returns>Retorna True se o fisioterapeuta for cadastrado se não false.</returns>
        public Boolean alterar(Fisioterapeuta fisioterapeura)
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
                this.comandoMysql.CommandText = "UPDATE " + Fisioterapeuta.entidade + " SET clinica_id = " + fisioterapeura.clinica.id +
                    ", nome = '" + fisioterapeura.nome + "' , cpf = '" + fisioterapeura.cpf + "', rg = '" + fisioterapeura.rg +
                    "', crefito = '" + fisioterapeura.crefito + "', especializacao = '" +  fisioterapeura.especializacao +
                    "', sexo = '" + fisioterapeura.sexo + "', data_de_nasc = '" + fisioterapeura.dataDeNascimento.ToString("yyyy/MM/dd") + 
                    "', estado_civil = '" + fisioterapeura.estadoCivil + "', logradouro = '" + fisioterapeura.logradouro + 
                    "', numero = " + fisioterapeura.numero + ", complemento = '" + fisioterapeura.complemento + 
                    "', bairro = '" + fisioterapeura.bairro + "', cep = '" + fisioterapeura.cep + 
                    "', cidade = '" + fisioterapeura.cidade + "', uf = '" + fisioterapeura.uf + 
                    "', telefone = '" + fisioterapeura.telefone + "', celular = '" + fisioterapeura.celular +
                    "', email = '" + fisioterapeura.email + "' WHERE id = " + fisioterapeura.id + ";";

                //Executando comando SQL
                this.comandoMysql.ExecuteNonQuery();

                //Comitando
                this.transacaoMysql.Commit();

                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não foi possível alterar o cadastro", ex);
            }
            finally
            {
                //Finalizando operação
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }


        /// <summary>
        /// Método excluir fisioterapeuta.
        /// </summary>
        /// <param name="id">Chave primária da tabela Fisioterapeuta.</param>
        /// <returns>Retorna True se o fisioterapeuta foi excluido se não false.</returns>
        public Boolean excluir(int id)
        {
            //Obtendo dados para conexao
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;
            
            //Tratamento de excecao
            try
            {
                //Montando SQL
                this.comandoMysql.CommandText = "DELETE FROM " + Fisioterapeuta.entidade + " WHERE id = " + id + ";";

                //Executando o comando
                this.comandoMysql.ExecuteNonQuery();

                //Comitando a transacao
                this.transacaoMysql.Commit();
                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    this.transacaoMysql.Rollback();//Retornando ao ponto inicial.    
                    throw new Exception("Este(a) fisioterapeuta não pode ser excluida, pois, possui dados vinculados a ele(a) no sistema.", ex);
                }
                this.transacaoMysql.Rollback();//Retorna ao ponto inicial
                throw new Exception("Não foi possível excluir o cadastro", ex);
            }
            finally
            {
                //Finalizando operacao
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
            //Obtendo dados para conexao
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes.
            try
            {
                //Montando SQL.
                this.comandoMysql.CommandText = "SELECT id AS ID, clinica_id AS 'ID DA CLINICA', nome AS NOME, cpf AS CPF, rg AS RG, " +
                        "crefito AS CREFITO, especializacao AS ESPECIALIZACAO, sexo AS SEXO, data_de_nasc AS 'DATA DE NASCIMENTO', " +
                        "estado_civil AS 'ESTADO CIVIL', logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, " +
                        "cep AS CEP, cidade AS CIDADE, uf AS UF, telefone AS TELEFONE, celular AS CELULAR, email AS EMAIL FROM " +
                        Fisioterapeuta.entidade + " ORDER BY nome ASC;";

                //Executando SQL.
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);

                //Comitando trasacao.
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não foi possívei obter dados", ex);
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

        public DataTable getDataTable(String Filtro, String Pesquisa)
        {
            //Obtendo dados para conexao
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de excecoes.
            try
            {
                //Montando SQL.
                this.comandoMysql.CommandText = "SELECT id AS ID, clinica_id AS 'ID DA CLINICA', nome AS NOME, cpf AS CPF, rg AS RG, " +
                        "crefito AS CREFITO, especializacao AS ESPECIALIZACAO, sexo AS SEXO, data_de_nasc AS 'DATA DE NASCIMENTO', " +
                        "estado_civil AS 'ESTADO CIVIL', logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, " +
                        "cep AS CEP, cidade AS CIDADE, uf AS UF, telefone AS TELEFONE, celular AS CELULAR, email AS EMAIL FROM " +
                        Fisioterapeuta.entidade + " WHERE " + Filtro + " LIKE" + " '%"+Pesquisa+"%'"+   " ORDER BY nome ASC;";

                //Executando SQL.
                MySqlDataAdapter adapter = new MySqlDataAdapter(this.comandoMysql);
                retorno = new DataTable();
                adapter.Fill(retorno);

                //Comitando trasacao.
                this.transacaoMysql.Commit();
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Retorna ao ponto inicial.
                throw new Exception("Não foi possívei obter dados", ex);
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


