using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.modelo
{
    class WristLeft
    {
        //Métodos
        public static String entidade = "wrist_left";
        public int id { get; set; }
        public Sessoes sessao { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public Double Z { get; set; }
        public int angulo { get; set; }
        public int tempo { get; set; }
        public int velocidade { get; set; }
        /// <summary>
        /// Construtor
        /// </summary>
        public WristLeft()
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sessao">Objeto</param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="angulo"></param>
        /// <param name="tempo"></param>
        /// <param name="velocidade"></param>
        public WristLeft(int id, Sessoes sessao, Double X, Double Y, Double Z, int angulo, int tempo,
            int velocidade)
        {
            this.id = id;
            this.sessao = sessao;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.angulo = angulo;
            this.tempo = tempo;
            this.velocidade = velocidade;
        }
    }
}
