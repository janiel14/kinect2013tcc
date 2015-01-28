using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCKinect1._0.modelo
{
    class Clinica
    {
        //Propriedades
        public static String entidade = "clinica";
        private int p1;
        private string p2;
        private string p3;
        private string p4;
        private int p5;
        private string p6;
        private string p7;
        private string p8;
        private string p9;
        private string p10;
        private string p11;
        private string p12;
        private string p13;
        private DateTime dateTime;
        private string p14;
        private int p15;
        private string p16;
        private string p17;
        private string p18;
        private DateTime dateTime1;
        private string p19;
        private string p20;
        private string p21;
        private string p22;
        private string p23;
        private string p24;
        private DateTime dateTime2;
        public int id { get; set; }
        public String cnpj { get; set; }
        public String razaoSocial { get; set; }
        public String nomeFantasia { get; set; }
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

        /// <summary>
        /// Constrotor vazio
        /// </summary>
        public Clinica()
        { }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cnpj"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="nomeFantasia"></param>
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
        public Clinica(int id, String cnpj, String razaoSocial, String nomeFantasia, String logradouro, int numero,
            String complemento, String bairro, String cep, String cidade, String uf, String telefone, String celular,
            String email)
        {
            this.id = id;
            this.cnpj = cnpj;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
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



        public Clinica(int p1, string p2, string p3, string p4, int p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
            this.p7 = p7;
            this.p8 = p8;
            this.p9 = p9;
            this.p10 = p10;
            this.p11 = p11;
            this.p12 = p12;
            this.p13 = p13;
        }

        public Clinica(int p1, string p2, string p3, string p4, string p6, DateTime dateTime, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p6 = p6;
            this.dateTime = dateTime;
            this.p7 = p7;
            this.p8 = p8;
            this.p9 = p9;
            this.p10 = p10;
            this.p11 = p11;
            this.p12 = p12;
            this.p13 = p13;
            this.p14 = p14;
        }

        public Clinica(int p1, string p2, string p3, string p4, string p6, DateTime dateTime, string p7, string p8, string p9, string p10, int p15, string p16, string p17, string p18)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p6 = p6;
            this.dateTime = dateTime;
            this.p7 = p7;
            this.p8 = p8;
            this.p9 = p9;
            this.p10 = p10;
            this.p15 = p15;
            this.p16 = p16;
            this.p17 = p17;
            this.p18 = p18;
        }

        public Clinica(int p1, string p2, string p3, string p4, string p6, DateTime dateTime1, string p7, string p8, string p9, string p10, int p15, string p16, string p17, string p18, string p19, string p20, string p21, string p22, string p23, string p24, DateTime dateTime2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p6 = p6;
            this.dateTime1 = dateTime1;
            this.p7 = p7;
            this.p8 = p8;
            this.p9 = p9;
            this.p10 = p10;
            this.p15 = p15;
            this.p16 = p16;
            this.p17 = p17;
            this.p18 = p18;
            this.p19 = p19;
            this.p20 = p20;
            this.p21 = p21;
            this.p22 = p22;
            this.p23 = p23;
            this.p24 = p24;
            this.dateTime2 = dateTime2;
        }
    }
}
