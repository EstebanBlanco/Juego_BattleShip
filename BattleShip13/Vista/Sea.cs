using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip13.Vista
{
    public partial class Sea : Form
    {
        private Controlador.controlador controlador;
        public Panel ladoAliado = new Panel();
        private Panel ladoEnemigo = new Panel();

        public Sea()
        {
            InitializeComponent();
            //iniciarComponentes();
        }

        public void iniciarComponentes(int tamaño, int xA, int yA, int xE, int yE)
        {
            //185, 68 500, 68
            ladoAliado = new Panel();
            ladoAliado.Size = new System.Drawing.Size(tamaño * 50, tamaño * 31);
            ladoAliado.Location = new System.Drawing.Point(xA, yA);
            this.Controls.Add(ladoAliado);
            ladoEnemigo = new Panel();
            ladoEnemigo.Size = new System.Drawing.Size(tamaño * 50, tamaño * 31);
            ladoEnemigo.Location = new System.Drawing.Point(xE, yE);
            this.Controls.Add(ladoEnemigo);
        }

        public void setControlador(Controlador.controlador controlador)
        {
            this.controlador = controlador;
        }

        /// <summary>
        /// Esta llamada la hace desde el controlador, allá va leyendo la matriz logica y va mandando cada boton hacia a quí
        /// para meterlo a la ventana. 
        /// </summary>
        /// <param name="boton"></param>
        public void insertarObjetos(Button boton)
        {
            this.ladoAliado.Controls.Add(boton);
            this.ladoAliado.Refresh();
            //this.Controls.Add(boton);
        }

        /// <summary>
        /// Esta llamada la hace desde el controlador, allá va leyendo la matriz logica y va mandando cada boton hacia a quí
        /// para meterlo a la ventana. 
        /// </summary>
        /// <param name="boton"></param>
        public void insertarObjetos2matriz(Button boton)
        {
            this.ladoEnemigo.Controls.Add(boton);
            //this.Controls.Add(boton);
        }

        public void reepintarMatrizJugador()
        {

            this.ladoAliado.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void jugar_Click(object sender, EventArgs e)
        {
            this.controlador.cargarArchvioProlog();
        }
    }
}
