using System;
using System.IO;
using System.Windows.Forms;
using SbsSW.SwiPlCs;
using SbsSW.SwiPlCs.Exceptions;
using NUnit.Framework;

namespace BattleShip13.Vista
{
    public partial class BattleShip : Form
    {
        private SocketConn.Conexion conexion = new SocketConn.Conexion();
        private Controlador.controlador controlador;
        private Vista.Sea sea;
        public BattleShip()
        {
            InitializeComponent();
        }

        private void nivel1_Click_1(object sender, EventArgs e)
        {
            InicializarVentana(1, 4, 185, 68, 500, 68);
            conexion.EnviarLvl("1");
        }

        private void nivel2_Click_1(object sender, EventArgs e)
        {
            InicializarVentana(1, 5, 150, 68, 500, 68);
            conexion.EnviarLvl("2");
        }

        private void nivel3_Click_1(object sender, EventArgs e)
        {
            InicializarVentana(1, 6, 100, 68, 500, 68);
            conexion.EnviarLvl("3");
        }

        public void InicializarVentana(int player, int tamanno, int xA, int yA, int xE, int yE)
        {
            this.controlador = new Controlador.controlador(tamanno,player);
            this.controlador.crearMatriz();
            //Se crea la ventana de juego, con los tamaños predeterminados
            this.sea = new Vista.Sea();
            this.sea.iniciarComponentes(tamanno, xA, yA, xE, yE);
            //Se meten los objetos.
            this.sea.setControlador(this.controlador);
            this.controlador.setCampoBatalla(this.sea);
            sea.StartPosition = FormStartPosition.CenterScreen;
            this.controlador.MeterComponentesEnVentana();
            if (player == 1)
            {
               conexion.WaitPlayerReady();
               sea.Show(this);
            }
            else
            {
                conexion.WaitPlayerReady();
                Application.Run(sea);
            };
        }

        private void BattleShip_Load_1(object sender, EventArgs e)
        {
            //Lee las variables del entorno, donde se encuentra Ubicado prolog.exe.
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\\bin");
            String[] param = { "-q", "-f", @"conexion.pl" };//Busca el archivo de conocimiento, esta dentro de debug 
            PlEngine.Initialize(param);//Inicializa el archivo de conocimiento.

            PlQuery consulta1 = new PlQuery("cargar(" + "Se_leyo" + ",R)");//Ejecuta la consulta a prolog. devolviendo n resultados.
            foreach (PlQueryVariables n in consulta1.SolutionVariables)//Recorre todos los resultados devueltos.
            {
                Console.WriteLine(n["R"]);//Los imprime en pantalla.
            }
            PlEngine.PlCleanup();
        }
    }
}
