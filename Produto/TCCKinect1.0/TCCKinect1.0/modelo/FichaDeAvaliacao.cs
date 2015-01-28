using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCKinect1._0.modelo
{
    class FichaDeAvaliacao
    {
        public static String entidade = "ficha_de_avaliacao";
        public int id { get; set; }
        public Paciente paciente { get; set; }
        public DateTime dataDaAvaliacao { get; set; }
        public DateTime dataProxAvaliacao { get; set; }
        public string diasDeAula { get; set; }
        public DateTime dataDeVencimento { get; set; }
        public string diagnostico { get; set; }
        public string objetivo { get; set; }
        public string conduta { get; set; }

        /// <summary>
        /// Cosntrutor vazio.
        /// </summary>
        public FichaDeAvaliacao()
        {
        }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paciente"></param>
        /// <param name="dataDaAvalicao"></param>
        /// <param name="dataProxAvalicao"></param>
        /// <param name="diasDeAula"></param>
        /// <param name="dataDeVencimento"></param>
        /// <param name="diagnostico"></param>
        /// <param name="objetivo"></param>
        /// <param name="conduta"></param>
        public FichaDeAvaliacao(int id, Paciente paciente,DateTime dataDaAvaliacao, DateTime dataProxAvalicao, string diasDeAula, 
            DateTime dataDeVencimento, string diagnostico, string objetivo, string conduta)
        {
            this.id = id;
            this.paciente = paciente;
            this.dataDaAvaliacao = dataDaAvaliacao;
            this.dataProxAvaliacao = dataProxAvaliacao;
            this.diasDeAula = diasDeAula;
            this.dataDeVencimento = dataDeVencimento;
            this.diagnostico = diagnostico;
            this.objetivo = objetivo;
            this.conduta = conduta;
        }

    }
}
