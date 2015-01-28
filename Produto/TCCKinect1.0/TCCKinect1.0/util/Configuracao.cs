using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCCKinect1._0.util
{
    /**
     * Class Configuração
     * Autor: Janiel
     */
    class Configuracao
    {
        //Globais
        private String diretorio = Application.StartupPath + @"\Resources\";
        private  const string sKey = "m200k9io";
        private String arquivo = "config.txt";
        private String temp = "configtemp.txt";
        private Utils nUtil = new Utils();
        public String host;
        public String usuario;
        public String senha;

        /// <summary>
        /// Verifica se arquivo de configuração existe s enão existe cria o diretório
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean existeConfiguracao()
        {
            //Variaveis
            Boolean retorno = false;
            //Tratamento de erros
            try
            {
                //Verifica se diretorio existe
                if (Directory.Exists(this.diretorio) == false)
                {
                    //Criando diretório.
                    Directory.CreateDirectory(this.diretorio);
                    //retorno
                    retorno = false;
                }
                else
                {
                    //Verifica se arquivo existe
                    if (File.Exists(diretorio + arquivo))
                    {
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar operação!", ex);
            }
            //Retorno
            return retorno;
        }

        /// <summary>
        /// Abre configurações para ler
        /// </summary>
        public void lerConfiguracoes()
        {
            //Tratamento de erros
            try
            {
                //Traduzindo texto.
                traduzir(this.diretorio + this.arquivo, this.diretorio + this.temp);
                //Leitura
                StreamReader rd = new StreamReader(this.diretorio + this.temp);
                //Lendo configurações
                this.host = rd.ReadLine();
                this.usuario = rd.ReadLine();
                this.senha = rd.ReadLine();
                //Fechando arquivo
                rd.Close();
                //Apagando arquivo temporário
                File.Delete(this.diretorio + this.temp);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível ler as configurações!",ex);
            }
        }

        /// <summary>
        /// Grava configurações
        /// </summary>
        /// <param name="host">String endereço</param>
        /// <param name="usuario">String usuário</param>
        /// <param name="senha">String senha</param>
        /// <param name="smtpCliente">String endereço SMTP para envio de e-mail</param>
        /// <param name="emailSistema">String endereço de e-mail para o sistema</param>
        /// <param name="emailSenha">String senha do e-mail do sistema</param>
        /// <param name="emailPort">String porta de envio de e-mail</param>
        public void gravarConfiguracoes(String host, String usuario, String senha)
        {
            //Tratamento de erros
            try
            {   
                //Gravando
                StreamWriter rw = new StreamWriter(this.diretorio + this.temp);
                rw.WriteLine(host);
                rw.WriteLine(usuario);
                rw.WriteLine(senha);
                //fecha arquivo
                rw.Close();
                //Criptogrando arquivo
                criptografar(this.diretorio + this.temp, this.diretorio + this.arquivo);
                //Apagando arquivo temporario
                File.Delete(this.diretorio + this.temp);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar arquivo de configurações no diretório: " + this.diretorio,ex);
            }
        }

        /// <summary>
        /// Traduzindo criptografia do arquivo
        /// </summary>
        /// <param name="sInputFilename">Arquivo de entrada</param>
        /// <param name="sOutputFilename">Arquivo de saída</param>
        private static void traduzir(string sInputFilename, string sOutputFilename)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        /// <summary>
        /// Criptografar arquivo
        /// </summary>
        /// <param name="sInputFilename">Arquivo de entrada</param>
        /// <param name="sOutputFilename">Arquivo de saída</param>
        private static void criptografar(string sInputFilename, string sOutputFilename)
        {
            //variaveis
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }
    }
}
