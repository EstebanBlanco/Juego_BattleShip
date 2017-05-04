using System;
using System.Threading;
using System.Windows.Forms;

namespace BattleShip13.Vista
{
    public partial class opciones : Form
    {
        
        Controlador.controlador controlador;
        SocketConn.Conexion conexion;
        int fila, Columna;
        public opciones(Controlador.controlador controlador, SocketConn.Conexion conexion, int fila, int Columna)
        {
            InitializeComponent();
            this.controlador = controlador;
            this.conexion = conexion;
            this.fila = fila;
            this.Columna = Columna;
        }

        private void aceptar_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine(tipoNave.SelectedItem);
            if (tipoNave.SelectedItem.Equals("Avión"))
            {
                Modelos.airplane avion = new Modelos.airplane(fila, Columna);
                this.Close();
                controlador.objetoCreado(avion, fila, Columna);
                controlador.reducirCantArmas();
                VerificarCantidad();


            }
            else if(tipoNave.SelectedItem.Equals("Submarino"))
            {
                Modelos.submarine submarino = new Modelos.submarine(fila, Columna);
                this.Close();
                controlador.objetoCreado(submarino, fila, Columna);
                controlador.reducirCantArmas();
                VerificarCantidad();
            }
            else if (tipoNave.SelectedItem.Equals("Barco"))
            {
                Modelos.ship barco = new Modelos.ship(fila,Columna);
                this.Close();
                controlador.objetoCreado(barco,fila,Columna);
                controlador.reducirCantArmas();
                VerificarCantidad();
            }
            else
            {
                this.Close();
            }

        }
        private void VerificarCantidad()
        {
            if (controlador.getCantArmas() == 0)
            {
                //Este jugador está listo, debe enviar los datos y esperar al otro.
                conexion.EnviarReady("1");
                while (Global.Global.banderaListo != 1)
                {
                    Console.WriteLine("Esperando jugador");
                    continue;
                }
                MessageBox.Show("Listo, a jugar!");
                conexion.WaitForAction();
                new Thread(controlador.Playing).Start();
            }
        }

    }
}
