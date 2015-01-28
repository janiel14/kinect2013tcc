using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.modelo
{
    class Sessoes
    {
        //Métodos
        public static String entidade = "sessao";
        public int id { get; set; }
        public Clinica clinica { get; set; }
        public Fisioterapeuta fisioterapeuta { get; set; }
        public Paciente paciente { get; set; }
        public String situacao { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
        public String observacao { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Sessoes()
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica">Objeto</param>
        /// <param name="fisioterapeuta">Objeto</param>
        /// <param name="paciente">Objeto</param>
        /// <param name="situacao"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="observacao"></param>
        public Sessoes(int id, Clinica clinica, Fisioterapeuta fisioterapeuta, Paciente paciente, String situacao,
            DateTime data, DateTime hora, String observacao)
        {
            this.id = id;
            this.clinica = clinica;
            this.fisioterapeuta = fisioterapeuta;
            this.paciente = paciente;
            this.situacao = situacao;
            this.data = data;
            this.hora = hora;
            this.observacao = observacao;
        }

    }
}
