using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TCCKinect1._0.util
{
    class Sessao
    {
        //Globais
        public MySqlConnection connMysql { get; set; }
        public String clinica { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Sessao()
        { }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="conn">String de conexão</param>
        public Sessao(MySqlConnection conn)
        {
            this.connMysql = conn;
        }
    }
}
