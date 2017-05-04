using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip13.Modelos
{
    class airplane : Objeto
    {
        private string nombre = "Jet";

        public airplane(int i, int j)
        {
            this.fila = i; this.columna = j;
            this.boton = new Button();
            this.type = 3; this.name = nombre;
            this.boton.SetBounds(columna * 50, fila * 31, 50, 31);
            this.boton.BackgroundImage = Image.FromFile(@"Imagenes/marAbiertoJet.jpe");
            boton.Click += Boton_Clic;
        }

        private void Boton_Clic(object sender, EventArgs e)
        {
            this.controlador.modificarTipo(this.fila, this.columna);
        }
    }
}
