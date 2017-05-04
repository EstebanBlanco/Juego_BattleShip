using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip13.Modelos
{
    public class Objeto
    {
        public string name;
        public int fila, columna, type;
        public Button boton;
        public Controlador.controlador controlador;
        public SocketConn.Conexion conexion;

        public Objeto()
        {

        }

        public void setControlador(Controlador.controlador controlador)
        {
            this.controlador = controlador;
        }

        public void setConexion(SocketConn.Conexion conn)
        {
            this.conexion = conn;
        }

        public int getTipo()
        {
            return this.type;
        }

        public Button getBoton()
        {
            return this.boton;
        }

        public void desactivarBoton()
        {
            this.boton.Enabled = false;
        }
    }
}
