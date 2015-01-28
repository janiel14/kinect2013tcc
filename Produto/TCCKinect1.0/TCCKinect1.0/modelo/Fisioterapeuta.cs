using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCKinect1._0.modelo
{
    class Fisioterapeuta
    {
        public static String entidade = "fisioterapeuta";
        public int id { get; set; }
        public Clinica clinica { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string crefito { get; set; }
        public string especializacao { get; set; }
        public string sexo { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string estadoCivil { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Fisioterapeuta()
        {
        }


        /// <summary>
        /// Costrutor com parâmetros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica"></param>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        /// <param name="rg"></param>
        /// <param name="crefito"></param>
        /// <param name="especializacao"></param>
        /// <param name="sexo"></param>
        /// <param name="dataDeNascimento"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="logradouro"></param>
        /// <param name="numero"></param>
        /// <param name="complemento"></param>
        /// <param name="bairro"></param>
        /// <param name="cep"></param>
        /// <param name="cidade"></param>
        /// <param name="uf"></param>
        /// <param name="telefone"></param>
        /// <param name="celular"></param>
        /// <param name="email"></param>
        public Fisioterapeuta(int id, Clinica clinica, string nome, string cpf, string rg, string crefito, string especializacao,
            string sexo, DateTime dataDeNascimento, string estadoCivil, string logradouro, int numero, string complemento, string bairro,
            string cep, string cidade, string uf, string telefone, string celular, string email)
        {
            this.id = id;
            this.clinica = clinica;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
            this.crefito = crefito;
            this.especializacao = especializacao;
            this.sexo = sexo;
            this.dataDeNascimento = dataDeNascimento;
            this.estadoCivil = estadoCivil;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.uf = uf;
            this.telefone = telefone;
            this.celular = celular;
            this.email = email;
        }
    }
}