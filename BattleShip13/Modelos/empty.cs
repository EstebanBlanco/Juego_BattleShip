using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip13.Modelos
{
    class empty : Objeto
    {
        private string nombre = "Vacio";

        public empty(int i, int j)
        {
            this.fila = i;this.columna = j;
            this.boton = new Button();
            this.type = 0;this.name = nombre;
            this.boton.SetBounds(columna * 50, fila * 31, 50, 31);
            this.boton.BackgroundImage = Image.FromFile(@"Imagenes/marAbierto.jpe");
            boton.Click += Boton_Clic;
        }

        /// <summary>
        /// Llama el evento en el controlador de modificar los objetos tanto en la matriz como en la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_Clic(object sender, EventArgs e)
        {
            this.controlador.modificarTipo(this.fila,this.columna);
        }
    }
}
