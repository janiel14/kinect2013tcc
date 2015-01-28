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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Kinect;
using System.Timers;
using System.ComponentModel;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Threading;
using CaptorKinect.modelo;
using CaptorKinect.util;
using CaptorKinect.dao;

namespace CaptorKinect
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        //Globais
        private ConexaoDataBase conn;
        private Configuracao config = new Configuracao();
        private EsqueletoDAO daoEsqueleto;
        private int _controlCaptor = -1;
        private List<Esqueleto> _capturaDados = new List<Esqueleto>();
        private DispatcherTimer _patcherTimer = new DispatcherTimer();
        private int _horaTimer = 0;
        private int _minutoTimer = 0;
        private int _segundoTimer = 30;
        //private int _contador = 0;
        private int _velocidadeDeGravacao = 1;
        //private int _contagemMaxima = 10;
        private Sessoes _sessao = null;
        private Boolean _sessaoAtiva = false;
        private Int32 _elevationAngle = 0;

        #region Parametros
        /// <summary>
        /// Width of output drawing
        /// </summary>
        private const float RenderWidth = 640.0f;

        /// <summary>
        /// Height of our output drawing
        /// </summary>
        private const float RenderHeight = 480.0f;

        /// <summary>
        /// Thickness of drawn joint lines
        /// </summary>
        private const double JointThickness = 3;

        /// <summary>
        /// Thickness of body center ellipse
        /// </summary>
        private const double BodyCenterThickness = 10;

        /// <summary>
        /// Thickness of clip edge rectangles
        /// </summary>
        private const double ClipBoundsThickness = 10;

        /// <summary>
        /// Brush used to draw skeleton center point
        /// </summary>
        private readonly Brush centerPointBrush = Brushes.Blue;

        /// <summary>
        /// Brush used for drawing joints that are currently tracked
        /// </summary>
        private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));

        /// <summary>
        /// Brush used for drawing joints that are currently inferred
        /// </summary>        
        private readonly Brush inferredJointBrush = Brushes.Yellow;

        /// <summary>
        /// Pen used for drawing bones that are currently tracked
        /// </summary>
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, 6);

        /// <summary>
        /// Pen used for drawing ligando pontos
        /// </summary>
        private readonly Pen trackedRainAngulo = new Pen(Brushes.Red, 6);

        /// <summary>
        /// Pen used for drawing bones that are currently inferred
        /// </summary>        
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        /// <summary>
        /// Drawing group for skeleton rendering output
        /// </summary>
        private DrawingGroup drawingGroup;

        /// <summary>
        /// Drawing image that we will display
        /// </summary>
        private DrawingImage imageSource;
        #endregion Parametros

        /// <summary>
        /// Construtor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Descrição do exercício
            StringBuilder strDescricao = new StringBuilder();
            strDescricao.AppendLine("Exercício:");
            strDescricao.AppendLine("1. Fique em pé, com os braços relaxados.");
            strDescricao.AppendLine("2. Levante os braços, mantendo-os estendidos, até em cima, tanto quanto possível.");
            strDescricao.AppendLine("3. Retorne à posição inicial devagar.");
            strDescricao.AppendLine("4. Repita 10 vezes.");
            this.txtDescricao.Text = strDescricao.ToString();
            //Configurando cronometro
            this._patcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this._patcherTimer.Interval = new TimeSpan(0, 0, 1);
            ///Tratamento de erros
            ///Verifica se existe arquivo de configuração
            ///Obtem as configurações
            ///Verifica conexão com o banco
            ///Verifica se o banco existe
            ///inicializa dao do esqueleto
            try
            {
                //Verificando conexão com o banco
                if (this.config.existeConfiguracao())
                {
                    //Lendo configurações
                    this.config.lerConfiguracoes();
                    //Inicializando configurações
                    this.conn = new ConexaoDataBase(this.config.host, this.config.usuario, this.config.senha);
                    //Verificando conexão com o banco
                    if (this.conn.verificaConexao())
                    {
                        //Verificando de banco de dados da aplicação existe
                        if (this.conn.bancoExiste())
                        {
                            //Inicializa dao do esquele
                            this.daoEsqueleto = new EsqueletoDAO(this.conn.getConnectionMysql());
                            this._sessao = this.daoEsqueleto.getSessaoLiberada();
                            //Verifica se há sessão disponível
                            if (this._sessao == null)
                            {
                                MessageBox.Show("Não há sessão liberada!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                this.lbTextFisioterapeuta.Content = this._sessao.fisioterapeuta.nome;
                                this.lbTextPaciente.Content = this._sessao.paciente.nome;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível encontrar o banco de dados, favor verificar se a instalação esta correta!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível se conectar ao banco de dados, favor verificar se a instalação esta correta!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                    }
                }
                else
                {
                    //Aviso
                    MessageBox.Show("Não foi encontrato arquivo de configurações da aplicação, será aberto a janela para gravar as configurações de conexão!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //Abrindo janela de configurações
                    FormConfiguracao form = new FormConfiguracao();
                    form.ShowDialog();
                    //Fechando a aplicação
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problema ao verificar conexão com o banco de dados!", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        #region Métodos de captura
        /// <summary>
        /// Calcula tempo da sessão
        /// </summary>
        /// <returns>Retorna segundos gastos na sessão</returns>
        private int calculaTempoDaSessao()
        {
            //Variaveis
            return (((this._horaTimer * 60) + this._minutoTimer) * 60) + this._segundoTimer;
        }
        /// <summary>
        /// Rastreando pontos
        /// </summary>
        /// <param name="skel"></param>
        /// <param name="dc"></param>
        private void rastrearPontos(Skeleton skel, DrawingContext dc)
        {
            //Variaveis
            Esqueleto _esqueleto = new Esqueleto();
            //Verifica se o primeiro dados que vem a tela
            if (this._controlCaptor == -1)
            {
                //Capturando dados iniciais
                _esqueleto.body = new Body(0, this._sessao,
                    skel.Position.X,
                    skel.Position.Y,
                    skel.Position.Z,
                    this.calculaTempoDaSessao());     
                _esqueleto.head = new Head(0, this._sessao,
                    skel.Joints[JointType.Head].Position.X,
                    skel.Joints[JointType.Head].Position.Y,
                    skel.Joints[JointType.Head].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.Head].Position.X,
                        skel.Joints[JointType.Head].Position.Y,
                        skel.Joints[JointType.ShoulderCenter].Position.X, skel.Joints[JointType.ShoulderCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.shoulderCenter = new ShoulderCenter(0, this._sessao,
                    skel.Joints[JointType.ShoulderCenter].Position.X,
                    skel.Joints[JointType.ShoulderCenter].Position.Y,
                    skel.Joints[JointType.ShoulderCenter].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.ShoulderCenter].Position.X,
                        skel.Joints[JointType.ShoulderCenter].Position.Y,
                        skel.Joints[JointType.Spine].Position.X, skel.Joints[JointType.Spine].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.shoulderRight = new ShoulderRight(0, this._sessao,
                    skel.Joints[JointType.ShoulderRight].Position.X,
                    skel.Joints[JointType.ShoulderRight].Position.Y,
                    skel.Joints[JointType.ShoulderRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.ShoulderRight].Position.X,
                        skel.Joints[JointType.ShoulderRight].Position.Y,
                        skel.Joints[JointType.ShoulderCenter].Position.X,skel.Joints[JointType.ShoulderCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.elbowRight = new ElbowRight(0, this._sessao,
                    skel.Joints[JointType.ElbowRight].Position.X,
                    skel.Joints[JointType.ElbowRight].Position.Y,
                    skel.Joints[JointType.ElbowRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.ElbowRight].Position.X,
                        skel.Joints[JointType.ElbowRight].Position.Y,
                        skel.Joints[JointType.ShoulderRight].Position.X,
                        skel.Joints[JointType.ShoulderRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.wristRight = new WristRight(0, this._sessao,
                    skel.Joints[JointType.WristRight].Position.X,
                    skel.Joints[JointType.WristRight].Position.Y,
                    skel.Joints[JointType.WristRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.WristRight].Position.X,
                        skel.Joints[JointType.WristRight].Position.Y,
                        skel.Joints[JointType.ElbowRight].Position.X,
                        skel.Joints[JointType.ElbowRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.handRight = new HandRight(0, this._sessao,
                    skel.Joints[JointType.HandRight].Position.X,
                    skel.Joints[JointType.HandRight].Position.Y,
                    skel.Joints[JointType.HandRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.HandRight].Position.X,
                        skel.Joints[JointType.HandRight].Position.Y,
                        skel.Joints[JointType.WristRight].Position.X,
                        skel.Joints[JointType.WristRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.shoulderLeft = new ShoulderLeft(0, this._sessao,
                    skel.Joints[JointType.ShoulderLeft].Position.X,
                    skel.Joints[JointType.ShoulderLeft].Position.Y,
                    skel.Joints[JointType.ShoulderLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.ShoulderLeft].Position.X,
                        skel.Joints[JointType.ShoulderLeft].Position.Y,
                        skel.Joints[JointType.ShoulderCenter].Position.X,
                        skel.Joints[JointType.ShoulderCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.elbowLeft = new ElbowLeft(0, this._sessao,
                    skel.Joints[JointType.ElbowLeft].Position.X,
                    skel.Joints[JointType.ElbowLeft].Position.Y,
                    skel.Joints[JointType.ElbowLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.ElbowLeft].Position.X,
                        skel.Joints[JointType.ElbowLeft].Position.Y,
                        skel.Joints[JointType.ShoulderLeft].Position.X,
                        skel.Joints[JointType.ShoulderLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.wristLeft = new WristLeft(0, this._sessao,
                    skel.Joints[JointType.WristLeft].Position.X,
                    skel.Joints[JointType.WristLeft].Position.Y,
                    skel.Joints[JointType.WristLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.WristLeft].Position.X,
                        skel.Joints[JointType.WristLeft].Position.Y,
                        skel.Joints[JointType.ElbowLeft].Position.X,
                        skel.Joints[JointType.ElbowLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.handLeft = new HandLeft(0, this._sessao,
                    skel.Joints[JointType.HandLeft].Position.X,
                    skel.Joints[JointType.HandLeft].Position.Y,
                    skel.Joints[JointType.HandLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.HandLeft].Position.X,
                        skel.Joints[JointType.HandLeft].Position.Y,
                        skel.Joints[JointType.WristLeft].Position.X,
                        skel.Joints[JointType.WristLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.spine = new Spine(0, this._sessao,
                    skel.Joints[JointType.Spine].Position.X,
                    skel.Joints[JointType.Spine].Position.Y,
                    skel.Joints[JointType.Spine].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.Spine].Position.X,
                        skel.Joints[JointType.Spine].Position.Y,
                        skel.Joints[JointType.HipCenter].Position.X,
                        skel.Joints[JointType.HipCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.hipCenter = new HipCenter(0, this._sessao,
                    skel.Joints[JointType.HipCenter].Position.X,
                    skel.Joints[JointType.HipCenter].Position.Y,
                    skel.Joints[JointType.HipCenter].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.HipCenter].Position.X,
                        skel.Joints[JointType.HipCenter].Position.Y,
                        skel.Joints[JointType.Spine].Position.X,
                        skel.Joints[JointType.Spine].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.hipRight = new HipRight(0, this._sessao,
                    skel.Joints[JointType.HipRight].Position.X,
                    skel.Joints[JointType.HipRight].Position.Y,
                    skel.Joints[JointType.HipRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.HipRight].Position.X,
                        skel.Joints[JointType.HipRight].Position.Y,
                        skel.Joints[JointType.HipCenter].Position.X,
                        skel.Joints[JointType.HipCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.kneeRight = new KneeRight(0, this._sessao,
                    skel.Joints[JointType.KneeRight].Position.X,
                    skel.Joints[JointType.KneeRight].Position.Y,
                    skel.Joints[JointType.KneeRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.KneeRight].Position.X,
                        skel.Joints[JointType.KneeRight].Position.Y,
                        skel.Joints[JointType.HipRight].Position.X,
                        skel.Joints[JointType.HipRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.ankleRight = new AnkleRight(0, this._sessao,
                    skel.Joints[JointType.AnkleRight].Position.X,
                    skel.Joints[JointType.AnkleRight].Position.Y,
                    skel.Joints[JointType.AnkleRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.AnkleRight].Position.X,
                        skel.Joints[JointType.AnkleRight].Position.Y,
                        skel.Joints[JointType.KneeRight].Position.X,
                        skel.Joints[JointType.KneeRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.footRight = new FootRight(0, this._sessao,
                    skel.Joints[JointType.FootRight].Position.X,
                    skel.Joints[JointType.FootRight].Position.Y,
                    skel.Joints[JointType.FootRight].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.FootRight].Position.X,
                        skel.Joints[JointType.FootRight].Position.Y,
                        skel.Joints[JointType.AnkleRight].Position.X,
                        skel.Joints[JointType.AnkleRight].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.hipLeft = new HipLeft(0, this._sessao,
                    skel.Joints[JointType.HipLeft].Position.X,
                    skel.Joints[JointType.HipLeft].Position.Y,
                    skel.Joints[JointType.HipLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.HipLeft].Position.X,
                        skel.Joints[JointType.HipLeft].Position.Y,
                        skel.Joints[JointType.HipCenter].Position.X,
                        skel.Joints[JointType.HipCenter].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.kneeLeft = new KneeLeft(0, this._sessao,
                    skel.Joints[JointType.KneeLeft].Position.X,
                    skel.Joints[JointType.KneeLeft].Position.Y,
                    skel.Joints[JointType.KneeLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.KneeLeft].Position.X,
                        skel.Joints[JointType.KneeLeft].Position.Y,
                        skel.Joints[JointType.HipLeft].Position.X,
                        skel.Joints[JointType.HipLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.ankleLeft = new AnkleLeft(0, this._sessao,
                    skel.Joints[JointType.AnkleLeft].Position.X,
                    skel.Joints[JointType.AnkleLeft].Position.Y,
                    skel.Joints[JointType.AnkleLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.AnkleLeft].Position.X,
                        skel.Joints[JointType.AnkleLeft].Position.Y,
                        skel.Joints[JointType.KneeLeft].Position.X,
                        skel.Joints[JointType.KneeLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                _esqueleto.footLeft = new FootLeft(0, this._sessao,
                    skel.Joints[JointType.FootLeft].Position.X,
                    skel.Joints[JointType.FootLeft].Position.Y,
                    skel.Joints[JointType.FootLeft].Position.Z,
                    this.getRotationAngle(skel.Joints[JointType.FootLeft].Position.X,
                        skel.Joints[JointType.FootLeft].Position.Y,
                        skel.Joints[JointType.AnkleLeft].Position.X,
                        skel.Joints[JointType.AnkleLeft].Position.Y),
                    this.calculaTempoDaSessao(), 0);
                //Adicionando esqueleto
                this._capturaDados.Add(_esqueleto);
            }
            //Incrementando contador
            this._controlCaptor++;
            //Gravando Movimento apos o inicial
            this.gravarMovimentacao(skel);
        }
        /// <summary>
        /// Pega angulo de 2 pontos
        /// </summary>
        /// <param name="px">Eixo x do ponto</param>
        /// <param name="py">Eixo y do ponto</param>
        /// <param name="bx">Eixo x da base</param>
        /// <param name="by">Eixo y da base</param>
        /// <returns></returns>
        public int getRotationAngle(double pX, double pY, double bX, double bY)
        {
            //Tratamento de erros
            try
            {
                //Pegando o angulo
                double ang = Math.Atan2(bY - pY, bX - pX);
                //Verificando se angulo é negativo
                if (ang < 0)
                {
                    //Convertendo em angulo positivo
                    ang = 2 * Math.PI + ang;
                }
                //Convertendo radianos em graus
                ang = 180 * ang / Math.PI;
                //Convertendo double para inteiro
                return Convert.ToInt32(ang);
            }
            catch (Exception)
            {
                //Consumindo erro internamente
                return -1;
            }
        }
        /// <summary>
        /// Grava movimentação se houver alterações
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        public void gravarMovimentacao(Skeleton skel)
        {
            /*
            //Variaveis
            Double difHandRightAngulo = 0.00, difHandLeftAngulo = 0.0;
            //Verifica se esqueleto esta travado
            if (skel.TrackingState == SkeletonTrackingState.Tracked)
            {
                difHandRightAngulo = (this.getRotationAngle(
                    skel.Joints[JointType.HandRight].Position.X,
                    skel.Joints[JointType.HandRight].Position.Y,
                    skel.Position.X,
                    skel.Position.Y) - this._capturaDados[this._capturaDados.Count - 1].handRight.angulo);
                difHandLeftAngulo = (this.getRotationAngle(
                    skel.Joints[JointType.HandLeft].Position.X,
                    skel.Joints[JointType.HandLeft].Position.Y,
                    skel.Position.X,
                    skel.Position.Y) - this._capturaDados[this._capturaDados.Count - 1].handLeft.angulo);                
            }
            //Verifica variação do angulo
            if (difHandRightAngulo != 0.0 && difHandRightAngulo >= 5 || 
                difHandRightAngulo != 0.0 && difHandRightAngulo < -5 ||
                difHandLeftAngulo != 0.0 && difHandLeftAngulo >= 5 ||
                difHandLeftAngulo != 0.0 && difHandLeftAngulo < -5)
            {
             */
                //Verifica contador
                if (this._controlCaptor == this._velocidadeDeGravacao)
                {
                    //Variavel
                    Esqueleto _esqueleto = new Esqueleto();
                    //Capturando dados iniciais
                    _esqueleto.body = new Body(0, this._sessao,
                        skel.Position.X,
                        skel.Position.Y,
                        skel.Position.Z,
                        this.calculaTempoDaSessao());
                    _esqueleto.head = new Head(0, this._sessao,
                        skel.Joints[JointType.Head].Position.X,
                        skel.Joints[JointType.Head].Position.Y,
                        skel.Joints[JointType.Head].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.Head].Position.X,
                            skel.Joints[JointType.Head].Position.Y,
                            skel.Joints[JointType.ShoulderCenter].Position.X,
                            skel.Joints[JointType.ShoulderCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].head.angulo,
                            this.getRotationAngle(skel.Joints[JointType.Head].Position.X,
                                skel.Joints[JointType.Head].Position.Y,
                                skel.Joints[JointType.ShoulderCenter].Position.X,
                                skel.Joints[JointType.ShoulderCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].head.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.shoulderCenter = new ShoulderCenter(0, this._sessao,
                        skel.Joints[JointType.ShoulderCenter].Position.X,
                        skel.Joints[JointType.ShoulderCenter].Position.Y,
                        skel.Joints[JointType.ShoulderCenter].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.ShoulderCenter].Position.X,
                            skel.Joints[JointType.ShoulderCenter].Position.Y,
                            skel.Joints[JointType.Spine].Position.X,
                            skel.Joints[JointType.Spine].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].shoulderCenter.angulo,
                            this.getRotationAngle(skel.Joints[JointType.ShoulderCenter].Position.X,
                                skel.Joints[JointType.ShoulderCenter].Position.Y,
                                skel.Joints[JointType.Spine].Position.X,
                                skel.Joints[JointType.Spine].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].shoulderCenter.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.shoulderRight = new ShoulderRight(0, this._sessao,
                        skel.Joints[JointType.ShoulderRight].Position.X,
                        skel.Joints[JointType.ShoulderRight].Position.Y,
                        skel.Joints[JointType.ShoulderRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.ShoulderRight].Position.X,
                            skel.Joints[JointType.ShoulderRight].Position.Y,
                            skel.Joints[JointType.ShoulderCenter].Position.X,
                            skel.Joints[JointType.ShoulderCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].shoulderRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.ShoulderRight].Position.X,
                                skel.Joints[JointType.ShoulderRight].Position.Y,
                                skel.Joints[JointType.ShoulderCenter].Position.X,
                                skel.Joints[JointType.ShoulderCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].shoulderRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.elbowRight = new ElbowRight(0, this._sessao,
                        skel.Joints[JointType.ElbowRight].Position.X,
                        skel.Joints[JointType.ElbowRight].Position.Y,
                        skel.Joints[JointType.ElbowRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.ElbowRight].Position.X,
                            skel.Joints[JointType.ElbowRight].Position.Y,
                            skel.Joints[JointType.ShoulderRight].Position.X,
                            skel.Joints[JointType.ShoulderRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].elbowRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.ElbowRight].Position.X,
                                skel.Joints[JointType.ElbowRight].Position.Y,
                                skel.Joints[JointType.ShoulderRight].Position.X,
                                skel.Joints[JointType.ShoulderRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].elbowRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.wristRight = new WristRight(0, this._sessao,
                        skel.Joints[JointType.WristRight].Position.X,
                        skel.Joints[JointType.WristRight].Position.Y,
                        skel.Joints[JointType.WristRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.WristRight].Position.X,
                            skel.Joints[JointType.WristRight].Position.Y,
                            skel.Joints[JointType.ElbowRight].Position.X,
                            skel.Joints[JointType.ElbowRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].wristRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.WristRight].Position.X,
                                skel.Joints[JointType.WristRight].Position.Y,
                                skel.Joints[JointType.ElbowRight].Position.X,
                                skel.Joints[JointType.ElbowRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].wristRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.handRight = new HandRight(0, this._sessao,
                        skel.Joints[JointType.HandRight].Position.X,
                        skel.Joints[JointType.HandRight].Position.Y,
                        skel.Joints[JointType.HandRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.HandRight].Position.X,
                            skel.Joints[JointType.HandRight].Position.Y,
                            skel.Joints[JointType.WristRight].Position.X,
                            skel.Joints[JointType.WristRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].handRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.HandRight].Position.X,
                                skel.Joints[JointType.HandRight].Position.Y,
                                skel.Joints[JointType.WristRight].Position.X,
                                skel.Joints[JointType.WristRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].handRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.shoulderLeft = new ShoulderLeft(0, this._sessao,
                        skel.Joints[JointType.ShoulderLeft].Position.X,
                        skel.Joints[JointType.ShoulderLeft].Position.Y,
                        skel.Joints[JointType.ShoulderLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.ShoulderLeft].Position.X,
                            skel.Joints[JointType.ShoulderLeft].Position.Y,
                            skel.Joints[JointType.ShoulderCenter].Position.X,
                            skel.Joints[JointType.ShoulderCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].shoulderLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.ShoulderLeft].Position.X,
                                skel.Joints[JointType.ShoulderLeft].Position.Y,
                                skel.Joints[JointType.ShoulderCenter].Position.X,
                                skel.Joints[JointType.ShoulderCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].shoulderLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.elbowLeft = new ElbowLeft(0, this._sessao,
                        skel.Joints[JointType.ElbowLeft].Position.X,
                        skel.Joints[JointType.ElbowLeft].Position.Y,
                        skel.Joints[JointType.ElbowLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.ElbowLeft].Position.X,
                            skel.Joints[JointType.ElbowLeft].Position.Y,
                            skel.Joints[JointType.ShoulderLeft].Position.X,
                            skel.Joints[JointType.ShoulderLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].elbowLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.ElbowLeft].Position.X,
                                skel.Joints[JointType.ElbowLeft].Position.Y,
                                skel.Joints[JointType.ShoulderLeft].Position.X,
                                skel.Joints[JointType.ShoulderLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].elbowLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.wristLeft = new WristLeft(0, this._sessao,
                        skel.Joints[JointType.WristLeft].Position.X,
                        skel.Joints[JointType.WristLeft].Position.Y,
                        skel.Joints[JointType.WristLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.WristLeft].Position.X,
                            skel.Joints[JointType.WristLeft].Position.Y,
                            skel.Joints[JointType.ElbowLeft].Position.X,
                            skel.Joints[JointType.ElbowLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].wristLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.WristLeft].Position.X,
                                skel.Joints[JointType.WristLeft].Position.Y,
                                skel.Joints[JointType.ElbowLeft].Position.X,
                                skel.Joints[JointType.ElbowLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].wristLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.handLeft = new HandLeft(0, this._sessao,
                        skel.Joints[JointType.HandLeft].Position.X,
                        skel.Joints[JointType.HandLeft].Position.Y,
                        skel.Joints[JointType.HandLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.HandLeft].Position.X,
                            skel.Joints[JointType.HandLeft].Position.Y,
                            skel.Joints[JointType.WristLeft].Position.X,
                            skel.Joints[JointType.WristLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].handLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.HandLeft].Position.X,
                                skel.Joints[JointType.HandLeft].Position.Y,
                                skel.Joints[JointType.WristLeft].Position.X,
                                skel.Joints[JointType.WristLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].handLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.spine = new Spine(0, this._sessao,
                        skel.Joints[JointType.Spine].Position.X,
                        skel.Joints[JointType.Spine].Position.Y,
                        skel.Joints[JointType.Spine].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.Spine].Position.X,
                            skel.Joints[JointType.Spine].Position.Y,
                            skel.Joints[JointType.HipCenter].Position.X,
                            skel.Joints[JointType.HipCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].spine.angulo,
                            this.getRotationAngle(skel.Joints[JointType.Spine].Position.X,
                                skel.Joints[JointType.Spine].Position.Y,
                                skel.Joints[JointType.HipCenter].Position.X,
                                skel.Joints[JointType.HipCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].spine.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.hipCenter = new HipCenter(0, this._sessao,
                        skel.Joints[JointType.HipCenter].Position.X,
                        skel.Joints[JointType.HipCenter].Position.Y,
                        skel.Joints[JointType.HipCenter].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.HipCenter].Position.X,
                            skel.Joints[JointType.HipCenter].Position.Y,
                            skel.Joints[JointType.Spine].Position.X,
                            skel.Joints[JointType.Spine].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].hipCenter.angulo,
                            this.getRotationAngle(skel.Joints[JointType.HipCenter].Position.X,
                                skel.Joints[JointType.HipCenter].Position.Y,
                                skel.Joints[JointType.Spine].Position.X,
                                skel.Joints[JointType.Spine].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].hipCenter.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.hipRight = new HipRight(0, this._sessao,
                        skel.Joints[JointType.HipRight].Position.X,
                        skel.Joints[JointType.HipRight].Position.Y,
                        skel.Joints[JointType.HipRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.HipRight].Position.X,
                            skel.Joints[JointType.HipRight].Position.Y,
                            skel.Joints[JointType.HipCenter].Position.X,
                            skel.Joints[JointType.HipCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].hipRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.HipRight].Position.X,
                                skel.Joints[JointType.HipRight].Position.Y,
                                skel.Joints[JointType.HipCenter].Position.X,
                                skel.Joints[JointType.HipCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].hipRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.kneeRight = new KneeRight(0, this._sessao,
                        skel.Joints[JointType.KneeRight].Position.X,
                        skel.Joints[JointType.KneeRight].Position.Y,
                        skel.Joints[JointType.KneeRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.KneeRight].Position.X,
                            skel.Joints[JointType.KneeRight].Position.Y,
                            skel.Joints[JointType.HipRight].Position.X,
                            skel.Joints[JointType.HipRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].kneeRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.KneeRight].Position.X,
                                skel.Joints[JointType.KneeRight].Position.Y,
                                skel.Joints[JointType.HipRight].Position.X,
                                skel.Joints[JointType.HipRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].kneeRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.ankleRight = new AnkleRight(0, this._sessao,
                        skel.Joints[JointType.AnkleRight].Position.X,
                        skel.Joints[JointType.AnkleRight].Position.Y,
                        skel.Joints[JointType.AnkleRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.AnkleRight].Position.X,
                            skel.Joints[JointType.AnkleRight].Position.Y,
                            skel.Joints[JointType.KneeRight].Position.X,
                            skel.Joints[JointType.KneeRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].ankleRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.AnkleRight].Position.X,
                                skel.Joints[JointType.AnkleRight].Position.Y,
                                skel.Joints[JointType.KneeRight].Position.X,
                                skel.Joints[JointType.KneeRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].ankleRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.footRight = new FootRight(0, this._sessao,
                        skel.Joints[JointType.FootRight].Position.X,
                        skel.Joints[JointType.FootRight].Position.Y,
                        skel.Joints[JointType.FootRight].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.FootRight].Position.X,
                            skel.Joints[JointType.FootRight].Position.Y,
                            skel.Joints[JointType.AnkleRight].Position.X,
                            skel.Joints[JointType.AnkleRight].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].footRight.angulo,
                            this.getRotationAngle(skel.Joints[JointType.FootRight].Position.X,
                                skel.Joints[JointType.FootRight].Position.Y,
                                skel.Joints[JointType.AnkleRight].Position.X,
                                skel.Joints[JointType.AnkleRight].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].footRight.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.hipLeft = new HipLeft(0, this._sessao,
                        skel.Joints[JointType.HipLeft].Position.X,
                        skel.Joints[JointType.HipLeft].Position.Y,
                        skel.Joints[JointType.HipLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.HipLeft].Position.X,
                            skel.Joints[JointType.HipLeft].Position.Y,
                            skel.Joints[JointType.HipCenter].Position.X,
                            skel.Joints[JointType.HipCenter].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].hipLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.HipLeft].Position.X,
                                skel.Joints[JointType.HipLeft].Position.Y,
                                skel.Joints[JointType.HipCenter].Position.X,
                                skel.Joints[JointType.HipCenter].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].hipLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.kneeLeft = new KneeLeft(0, this._sessao,
                        skel.Joints[JointType.KneeLeft].Position.X,
                        skel.Joints[JointType.KneeLeft].Position.Y,
                        skel.Joints[JointType.KneeLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.KneeLeft].Position.X,
                            skel.Joints[JointType.KneeLeft].Position.Y,
                            skel.Joints[JointType.HipLeft].Position.X,
                            skel.Joints[JointType.HipLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].kneeLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.KneeLeft].Position.X,
                                skel.Joints[JointType.KneeLeft].Position.Y,
                                skel.Joints[JointType.HipLeft].Position.X,
                                skel.Joints[JointType.HipLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].kneeLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.ankleLeft = new AnkleLeft(0, this._sessao,
                        skel.Joints[JointType.AnkleLeft].Position.X,
                        skel.Joints[JointType.AnkleLeft].Position.Y,
                        skel.Joints[JointType.AnkleLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.AnkleLeft].Position.X,
                            skel.Joints[JointType.AnkleLeft].Position.Y,
                            skel.Joints[JointType.KneeLeft].Position.X,
                            skel.Joints[JointType.KneeLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count - 1].ankleLeft.angulo,
                            this.getRotationAngle(skel.Joints[JointType.AnkleLeft].Position.X,
                                skel.Joints[JointType.AnkleLeft].Position.Y,
                                skel.Joints[JointType.KneeLeft].Position.X,
                                skel.Joints[JointType.KneeLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count - 1].ankleLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    _esqueleto.footLeft = new FootLeft(0, this._sessao,
                        skel.Joints[JointType.FootLeft].Position.X,
                        skel.Joints[JointType.FootLeft].Position.Y,
                        skel.Joints[JointType.FootLeft].Position.Z,
                        this.getRotationAngle(skel.Joints[JointType.FootLeft].Position.X,
                            skel.Joints[JointType.FootLeft].Position.Y,
                            skel.Joints[JointType.AnkleLeft].Position.X,
                            skel.Joints[JointType.AnkleLeft].Position.Y),
                        this.calculaTempoDaSessao(),
                        this.calculaVelocidade(this._capturaDados[this._capturaDados.Count-1].footLeft.angulo,
                        this.getRotationAngle(skel.Joints[JointType.FootLeft].Position.X,
                                skel.Joints[JointType.FootLeft].Position.Y,
                                skel.Joints[JointType.AnkleLeft].Position.X,
                                skel.Joints[JointType.AnkleLeft].Position.Y),
                            this._capturaDados[this._capturaDados.Count-1].footLeft.tempo,
                            this.calculaTempoDaSessao())
                     );
                    //Adicionando esqueleto
                    this._capturaDados.Add(_esqueleto);
                    this.elpGravando.Visibility = Visibility.Visible;
                }
                else if (this._controlCaptor > this._velocidadeDeGravacao)
                {
                    this._controlCaptor = 0;
                    this.elpGravando.Visibility = Visibility.Hidden;
                }
            /*
            }
             */
              
        }
        /// <summary>
        /// Calcula velocidade do angulo em segundos.
        /// </summary>
        /// <param name="pontInicial"></param>
        /// <param name="pontFinal"></param>
        /// <param name="tempInicial"></param>
        /// <param name="tempFinal"></param>
        /// <returns></returns>
        private int calculaVelocidade(int pontInicial, int pontFinal, int tempInicial, int tempFinal)
        { 
            //Variaveis
            int tempo = 0, angulo = 0, velocidade = 0;
            //Obtem tempo
            tempo = (tempFinal - tempInicial);
            angulo = pontFinal - pontInicial;
            //Verifica se tempo é zero
            if (tempo <= 0)
	        {
		        velocidade = 0;
	        }
            else
            {
                velocidade = angulo / tempo;
            }
            //Verifica velocidade é menor que 0
            if (velocidade < 0)
            {
                velocidade = 0;
            }
            //Retorno
            return velocidade;
        }
        /// <summary>
        /// Este faz uma linha entre os pontos rastreados para o angulo
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="drawingContext"></param>
        /// <param name="jointType0"></param>
        /// <param name="jointType1"></param>
        private void DrawLine(Skeleton skeleton, DrawingContext drawingContext, JointType jointType0, JointType jointType1)
        {
            Joint joint0 = skeleton.Joints[jointType0];
            Joint joint1 = skeleton.Joints[jointType1];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == JointTrackingState.NotTracked ||
                joint1.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint0.TrackingState == JointTrackingState.Inferred &&
                joint1.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedRainAngulo;
            }

            drawingContext.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position));
        }
        #endregion Métodos de captura

        #region Métodos Microsoft
        /// <summary>
        /// Draws indicators to show which edges are clipping skeleton data
        /// </summary>
        /// <param name="skeleton">skeleton to draw clipping information for</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private static void RenderClippedEdges(Skeleton skeleton, DrawingContext drawingContext)
        {
            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Bottom))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, RenderHeight - ClipBoundsThickness, RenderWidth, ClipBoundsThickness));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Top))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, 0, RenderWidth, ClipBoundsThickness));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Left))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, 0, ClipBoundsThickness, RenderHeight));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Right))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(RenderWidth - ClipBoundsThickness, 0, ClipBoundsThickness, RenderHeight));
            }
        }
        /// <summary>
        /// Draws a bone line between two joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw bones from</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        /// <param name="jointType0">joint to start drawing from</param>
        /// <param name="jointType1">joint to end drawing at</param>
        private void DrawBone(Skeleton skeleton, DrawingContext drawingContext, JointType jointType0, JointType jointType1)
        {
            Joint joint0 = skeleton.Joints[jointType0];
            Joint joint1 = skeleton.Joints[jointType1];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == JointTrackingState.NotTracked ||
                joint1.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint0.TrackingState == JointTrackingState.Inferred &&
                joint1.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedBonePen;
            }

            drawingContext.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position));
        }
        /// <summary>
        /// Maps a SkeletonPoint to lie within our render space and converts to Point
        /// </summary>
        /// <param name="skelpoint">point to map</param>
        /// <returns>mapped point</returns>
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = this.sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }
        /// <summary>
        /// Draws a skeleton's bones and joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private void DrawBonesAndJoints(Skeleton skeleton, DrawingContext drawingContext)
        {
            // Render Torso
            this.DrawBone(skeleton, drawingContext, JointType.Head, JointType.ShoulderCenter);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.Spine);
            this.DrawBone(skeleton, drawingContext, JointType.Spine, JointType.HipCenter);
            this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipLeft);
            this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipRight);

            // Left Arm
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
            this.DrawBone(skeleton, drawingContext, JointType.ElbowLeft, JointType.WristLeft);
            this.DrawBone(skeleton, drawingContext, JointType.WristLeft, JointType.HandLeft);

            // Right Arm
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
            this.DrawBone(skeleton, drawingContext, JointType.ElbowRight, JointType.WristRight);
            this.DrawBone(skeleton, drawingContext, JointType.WristRight, JointType.HandRight);

            // Left Leg
            this.DrawBone(skeleton, drawingContext, JointType.HipLeft, JointType.KneeLeft);
            this.DrawBone(skeleton, drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
            this.DrawBone(skeleton, drawingContext, JointType.AnkleLeft, JointType.FootLeft);

            // Right Leg
            this.DrawBone(skeleton, drawingContext, JointType.HipRight, JointType.KneeRight);
            this.DrawBone(skeleton, drawingContext, JointType.KneeRight, JointType.AnkleRight);
            this.DrawBone(skeleton, drawingContext, JointType.AnkleRight, JointType.FootRight);

            // Render Joints
            foreach (Joint joint in skeleton.Joints)
            {
                Brush drawBrush = null;

                if (joint.TrackingState == JointTrackingState.Tracked)
                {
                    drawBrush = this.trackedJointBrush;
                }
                else if (joint.TrackingState == JointTrackingState.Inferred)
                {
                    drawBrush = this.inferredJointBrush;
                }

                if (drawBrush != null)
                {
                    drawingContext.DrawEllipse(drawBrush, null, this.SkeletonPointToScreen(joint.Position), JointThickness, JointThickness);
                }
            }
        }
        #endregion Métodos Microsoft

        #region Eventos
        /// <summary>
        /// Cronometro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Variaveis
            String hora,minuto,segundo = null;
            //Verifica se sessão esta ativa
            if (this._sessaoAtiva)
            {
                //Somando segundo
                this._segundoTimer -= 1;
                //Verificando se segundo é mais de 60
                if (this._segundoTimer >= 60)
                {
                    this._minutoTimer++; //Incrementa minutos
                    this._segundoTimer = 0; //Zera segundos
                }
                //Verifica se minuto e maior que 60
                if (this._minutoTimer >= 60)
                {
                    this._horaTimer++; //Incrementa hora
                    this._minutoTimer = 0; //Zera minuto
                }
                //Convertendo hora em String
                if (this._horaTimer < 10)
                {
                    hora = "0" + this._horaTimer.ToString();
                }
                else
                {
                    hora = this._horaTimer.ToString();
                }
                //Convertendo minuto em String
                if (this._minutoTimer < 10)
                {
                    minuto = "0" + this._minutoTimer.ToString();
                }
                else
                {
                    minuto = this._minutoTimer.ToString();
                }
                //Convertendo segundo em String
                if (this._segundoTimer < 10)
                {
                    segundo = "0" + this._segundoTimer.ToString();
                }
                else
                {
                    segundo = this._segundoTimer.ToString();
                }
                //Exibindo cronometro
                this.lbContagemTempo.Content = hora + ":" + minuto + ":" + segundo;
                //Parar exercicio
                //if (this._contador == this._contagemMaxima)
                if (this._segundoTimer == 0 && this._minutoTimer == 0 && this._horaTimer == 0)
                {
                    //Parando tempo
                    this._patcherTimer.Stop();
                    //Tratamento de erros
                    try
                    {
                        //Gravando dados
                        if (this.daoEsqueleto.gravar(this._capturaDados,this._sessao.id))
                        {
                            //Aviso
                            MessageBox.Show("Informações de captura armazenadas com sucesso!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                            //Fechando aplicação
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível armazenar as informações, favor informar ao suporte!", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            else
            {
                
            }
        }
        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }
        /// <summary>
        /// Event handler for Kinect sensor's SkeletonFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            using (DrawingContext dc = this.drawingGroup.Open())
            {
                // Draw a transparent background to set the render size
                dc.DrawRectangle(Brushes.Black, null, new Rect(0.0, 0.0, RenderWidth, RenderHeight));

                if (skeletons.Length != 0)
                {
                    foreach (Skeleton skel in skeletons)
                    {
                        RenderClippedEdges(skel, dc);

                        if (skel.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            this.DrawBonesAndJoints(skel, dc);
                            //Verifica se sessão esta ativa para gravar
                            if (this._sessaoAtiva)
                            {
                                this.rastrearPontos(skel, dc);//Obtem dados do movimentos                                
                            }
                        }
                        else if (skel.TrackingState == SkeletonTrackingState.PositionOnly)
                        {
                            dc.DrawEllipse(
                            this.centerPointBrush,
                            null,
                            this.SkeletonPointToScreen(skel.Position),
                            BodyCenterThickness,
                            BodyCenterThickness);
                        }
                    }
                }

                // prevent drawing outside of our render area
                this.drawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, RenderWidth, RenderHeight));
            }
        }
        /// <summary>
        /// Execute startup tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Create the drawing group we'll use for drawing
            this.drawingGroup = new DrawingGroup();

            // Create an image source that we can use in our image control
            this.imageSource = new DrawingImage(this.drawingGroup);

            // Display the drawing using our image control
            this.imgKinect.Source = this.imageSource;

            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    //Inicializando sensor
                    this.sensor.Start();
                    //Ativando cronometro
                    this._patcherTimer.Start();
                    //Obtendo angulo atual
                    this._elevationAngle = this.sensor.ElevationAngle;
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                MessageBox.Show("Não há kinect conectado! Conecte o sensor ao computador e inicialize a aplicação novamente!","Aviso!",MessageBoxButton.OK,MessageBoxImage.Warning);
                this.Close();
            }
        }
        /// <summary>
        /// Alterar altura do kinect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Informando na tela
            this.sliderAngulo.Content = ((int)this.slider.Value).ToString();
        }
        /// <summary>
        /// Evento ao clicar no botão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnControle_Click(object sender, RoutedEventArgs e)
        {
            //Verificando controle
            if (this._sessaoAtiva)
            {
                this._sessaoAtiva = false;
                this.lbStatus.Content = "Pausada";
                this.btnControle.Content = "Continuar";
            }
            else
            {
                this._sessaoAtiva = true;
                this.lbStatus.Content = "Ativa";
                this.btnControle.Content = "Pausar";
            }
        }
        /// <summary>
        /// Evento salvar ajuste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjustar_Click(object sender, RoutedEventArgs e)
        {
            //Verifica se sessão esta ativa
            if (this._sessaoAtiva == false)
            {
                //Verificando se houve modificação do angulo
                if (this._elevationAngle != Convert.ToInt32(this.slider.Value))
                {
                    //Obntedo angulo ajustado
                    this._elevationAngle = Convert.ToInt32(this.slider.Value);
                    //Ajustando angulo do kinect
                    this.sensor.ElevationAngle = this._elevationAngle;
                }
                else
                {
                    MessageBox.Show("O angulo do sensor já esta sendo ajustado!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion Eventos
    }
}
