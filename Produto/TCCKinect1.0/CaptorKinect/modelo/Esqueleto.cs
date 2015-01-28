using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptorKinect.modelo
{
    class Esqueleto
    {
        //Métodos
        public Head head { get; set; }
        public Body body { get; set; }
        public ShoulderCenter shoulderCenter { get; set; }
        public ShoulderRight shoulderRight { get; set; }
        public ShoulderLeft shoulderLeft { get; set; }
        public ElbowRight elbowRight { get; set; }
        public ElbowLeft elbowLeft { get; set; }
        public WristRight wristRight { get; set; }
        public WristLeft wristLeft { get; set; }
        public HandRight handRight { get; set; }
        public HandLeft handLeft { get; set; }
        public Spine spine { get; set; }
        public HipCenter hipCenter { get; set; }
        public HipRight hipRight { get; set; }
        public HipLeft hipLeft { get; set; }
        public KneeRight kneeRight { get; set; }
        public KneeLeft kneeLeft { get; set; }
        public AnkleRight ankleRight { get; set; }
        public AnkleLeft ankleLeft { get; set; }
        public FootRight footRight { get; set; }
        public FootLeft footLeft { get; set; }
        /// <summary>
        /// Construtor
        /// </summary>
        public Esqueleto()
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="head">Cabeça</param>
        /// <param name="shoulderCenter">Centro do ombro</param>
        /// <param name="shoulderRight">Ombro direito</param>
        /// <param name="shoulderLeft">Ombro esquerdo</param>
        /// <param name="elbowRight">Cotovelo direito</param>
        /// <param name="elbowLeft">Cotovelo esquerdo</param>
        /// <param name="wristRight">Pulso direito</param>
        /// <param name="wristLeft">Pulso esquerda</param>
        /// <param name="handRight">Mão direita</param>
        /// <param name="handLeft">Mão esquerda</param>
        /// <param name="spine">Centro do corpo</param>
        /// <param name="hipCenter">Centro do quadril</param>
        /// <param name="hipRight">Quadril direito</param>
        /// <param name="hipLeft">Quadril esquerdo</param>
        /// <param name="kneeRight">Joelho direito</param>
        /// <param name="kneeLeft">Joelo esquerdo</param>
        /// <param name="ankleRight">Calcanhar direito</param>
        /// <param name="ankleLeft">Calcanhar esquerdo</param>
        /// <param name="footRight">Pé direito</param>
        /// <param name="footLeft">Pé esquerdo</param>
        public Esqueleto(Head head, Body body, ShoulderCenter shoulderCenter, ShoulderRight shoulderRight,
            ShoulderLeft shoulderLeft, ElbowRight elbowRight, ElbowLeft elbowLeft,
            WristRight wristRight, WristLeft wristLeft, HandRight handRight, HandLeft handLeft,
            Spine spine, HipCenter hipCenter, HipRight hipRight, HipLeft hipLeft,
            KneeRight kneeRight, KneeLeft kneeLeft, AnkleRight ankleRight, AnkleLeft ankleLeft,
            FootRight footRight, FootLeft footLeft)
        {
            this.head = head;
            this.body = body;
            this.shoulderCenter = shoulderCenter;
            this.shoulderRight = shoulderRight;
            this.shoulderLeft = shoulderLeft;
            this.elbowRight = elbowRight;
            this.elbowLeft = elbowLeft;
            this.wristRight = wristRight;
            this.wristLeft = wristLeft;
            this.handRight = handRight;
            this.handLeft = handLeft;
            this.spine = spine;
            this.hipCenter = hipCenter;
            this.hipRight = hipRight;
            this.hipLeft = hipLeft;
            this.kneeRight = kneeRight;
            this.kneeLeft = kneeLeft;
            this.ankleRight = ankleRight;
            this.ankleLeft = ankleLeft;
            this.footRight = footRight;
            this.footLeft = footLeft;
        }
    }
}
