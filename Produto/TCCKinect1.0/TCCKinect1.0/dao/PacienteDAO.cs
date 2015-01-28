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
    class PacienteDAO
    {
        //Atributos
        private MySqlConnection connMysql;
        private MySqlTransaction transacaoMysql;
        private MySqlCommand comandoMysql;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="conn"></param>
        public PacienteDAO(MySqlConnection conn)
        {
            this.connMysql = conn;
        }

        /// <summary>
        /// Este método verifica através do cpf se o paciente já foi cadastrado.
        /// </summary>
        /// <returns>True e False</returns>
        public Boolean existePaciente(String cpf)
        {
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            try
            {
                this.comandoMysql.CommandText = "SELECT * FROM " + Paciente.entidade + " WHERE cpf = '" + cpf + "';";
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
        /// Método cadastrar Paciente.
        /// </summary>
        /// <param name="paciente">Objeto com dados</param>
        /// <returns>Retorna True se o paciente foi cadastrado se não false.</returns>
        public Boolean cadastrar(Paciente paciente)
        {
            Boolean retorno = false;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction(); // Inicia transação.
            this.comandoMysql = this.connMysql.CreateCommand(); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções
            try
            {
                //Montando o SQL
                this.comandoMysql.CommandText = "INSERT INTO " + Paciente.entidade + "(id, clinica_id, nome, cpf, rg, sexo, " +
                    "data_de_nasc, estado_civil, profissao, logradouro, numero, complemento, bairro, cep, cidade, uf, telefone, celular, email, " +
                    "observacao, data_do_cadastro) VALUES (" + paciente.id + ", " + paciente.clinica.id + " , '" + paciente.nome + "' , '" +
                    paciente.cpf + "', '" + paciente.rg + "', '" + paciente.sexo + "', '" + paciente.dataDeNascimento.ToString("yyyy/MM/dd") + "', '" + 
                    paciente.estadoCivil + "', '" + paciente.profissao + "', '" + paciente.logradouro + "', " + paciente.numero + ", '" + 
                    paciente.complemento + "', '" + paciente.bairro + "', '"+ paciente.cep +"', '" + paciente.cidade + "', '" + paciente.uf + "', '" + 
                    paciente.telefone + "', '" + paciente.celular + "', '" + paciente.email + "', '" + paciente.observacao + "', '" +
                    paciente.dataDoCadastro.ToString("yyyy/MM/dd") + "');";

                this.comandoMysql.ExecuteNonQuery();//Executa o código SQL acima.
                this.transacaoMysql.Commit(); //Comitando transação.
                retorno = true; // Retorno
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Rertornando ao ponto inicial.
                throw new Exception("Não foi possível realizar o cadastro!", ex);
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
        /// Método Alterar Paciente
        /// </summary>
        /// <param name="paciente">Objeto com dados</param>
        /// <returns>Retorna True se o paciente foi cadastrado se não false.</returns>
        public Boolean alterar(Paciente paciente)
        {
            Boolean retorno = false;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction(); // Inicia transação.
            this.comandoMysql = this.connMysql.CreateCommand(); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções
            try
            {
                //Montando o SQL
                this.comandoMysql.CommandText = "UPDATE " + Paciente.entidade + " SET clinica_id = " + paciente.clinica.id +
                    ", nome = '" + paciente.nome + "', cpf = '" + paciente.cpf + "', rg = '" + paciente.rg + "', sexo = '" + paciente.sexo +
                    "', data_de_nasc = '" + paciente.dataDeNascimento.ToString("yyyy/MM/dd") + "', estado_civil = '" + paciente.estadoCivil +
                    "', profissao = '" + paciente.profissao + "', logradouro = '" + paciente.logradouro + "', complemento = '" + paciente.complemento +
                    "', numero = '" + paciente.numero + "', bairro = '" + paciente.bairro + "', cep = '" + paciente.cep + "', cidade = '" + paciente.cidade +
                    "', uf = '" + paciente.uf + "', telefone = '" + paciente.telefone + "', celular = '" + paciente.celular +
                    "', email = '" + paciente.email + "', observacao = '" + paciente.observacao +
                    "', data_do_cadastro = '" + paciente.dataDoCadastro.ToString("yyyy/MM/dd") + "' WHERE id = " + paciente.id;

                this.comandoMysql.ExecuteNonQuery(); //Executa o código SQL a cima.
                this.transacaoMysql.Commit(); //Comitando a transação.
                retorno = true;
            }
            catch (MySqlException ex)
            {
                //Retorna ao ponto inicial.
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível alterar o cadastro.", ex);
            }
            finally 
            {
                //Finalizando operação.
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Método excluir paciente.
        /// </summary>
        /// <param name="id">Chave primária da tabela paciente</param>
        /// <returns>Retorna True se o paciente foi excluido se não false.</returns>
        public Boolean excluir(int id)
        {
            //Obtendo dados para conexão.
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                //Montando o SQL.
                this.comandoMysql.CommandText = "DELETE FROM " + Paciente.entidade + " WHERE id = " + id;
                //Executando comando.
                this.comandoMysql.ExecuteNonQuery();
                //Comitando a transação.
                this.transacaoMysql.Commit();
                //Retorno
                retorno = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    this.transacaoMysql.Rollback();//Retornando ao ponto inicial.
                    throw new Exception("O paciente não pode ser excluido, pois, possui dados vinculados a ele no sistema.", ex);
                }
                this.transacaoMysql.Rollback();//Retornando ao ponto inicial.
                throw new Exception("Não foi possível excluir o cadastro", ex);
            }
            finally {
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Este método retorna um DataTable de todos os pacientes cadastras.
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable() 
        {
            ///Obtendos dados para conexão.
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;
            
            //Tratamento de exceções.
            try
            {
                this.comandoMysql.CommandText = "SELECT id AS ID, clinica_id AS 'ID DA CLINICA', nome AS NOME, cpf AS CPF, rg AS RG, " +
                    "sexo AS SEXO, data_de_nasc AS 'DATA DE NASCIMENTO', estado_civil AS 'ESTADO CIVIL', profissao AS PROFISSAO, " +
                    "logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, cep AS CEP, " +
                    "cidade AS CIDADE, uf AS UF, " +
                    "telefone AS TELEFONE, celular AS CELULAR, email AS 'E-MAIL', observacao AS OBSERVACAO, " +
                    "data_do_cadastro  AS 'DATA DO CADASTRO' FROM " + Paciente.entidade + " ORDER BY nome ASC;";

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
                throw new Exception("Não possível obter dados", ex);
            }
            finally
            {
                //Finalizando operação.
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }

        public DataTable getDataTable(String filtro, String pesquisa)
        {
            ///Obtendos dados para conexão.
            DataTable retorno = null;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                this.comandoMysql.CommandText = "SELECT id AS ID, clinica_id AS 'ID DA CLINICA', nome AS NOME, cpf AS CPF, rg AS RG, " +
                    "sexo AS SEXO, data_de_nasc AS 'DATA DE NASCIMENTO', estado_civil AS 'ESTADO CIVIL', profissao AS PROFISSAO, " +
                    "logradouro AS LOGRADOURO, numero AS NUMERO, complemento AS COMPLEMENTO, bairro AS BAIRRO, cep AS CEP, " +
                    "cidade AS CIDADE, uf AS UF, " +
                    "telefone AS TELEFONE, celular AS CELULAR, email AS 'E-MAIL', observacao AS OBSERVACAO, " +
                    "data_do_cadastro  AS 'DATA DO CADASTRO' FROM " + Paciente.entidade + " WHERE " + filtro +
                    " LIKE '%" + pesquisa + "%' ORDER BY nome ASC;";

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
                throw new Exception("Não possível obter dados", ex);
            }
            finally
            {
                //Finalizando operação.
                this.connMysql.Close();
                this.transacaoMysql = null;
                this.comandoMysql = null;
            }
            return retorno;
        }
    }
}
