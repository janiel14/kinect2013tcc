using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.modelo
{
    class Paciente
    {
        public static String entidade = "paciente";
        private int p;
        private Clinica clinica1;
        public int id { get; set; }
        public Clinica clinica { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String sexo { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public String estadoCivil { get; set; }
        public String profissao { get; set; }
        public String logradouro { get; set; }
        public int numero { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String cep { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
        public String telefone { get; set; }
        public String celular { get; set; }
        public String email { get; set; }
        public String observacao { get; set; }
        public DateTime dataDoCadastro { get; set; }
        
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Paciente()
        {
        }

       /// <summary>
       /// Construtor com parâmetros
       /// </summary>
       /// <param name="id"></param>
       /// <param name="clinica"></param>
       /// <param name="nome"></param>
       /// <param name="cpf"></param>
       /// <param name="rg"></param>
       /// <param name="sexo"></param>
       /// <param name="dataDeNascimento"></param>
       /// <param name="estadoCivil"></param>
       /// <param name="profissao"></param>
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
       /// <param name="observacao"></param>
       /// <param name="dataDoCadastro"></param>
        public Paciente(int id, Clinica clinica, String nome, String cpf, String rg, String sexo, DateTime dataDeNascimento,
            String estadoCivil, String profissao, String logradouro, int numero, String complemento, String bairro,
            String cep, String cidade, String uf, String telefone, String celular, String email, String observacao,
            DateTime dataDoCadastro) 
        {
            this.id = id;
            this.clinica = clinica;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
            this.sexo = sexo;
            this.dataDeNascimento = dataDeNascimento;
            this.estadoCivil = estadoCivil;
            this.profissao = profissao;
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
            this.observacao = observacao;
            this.dataDeNascimento = dataDeNascimento;
        }

        public Paciente(int p, Clinica clinica1)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.clinica1 = clinica1;
        }
    }
}
