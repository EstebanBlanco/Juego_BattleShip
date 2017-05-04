using System.Windows.Forms;

namespace BattleShip13
{
    public class Inicio
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        //private Controlador.controlador controlador;
        //private Vista.Sea sea;
        private Vista.BattleShip principal;
        private SocketConn.Conexion conexion;
        private int player;

        public void Iniciar()
        {
            player = 2;
            conexion = new SocketConn.Conexion();
            Application.SetCompatibleTextRenderingDefault(true);
            this.principal = new Vista.BattleShip();
            Application.EnableVisualStyles();
            this.principal.StartPosition = FormStartPosition.CenterScreen;

            if (player == 1){Application.Run(this.principal);}
            else
            {
                conexion.getLevel();
                while (Global.Global.nvlRecibido != 1 && Global.Global.nvlRecibido != 2 && Global.Global.nvlRecibido != 3){continue;}

                Global.Global.running = false;

                if (Global.Global.nvlRecibido == 1){this.principal.InicializarVentana(2, 4, 185, 68, 500, 68);}

                else if (Global.Global.nvlRecibido == 2){this.principal.InicializarVentana(2, 5, 150, 68, 500, 68);}

                else {this.principal.InicializarVentana(2, 6, 100, 68, 500, 68);}
            }
        }

        static void Main()
        {
            Inicio inicio = new Inicio();
            inicio.Iniciar();
        }
    }
}
