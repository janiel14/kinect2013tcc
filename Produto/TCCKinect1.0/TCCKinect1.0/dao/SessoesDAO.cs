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
    class SessoesDAO
    {
        //Atributos
        MySqlConnection connMysql;
        MySqlTransaction transacaoMysql;
        MySqlCommand comandoMysql;


        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="connMysql">Conexao com o BD</param>
        public SessoesDAO(MySqlConnection connMysql)
        {
            this.connMysql = connMysql;
        }


        /// <summary>
        /// Método cadastrar sessao.
        /// </summary>
        /// <param name="sessoes">Objeto com dados</param>
        /// <returns>Retorna True se a sessao foi cadastrado se não false.</returns>
        public Boolean cadastrar(Sessoes sessoes)
        {
            Boolean retorno = false;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções
            try
            {
                //Montando o SQL
                this.comandoMysql.CommandText = "INSERT INTO " + Sessoes.entidade + "(id, clinica_id, fisioterapeuta_id, paciente_id, situacao, data, " +
                    "hora, observacao) VALUES(@id, @clinica_id, @fisioterapeuta_id, @paciente_id, @situacao, @data, @hora, @observacao);";
                this.comandoMysql.Parameters.AddWithValue("@id", sessoes.id);
                this.comandoMysql.Parameters.AddWithValue("@clinica_id", sessoes.clinica.id);
                this.comandoMysql.Parameters.AddWithValue("@fisioterapeuta_id", sessoes.fisioterapeuta.id);
                this.comandoMysql.Parameters.AddWithValue("@paciente_id", sessoes.paciente.id);
                this.comandoMysql.Parameters.AddWithValue("@situacao", sessoes.situacao);
                this.comandoMysql.Parameters.AddWithValue("@data", sessoes.data.ToString("yyyy/MM/dd"));
                this.comandoMysql.Parameters.AddWithValue("@hora", sessoes.hora.ToString("HH:mm"));
                this.comandoMysql.Parameters.AddWithValue("@observacao", sessoes.observacao);
                this.comandoMysql.Prepare();
                this.comandoMysql.ExecuteNonQuery();
                    
                //this.comandoMysql.ExecuteNonQuery();//Executa o código SQL acima.
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
        /// Método Alterar sessao
        /// </summary>
        /// <param name="sessoes">Objeto com dados</param>
        /// <returns>Retorna True se a sessao foi cadastrado se não false.</returns>
        public Boolean alterar(Sessoes sessoes)
        {
            Boolean retorno = false;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções
            try
            {
                //Montando o SQL
                this.comandoMysql.CommandText = "UPDATE " + Sessoes.entidade + " SET clinica_id = @clinica_id, fisioterapeuta_id = @fisioterapeuta_id, " +
                "paciente_id = @paciente_id, situacao = @situacao, data = @data, hora = @hora, observacao = @observacao WHERE id = @id";
                this.comandoMysql.Parameters.AddWithValue("@clinica_id", sessoes.clinica.id);
                this.comandoMysql.Parameters.AddWithValue("@fisioterapeuta_id", sessoes.fisioterapeuta.id);
                this.comandoMysql.Parameters.AddWithValue("@paciente_id", sessoes.paciente.id);
                this.comandoMysql.Parameters.AddWithValue("@situacao", sessoes.situacao);
                this.comandoMysql.Parameters.AddWithValue("@data", sessoes.data.ToString("yyyy/MM/dd"));
                this.comandoMysql.Parameters.AddWithValue("@hora", sessoes.hora.ToString("HH:mm"));
                this.comandoMysql.Parameters.AddWithValue("@observacao", sessoes.observacao);
                this.comandoMysql.Parameters.AddWithValue("@id", sessoes.id);
                this.comandoMysql.Prepare();

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
        /// Método excluir sessao.
        /// </summary>
        /// <param name="id">Chave primária da tabela sessao</param>
        /// <returns>Retorna True se a sessao foi excluida se não false.</returns>
        public Boolean excluir(int id)
        {
            Boolean retorno = false;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                //Montando o SQL.
                this.comandoMysql.CommandText = "DELETE FROM " + Sessoes.entidade + " WHERE id = @id;";
                this.comandoMysql.Parameters.AddWithValue("@id", id);
                this.comandoMysql.Prepare();

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
                    throw new Exception("Esta sessão não pode ser excluida, pois, possui dados vinculados a ela no sistema.", ex);
                }
                this.transacaoMysql.Rollback();//Retornando ao ponto inicial.
                throw new Exception("Não foi possível excluir o cadastro.", ex);
            }
            finally
            {
                this.connMysql.Close();
                this.comandoMysql = null;
                this.transacaoMysql = null;
            }
            return retorno;
        }

        /// <summary>
        /// Este método retorna um DataTable de todos as sessoes cadastras.
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            ///Obtendos dados para conexão.
            DataTable retorno = null;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                this.comandoMysql.CommandText = "SELECT " +
                    "ses.id AS ID," +
                    "ses.clinica_id 'CLINICA ID'," +
                    "ses.fisioterapeuta_id AS 'FISIOTERAPEUTA ID'," +
                    "ses.paciente_id AS 'PACIENTE ID'," +
                    "cli.nome_fantasia AS 'CLÍNICA'," +
                    "fis.nome AS 'FISIOTERAPEUTA'," +
                    "pac.nome AS 'PACIENTE'," +
                    "ses.situacao AS 'SITUAÇÃO'," +
                    "ses.data AS 'DATA'," +
                    "ses.hora AS 'HORAS'," +
                    "ses.observacao AS 'OBSERVAÇÃO'" +
                    " FROM " + Sessoes.entidade + " ses" +
                    " JOIN " + Paciente.entidade + " pac ON(ses.paciente_id=pac.id)" +
                    " JOIN " + Clinica.entidade + " cli ON(cli.id = ses.clinica_id)" +
                    " JOIN " + Fisioterapeuta.entidade + " fis ON(fis.id = ses.fisioterapeuta_id)" +
                    " ORDER BY pac.nome ASC";

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


        /// <summary>
        /// Este método retorna um DataTable das sessoes cadastras conforme o filtro e pesquisa.
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable(String filtro, String pesquisa)
        {
            ///Obtendos dados para conexão.
            DataTable retorno = null;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                this.comandoMysql.CommandText =
                    "SELECT " +
                    "ses.id AS ID," +
                    "ses.clinica_id 'CLINICA ID'," +
                    "ses.fisioterapeuta_id AS 'FISIOTERAPEUTA ID'," +
                    "ses.paciente_id AS 'PACIENTE ID'," +
                    "cli.nome_fantasia AS 'CLÍNICA'," +
                    "fis.nome AS 'FISIOTERAPEUTA'," +
                    "pac.nome AS 'PACIENTE'," +
                    "ses.situacao AS 'SITUAÇÃO'," +
                    "ses.data AS 'DATA'," +
                    "ses.hora AS 'HORAS'," +
                    "ses.observacao AS 'OBSERVAÇÃO'" +
                    " FROM " + Sessoes.entidade + " ses" +
                    " JOIN " + Paciente.entidade + " pac ON(ses.paciente_id=pac.id)" +
                    " JOIN " + Clinica.entidade + " cli ON(cli.id = ses.clinica_id)" +
                    " JOIN " + Fisioterapeuta.entidade + " fis ON(fis.id = ses.fisioterapeuta_id) WHERE "+ filtro +
                    " LIKE @pesquisa ORDER BY pac.nome ASC;";

                this.comandoMysql.Parameters.AddWithValue("@pesquisa", String.Format("%{0}%", pesquisa));
                this.comandoMysql.Prepare();
                
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

        /// <summary>
        /// Este método retorna um DataTable das sessoes cadastras conforme o filtro e pesquisa.
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable(int pacienteId)
        {
            ///Obtendos dados para conexão.
            DataTable retorno = null;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = new MySqlCommand(null, this.connMysql); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções.
            try
            {
                this.comandoMysql.CommandText = "SELECT id AS ID," +
                    " CONCAT(DATE_FORMAT(data,'%d/%m/%Y'),' - ',DATE_FORMAT(hora,'%H:%i:%s')) AS SESSAO" +
                    " FROM sessao" +
                    " WHERE paciente_id=@pacienteId AND situacao='Concluida' ORDER BY SESSAO ASC";
                this.comandoMysql.Parameters.AddWithValue("@pacienteId", pacienteId);
                this.comandoMysql.Prepare();

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

        /// <summary>
        /// Verifica se já existe uma sessão LIBERADA
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Boolean verificaSessao()
        {
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            try
            {
                this.comandoMysql.CommandText = "SELECT * FROM " + Sessoes.entidade + " WHERE situacao = 'liberada';";
                this.comandoMysql.ExecuteNonQuery(); //Executa o comando.
                this.transacaoMysql.Commit(); //Comitando transação

                MySqlDataReader dr = comandoMysql.ExecuteReader();
                if (dr.HasRows == true)
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
        /// Libera sessão.
        /// </summary>
        /// <returns>Retorna true se a sesão foi liberada.</returns>
        public Boolean liberaSessao(int id)
        {
            Boolean retorno = false;
            this.connMysql.Open();
            this.transacaoMysql = this.connMysql.BeginTransaction();
            this.comandoMysql = this.connMysql.CreateCommand();
            this.comandoMysql.Transaction = this.transacaoMysql;
            this.comandoMysql.Connection = this.connMysql;

            try
            {
                this.comandoMysql.CommandText = "UPDATE " + Sessoes.entidade + " SET situacao = 'Liberada' WHERE id = @id;";
                this.comandoMysql.Parameters.AddWithValue("@id", id);
                this.comandoMysql.Prepare();
                this.comandoMysql.ExecuteNonQuery(); //Executa o comando.
                this.transacaoMysql.Commit(); //Comitando transação
                retorno = true;
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
    }
}
