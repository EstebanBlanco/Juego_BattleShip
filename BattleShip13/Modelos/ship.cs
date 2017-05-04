using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip13.Modelos
{
    class ship : Objeto
    {
        private string nombre = "Buque";

        public ship(int i, int j)
        {
            this.fila = i; this.columna = j;
            this.boton = new Button();
            this.type = 1; this.name = nombre;
            this.boton.SetBounds(columna * 50, fila * 31, 50, 31);
            this.boton.BackgroundImage = Image.FromFile(@"Imagenes/marAbiertoBuque.jpe");
            boton.Click += Boton_Clic;
        }

        private void Boton_Clic(object sender, EventArgs e)
        {
            this.controlador.modificarTipo(this.fila, this.columna);
        }
    }
}
