using CaptorKinect.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CaptorKinect
{
    /// <summary>
    /// Lógica interna para Configuracao.xaml
    /// </summary>
    public partial class FormConfiguracao : Window
    {
        //Globais
        private Configuracao nConfiguracao = new Configuracao();
        /// <summary>
        /// Construtor
        /// </summary>
        public FormConfiguracao()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Validando campos
            if (this.txtHost.Text.Length == 0)
            {
                MessageBox.Show("Informe o host de conexão com o banco!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.txtHost.Focus();
            }
            else if (this.txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Informe o usuário de conexão com o banco!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.txtUsuario.Focus();
            }
            else if (this.txtSenha.Password.Length == 0)
            {
                MessageBox.Show("Informe a senha de conexão com o banco!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.txtSenha.Focus();
            }
            else
            {
                //Tratamento de erros
                try
                {
                    //Gravando configurações
                    this.nConfiguracao.gravarConfiguracoes(this.txtHost.Text, this.txtUsuario.Text, this.txtSenha.Password);
                    //Mensagem
                    MessageBox.Show("Configurações foram salvas com sucesso!\n Inicie o aplicativo novamente!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Fechando a aplicaçaõ
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao gravar configurações!", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
            }
        }
    }
}
