using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip13.Modelos
{
    class enemy : Objeto
    {
        private string nombre = "Enemigo";

        public enemy(int i, int j)
        {
            this.fila = i; this.columna = j;
            this.boton = new Button();
            this.type = 0; this.name = nombre;
            this.boton.SetBounds(columna * 50, fila * 31, 50, 31);
            this.boton.BackgroundImage = Image.FromFile(@"Imagenes/marAbierto.jpe");
            boton.Click += Boton_Clic;
        }

        /// <summary>
        /// Llama al envento que envia los parametros por el socket, hacia el segundo jugador,
        /// lleva la fila y la columna del objetos instatnciado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_Clic(object sender, EventArgs e)
        {
            Console.WriteLine(fila+" "+ columna);
            if (Global.Global.myTurn)
            {
                this.conexion.EnviarGame(fila.ToString()+","+columna.ToString());
                //this.controlador.elementoEnemigoSeleccionado(fila, columna);
                //Hay q Deshabilitar el boton, para ello crear una funcion en el controlador y llamarla
                Global.Global.myTurn = false;
            }
            else
            {
                MessageBox.Show("No estás en tu turno.");
            }
        }
    }
}
