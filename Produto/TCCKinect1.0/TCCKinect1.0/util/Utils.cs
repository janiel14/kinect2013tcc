using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace TCCKinect1._0.util
{
    /**
     * Class Validacao
     * Realiza varios tipos de validação
     * Preparada por: Janiel Madureira Oliveira
     */
    class Utils
    {
        /// <summary>
        /// Valida CNPJ
        /// </summary>
        /// <param name="cnpj">String CNPJ</param>
        /// <returns>Boolean</returns>
        public Boolean validaCnpj(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");

            if (cnpj.Length != 14)
            
                return false;
            
            else if (cnpj == "00000000000000")
            
                return false;
            

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }        
        /// <summary>
        /// Valida data 
        /// </summary>
        /// <param name="Data">String DATA</param>
        /// <returns>Boolean</returns>
        public Boolean validaData(String Data)
        {
            //Variaveis
            Boolean Resultado = false;

            //Tratando Variaveis
            Data = Data.Replace(" ", "").Replace("/", "").Replace("_","");

            //Verificando condições
            if (Data.Length != 8)
            {
                Resultado = false;
            }
            else
            {
                //Convertendo em Inteiros
                int Dia = Convert.ToInt32(Data.Substring(0, 2));
                int Mes = Convert.ToInt32(Data.Substring(2, 2));
                int Ano = Convert.ToInt32(Data.Substring(4));

                //Validação
                if (Ano < 1900 || Ano > 2100)
                {
                    Resultado = false;
                }
                else if (Mes < 1 || Mes > 12)
                {
                    Resultado = false;
                }
                else
                {
                    switch (Mes)
                    {
                        case 1:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 2:
                            if (Dia < 1 || Dia > 29)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 3:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 4:
                            if (Dia < 1 || Dia > 30)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 5:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 6:
                            if (Dia < 1 || Dia > 30)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 7:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 8:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 9:
                            if (Dia < 1 || Dia > 30)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 10:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 11:
                            if (Dia < 1 || Dia > 30)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        case 12:
                            if (Dia < 1 || Dia > 31)
                            {
                                Resultado = false;
                            }
                            else
                            {
                                Resultado = true;
                            }
                            break;
                        default:
                            Resultado = true;
                            break;
                    }
                }
            }

            //resultado
            return Resultado;
        }
        /// <summary>
        /// Valida CPF
        /// </summary>
        /// <param name="cpf">String CPF</param>
        /// <returns>Boolean</returns>
        public Boolean validaCpf(String cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(",", "").Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;
            else if (cpf == "00000000000")

                return false;
            else if (cpf == "11111111111")

                return false;
            else if (cpf == "22222222222")

                return false;
            else if (cpf == "33333333333")

                return false;
            else if (cpf == "44444444444")

                return false;
            else if (cpf == "55555555555")

                return false;
            else if (cpf == "66666666666")

                return false;
            else if (cpf == "77777777777")

                return false;
            else if (cpf == "88888888888")

                return false;
            else if (cpf == "99999999999")

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }
        /// <summary>
        /// Formata valor em moeda
        /// </summary>
        /// <param name="Valor">Decimal valor</param>
        /// <returns>String valor</returns>
        public String convertDecimalParaMoeda(Decimal Valor)
        {
            //Variaveis
            String resultado = null;
            //Tratamento de erros
            try
            {
                String str = Convert.ToString(Valor);

                //Formata
                if (str.Length == 0)
                {
                    resultado = "";
                }
                if (str.Length == 1)
                {
                    resultado = "0.0" + str;
                }
                else if (str.Length == 2)
                {
                    resultado = "0." + str;
                }
                else if (str.Length > 2)
                {
                    resultado = str.Substring(0, str.Length - 2) + "." + str.Substring(str.Length - 2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível converter Decimal em Moeda!",ex);
            }

            return resultado;
        }
        /// <summary>
        /// Verifica se é um número
        /// </summary>
        /// <param name="Val">Int valor</param>
        /// <returns>Boolean</returns>
        public bool isNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val >= 96 && Val <= 105) || (Val == 8) || (Val == 46));
        }
        /// <summary>
        /// Converte teclado número
        /// </summary>
        /// <param name="Val">int valor</param>
        /// <returns>Int</returns>
        public int convertNumPad(int Val)
        {
            int Retorno = 0;

            //CHECK
            if (Val >= 96 && Val <= 105)
            {
                switch (Val)
                {
                    case 96:
                        Retorno = 48;
                        break;
                    case 97:
                        Retorno = 49;
                        break;
                    case 98:
                        Retorno = 50;
                        break;
                    case 99:
                        Retorno = 51;
                        break;
                    case 100:
                        Retorno = 52;
                        break;
                    case 101:
                        Retorno = 53;
                        break;
                    case 102:
                        Retorno = 54;
                        break;
                    case 103:
                        Retorno = 55;
                        break;
                    case 104:
                        Retorno = 56;
                        break;
                    case 105:
                        Retorno = 57;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Retorno = Val;
            }

            return Retorno;
        }
        /// <summary>
        /// Converte String para Inteiro
        /// </summary>
        /// <param name="numero">String número</param>
        /// <returns>Int</returns>
        public int convertStringParaInt(String numero)
        {
            //Variaveis
            int retorno = 0;
            //Tratamento de erros
            try
            {
                retorno = Convert.ToInt32(numero);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível converter texto em número!",ex);
            }
            //Retorno
            return retorno;
        }
        /// <summary>
        /// Converte uma String em Data
        /// </summary>
        /// <param name="data">String DATA</param>
        /// <returns>DateTime</returns>
        public DateTime convertStringParaData(string data)
        {
            //Variaveis
            DateTime tempData;
            //Tratamento de erros
            try
            {
                //Convertendo valor
                tempData = Convert.ToDateTime(data);
            }
            catch (Exception ex)
            {                
                throw new Exception("Não foi possível converter valor em uma data!",ex);
            }
            //Retorno
            return tempData;
        }
        /// <summary>
        /// Converte String para Double
        /// </summary>
        /// <param name="p">String</param>
        /// <returns>Double</returns>
        public double convertStringParaDouble(string p)
        {
            //Variaveis
            Double temp;
            //Tratamento de erros
            try
            {
                //Convertendo valor
                temp = Convert.ToDouble(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível converter valor em Double!", ex);
            }
            //Retorno
            return temp;
        }
        /// <summary>
        /// Converte String para Decimal
        /// </summary>
        /// <param name="p">String</param>
        /// <returns></returns>
        public decimal convertStringParaDecimal(string p)
        {
            //Variaveis
            Decimal temp;
            //Tratamento de erros
            try
            {
                //Convertendo valor
                temp = Convert.ToDecimal(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível converter valor em Decimal!", ex);
            }
            //Retorno
            return temp;
        }

        /// <summary>
        /// Este método retorna true se o email é válida e false se não.
        /// </summary>
        /// <returns></returns>
        public Boolean validaEmail(String email)
        {
            Boolean retorno = false;
            if (email.Trim().Length > 0 && email.Trim().Contains("@") && email.Trim().Contains("."))
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
