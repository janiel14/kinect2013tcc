using CaptorKinect.modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.dao
{
    class EsqueletoDAO
    {
        //Atributos
        private MySqlConnection connMysql;
        private MySqlTransaction transacaoMysql;
        private MySqlCommand comandoMysql;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="conn">MySqlConnection</param>
        public EsqueletoDAO(MySqlConnection conn)
        {
            this.connMysql = conn;
        }
        /// <summary>
        /// Gravar
        /// </summary>
        /// <param name="esqueletos">Lista de esqueletos</param>
        /// <returns>Boolean</returns>
        public Boolean gravar(List<Esqueleto> esqueletos,int sessaoId)
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
                //Listando esqueletos
                foreach (var esq in esqueletos)
                {
                    //Gravando body
                    this.comandoMysql.CommandText = "INSERT INTO " + Body.entidade +
                        " (sessao_id,x,y,z,tempo) VALUES (" +
                        esq.body.sessao.id + "," +
                        "'" + esq.body.X.ToString().Replace(",",".") + "'," +
                        "'" + esq.body.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.body.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.body.tempo + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando head
                    this.comandoMysql.CommandText = "INSERT INTO " + Head.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.head.sessao.id + "," +
                        "'" + esq.head.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.head.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.head.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.head.angulo + "'," +
                        "'" + esq.head.tempo + "'," +
                        "'" + esq.head.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando shoulder center
                    this.comandoMysql.CommandText = "INSERT INTO " + ShoulderCenter.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.shoulderCenter.sessao.id + "," +
                        "'" + esq.shoulderCenter.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderCenter.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderCenter.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderCenter.angulo + "'," +
                        "'" + esq.shoulderCenter.tempo + "'," +
                        "'" + esq.shoulderCenter.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando shoulder right
                    this.comandoMysql.CommandText = "INSERT INTO " + ShoulderRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.shoulderRight.sessao.id + "," +
                        "'" + esq.shoulderRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderRight.angulo + "'," +
                        "'" + esq.shoulderRight.tempo + "'," +
                        "'" + esq.shoulderRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Elbow right
                    this.comandoMysql.CommandText = "INSERT INTO " + ElbowRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.elbowRight.sessao.id + "," +
                        "'" + esq.elbowRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowRight.angulo + "'," +
                        "'" + esq.elbowRight.tempo + "'," +
                        "'" + esq.elbowRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Wrist right
                    this.comandoMysql.CommandText = "INSERT INTO " + WristRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.wristRight.sessao.id + "," +
                        "'" + esq.wristRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristRight.angulo + "'," +
                        "'" + esq.wristRight.tempo + "'," +
                        "'" + esq.wristRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Hand right
                    this.comandoMysql.CommandText = "INSERT INTO " + HandRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.handRight.sessao.id + "," +
                        "'" + esq.handRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handRight.angulo + "'," +
                        "'" + esq.handRight.tempo + "'," +
                        "'" + esq.handRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Shoulder left
                    this.comandoMysql.CommandText = "INSERT INTO " + ShoulderLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.shoulderLeft.sessao.id + "," +
                        "'" + esq.shoulderLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.shoulderLeft.angulo + "'," +
                        "'" + esq.shoulderLeft.tempo + "'," +
                        "'" + esq.shoulderLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Elbow left
                    this.comandoMysql.CommandText = "INSERT INTO " + ElbowLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.elbowLeft.sessao.id + "," +
                        "'" + esq.elbowLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.elbowLeft.angulo + "'," +
                        "'" + esq.elbowLeft.tempo + "'," +
                        "'" + esq.elbowLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Wrist left
                    this.comandoMysql.CommandText = "INSERT INTO " + WristLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.wristLeft.sessao.id + "," +
                        "'" + esq.wristLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.wristLeft.angulo + "'," +
                        "'" + esq.wristLeft.tempo + "'," +
                        "'" + esq.wristLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Hand left
                    this.comandoMysql.CommandText = "INSERT INTO " + HandLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.handLeft.sessao.id + "," +
                        "'" + esq.handLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.handLeft.angulo + "'," +
                        "'" + esq.handLeft.tempo + "'," +
                        "'" + esq.handLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Spine
                    this.comandoMysql.CommandText = "INSERT INTO " + Spine.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.spine.sessao.id + "," +
                        "'" + esq.spine.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.spine.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.spine.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.spine.angulo + "'," +
                        "'" + esq.spine.tempo + "'," +
                        "'" + esq.spine.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Hip Center
                    this.comandoMysql.CommandText = "INSERT INTO " + HipCenter.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.hipCenter.sessao.id + "," +
                        "'" + esq.hipCenter.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipCenter.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipCenter.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipCenter.angulo + "'," +
                        "'" + esq.hipCenter.tempo + "'," +
                        "'" + esq.hipCenter.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Hip Right
                    this.comandoMysql.CommandText = "INSERT INTO " + HipRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.hipRight.sessao.id + "," +
                        "'" + esq.hipRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipRight.angulo + "'," +
                        "'" + esq.hipRight.tempo + "'," +
                        "'" + esq.hipRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Knee Right
                    this.comandoMysql.CommandText = "INSERT INTO " + KneeRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.kneeRight.sessao.id + "," +
                        "'" + esq.kneeRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeRight.angulo + "'," +
                        "'" + esq.kneeRight.tempo + "'," +
                        "'" + esq.kneeRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Ankle Right
                    this.comandoMysql.CommandText = "INSERT INTO " + AnkleRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.ankleRight.sessao.id + "," +
                        "'" + esq.ankleRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleRight.angulo + "'," +
                        "'" + esq.ankleRight.tempo + "'," +
                        "'" + esq.ankleRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Foot Right
                    this.comandoMysql.CommandText = "INSERT INTO " + FootRight.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.footRight.sessao.id + "," +
                        "'" + esq.footRight.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footRight.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footRight.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footRight.angulo + "'," +
                        "'" + esq.footRight.tempo + "'," +
                        "'" + esq.footRight.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Hip Left
                    this.comandoMysql.CommandText = "INSERT INTO " + HipLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.hipLeft.sessao.id + "," +
                        "'" + esq.hipLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.hipLeft.angulo + "'," +
                        "'" + esq.hipLeft.tempo + "'," +
                        "'" + esq.hipLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Knee Left
                    this.comandoMysql.CommandText = "INSERT INTO " + KneeLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.kneeLeft.sessao.id + "," +
                        "'" + esq.kneeLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.kneeLeft.angulo + "'," +
                        "'" + esq.kneeLeft.tempo + "'," +
                        "'" + esq.kneeLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Ankle left
                    this.comandoMysql.CommandText = "INSERT INTO " + AnkleLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.ankleLeft.sessao.id + "," +
                        "'" + esq.ankleLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.ankleLeft.angulo + "'," +
                        "'" + esq.ankleLeft.tempo + "'," +
                        "'" + esq.ankleLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                    //Gravando Foot left
                    this.comandoMysql.CommandText = "INSERT INTO " + FootLeft.entidade +
                        " (sessao_id,x,y,z,angulo,tempo,velocidade) VALUES (" +
                        esq.footLeft.sessao.id + "," +
                        "'" + esq.footLeft.X.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footLeft.Y.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footLeft.Z.ToString().Replace(",", ".") + "'," +
                        "'" + esq.footLeft.angulo + "'," +
                        "'" + esq.footLeft.tempo + "'," +
                        "'" + esq.footLeft.velocidade + "')";
                    this.comandoMysql.ExecuteNonQuery();
                }
                //Concluindo sessão
                this.comandoMysql.CommandText = "UPDATE " + Sessoes.entidade + " SET situacao='Concluida' WHERE id=" + sessaoId;
                this.comandoMysql.ExecuteNonQuery();
                this.transacaoMysql.Commit(); //Comitando transação.
                retorno = true; // Retorno
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Rertornando ao ponto inicial.
                throw new Exception("Não foi possível gravar informações!", ex);
            }
            catch (Exception ex)
            {
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível gravar informações!", ex);
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
        /// Verifica se há uma sessão liberada
        /// </summary>
        /// <returns></returns>
        public Sessoes getSessaoLiberada()
        {
            Sessoes retorno = null;
            this.connMysql.Open(); //Abri a conexão com o MySQL.
            this.transacaoMysql = this.connMysql.BeginTransaction(); // Inicia transação.
            this.comandoMysql = this.connMysql.CreateCommand(); // Cria o camando SQL.
            this.comandoMysql.Transaction = this.transacaoMysql; //Atribui a transação para o comando.
            this.comandoMysql.Connection = this.connMysql;

            //Tratamento de exceções
            try
            {
                this.comandoMysql.CommandText = "SELECT" +
                    " se.id AS ID," +
                    " se.clinica_id AS ID_CLINICA," +
                    " se.fisioterapeuta_id AS ID_FISIO," +
                    " se.paciente_id AS ID_PACIENTE," +
                    " se.situacao AS SITUACAO," +
                    " se.data AS DATA," +
                    " se.hora AS HORA," +
                    " fi.nome AS FISIOTERAPEUTA," +
                    " pa.nome AS PACIENTE " +
                    " FROM " + Sessoes.entidade + " se" +
                    " JOIN " + Fisioterapeuta.entidade + " fi" +
                    " ON(fi.id=se.fisioterapeuta_id)" +
                    " JOIN " + Paciente.entidade + " pa" +
                    " ON(pa.id=se.paciente_id)" +
                    " WHERE se.situacao='Liberada'";
                MySqlDataReader rd = this.comandoMysql.ExecuteReader();
                //Verifica se há linhas
                if (rd.HasRows)
                {
                    rd.Read();
                    retorno = new Sessoes(rd.GetInt32("ID"),
                        new Clinica(rd.GetInt32("ID_CLINICA"), null, null, null, 0, null, null, null, null, null, null, null, null),
                        new Fisioterapeuta(rd.GetInt32("ID_FISIO"),
                            null, rd.GetString("FISIOTERAPEUTA"), null, null, null, null, null,
                            DateTime.Now, null, null, 0, null, null, null, null, null, null,null,null),
                        new Paciente(rd.GetInt32("ID_PACIENTE"), null, rd.GetString("PACIENTE"), null, null, null, DateTime.Now, null, null, null, 0, null, null, null, null, null, null, null, null, null,DateTime.Now),
                        rd.GetString("SITUACAO"), rd.GetDateTime("DATA"), DateTime.Now, null);
                }
                //Fecha data header
                rd.Close();

                this.transacaoMysql.Commit(); //Comitando transação.
            }
            catch (MySqlException ex)
            {
                this.transacaoMysql.Rollback(); //Rertornando ao ponto inicial.
                throw new Exception("Não foi possível gravar informações!", ex);
            }
            catch (Exception ex)
            {
                this.transacaoMysql.Rollback();
                throw new Exception("Não foi possível gravar informações!", ex);
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
