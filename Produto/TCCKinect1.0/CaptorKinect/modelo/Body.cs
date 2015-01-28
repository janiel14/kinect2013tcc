using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.modelo
{
    class Body
    {
        public static String entidade = "body";
        public int id { get; set; }
        public Sessoes sessao { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public Double Z { get; set; }
        public int tempo { get; set; }
        /// <summary>
        /// Construtor
        /// </summary>
        public Body()
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sessao"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="tempo"></param>
        public Body(int id, Sessoes sessao, Double X, Double Y, Double Z, int tempo)
        {
            this.id = id;
            this.sessao = sessao;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.tempo = tempo;
        }   
    }
}
