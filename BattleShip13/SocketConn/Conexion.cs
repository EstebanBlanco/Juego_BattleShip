using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BattleShip13.SocketConn
{
    public class Conexion
    {
        private static Socket socketLevel,socketReady,socketGame;
        private static IPAddress ipPlayer;
        private static IPAddress ipDestino;
        private static IPEndPoint connPointLvl, connPointReady, connPointGame, connSendLvl, connSendReady, connSendGame = null;
        private static string datosRecibidos;

        public Conexion()
        {

            ipPlayer = IPAddress.Parse("192.168.1.5"); //indicamos que escuche por cualquier tarjeta de red local/Esteban:172.24.43.18  
            ipDestino = IPAddress.Parse("192.168.1.4");       
            connPointLvl = new IPEndPoint(ipPlayer, 8000);
            connPointReady = new IPEndPoint(ipPlayer, 8001);
            connPointGame = new IPEndPoint(ipPlayer, 8002);
            connSendLvl = new IPEndPoint(ipDestino, 8000);
            connSendReady = new IPEndPoint(ipDestino, 8001);
            connSendGame = new IPEndPoint(ipDestino, 8002);
            socketLevel = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketReady = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketGame = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Global.Global.nvlRecibido = 0;
            Global.Global.running = true;
        }

        
        private static void CoordsListener()
        {
            //asociamos el socket a la dirección local por la cual escucharemos (IP:Puerto) 
            //en caso de que otro programa esté escuchado por el mismo IP/Puerto nos lanzará un error aquí 
            socketGame.Bind(connPointGame);
            //declarar buffer para recibir los datos y le damos un tamaño máximo de datos recibidos por cada mensaje 
            byte[] buffer = new byte[1024];
            //definir objeto para obtener la IP y Puerto de quien nos envía los datos 
            EndPoint ipRemota = new IPEndPoint(ipDestino, 8002); //no importa que IPAddress o IP definamos aquí 
            //indicamos que el servidor a partir de aquí está corriendo 
            Global.Global.running = true;
            //ciclo que permitirá escuchar continuamente mientras se esté corriendo el servidor 
            while (Global.Global.running)
            {
                if (socketGame.Available == 0) //consultamos si hay datos disponibles que no hemos leido 
                {
                    Thread.Sleep(200); //esperamos 200 milisegundos para volver a preguntar 
                    continue; //esta sentencia hace que el programa regrese al ciclo while(corriendo) 
                }

                //en caso de que si hayan datos disponibles debemos leerlos 
                //indicamos el buffer donde se guardarán los datos y enviamos ipRemota como parámetro de referencia 
                //adicionalmente el método ReceiveFrom nos devuelve cuandos bytes se leyeron 
                int contadorLeido = socketGame.ReceiveFrom(buffer, ref ipRemota);
                //ahora tenemos los datos en buffer (1024 bytes) pero sabemos cuantos recibimos (contadorLeido) 
                //convertimos esos bytes a string 
                datosRecibidos = Encoding.Default.GetString(buffer, 0, contadorLeido);
                MessageBox.Show(datosRecibidos);
                if (datosRecibidos.Equals("R"))
                {
                    Global.Global.enemySurrender = true;
                }
                else if (datosRecibidos.Length <= 2) //Es un indicador de puntuacion
                {
                    Global.Global.resultado = Int32.Parse(datosRecibidos);
                }
                else
                {
                    Global.Global.coordenadas = datosRecibidos;//Son coordenadas
                }
                
            }
        }
        

        private static void LevelListener()
        {
            //El bind asocia el socket a una IP y puerto especificos, que en este caso van en un EndPoint (connPointLvl). El problema que tenia es que no se puede asociar dos sockets a un
            //mismo EndPoint, por eso tuve que hacer para los 3 sockets, 3 EndPoints diferentes. Y como ahora cada funciond de escuchar utiliza un puerto diferente, se requirieron 3 
            //funciones de enviar distintas, una para cada puerto. Seguro que si hay una forma mas eficiente... pero ahorita esto es lo que hay
            socketLevel.Bind(connPointLvl);
            //buffer donde se recibiran los datos
            byte[] buffer = new byte[1024];
            //Endpoint es el conjunto de la IP y el puerto. Aquí se especificó la ip de la computadora de donde se quiere escuchar, aunque según había leido no era necesario ponerla.
            EndPoint ipRemota = new IPEndPoint(ipDestino, 8000); //no importa que IPAddress o IP definamos aquí 
            Global.Global.running = true; // Activamos el ciclo 
            while (Global.Global.running)
            {
                if (socketLevel.Available == 0) // Available nos dice si se ha leido algo nuevo, si es 0 quiere decir que no
                {
                    Thread.Sleep(200); //esperamos 200 milisegundos para volver a preguntar si llegó info
                    continue;
                }

                //receive from guarda los datos recibidos en el buffer, en contador leido se guarda la cantidad para posteriormente decodificar
                int contadorLeido = socketLevel.ReceiveFrom(buffer, ref ipRemota);
                datosRecibidos = Encoding.Default.GetString(buffer, 0, contadorLeido); //Se decodifica la info
                Global.Global.nvlRecibido = Int32.Parse(datosRecibidos); //Se convierte a entero y se guarda en la global
            }
            LingerOption lo = new LingerOption(false, 0);
            socketLevel.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lo);
        }

        private static void ReadyListener()
        {
            socketReady.Bind(connPointReady);
            byte[] buffer = new byte[1024];
            //definir objeto para obtener la IP y Puerto de quien nos envía los datos 
            EndPoint ipRemota = new IPEndPoint(ipDestino, 8001); //no importa que IPAddress o IP definamos aquí 
            Global.Global.running = true;
            while (Global.Global.running)
            {
                if (socketReady.Available == 0) //consultamos si hay datos disponibles que no hemos leido 
                {
                    Thread.Sleep(200); //esperamos 200 milisegundos para volver a preguntar 
                    continue; //esta sentencia hace que el programa regrese al ciclo while(corriendo) 
                }

                //en caso de que si hayan datos disponibles debemos leerlos 
                //indicamos el buffer donde se guardarán los datos y enviamos ipRemota como parámetro de referencia 
                //adicionalmente el método ReceiveFrom nos devuelve cuandos bytes se leyeron 
                int contadorLeido = socketReady.ReceiveFrom(buffer, ref ipRemota);
                //ahora tenemos los datos en buffer (1024 bytes) pero sabemos cuantos recibimos (contadorLeido) 
                //convertimos esos bytes a string 
                datosRecibidos = Encoding.Default.GetString(buffer, 0, contadorLeido);
                Global.Global.banderaListo = Int32.Parse(datosRecibidos);
                Console.WriteLine(datosRecibidos);
            }

        }

        public void EnviarLvl(string data)
        {
            byte[] dataBytes = Encoding.Default.GetBytes(data);
            socketLevel.SendTo(dataBytes, connSendLvl);
        }

        public void EnviarReady(string data)
        {
            byte[] dataBytes = Encoding.Default.GetBytes(data);
            socketReady.SendTo(dataBytes, connSendReady);
        }

        public void EnviarGame(string data)
        {
            byte[] dataBytes = Encoding.Default.GetBytes(data);
            socketGame.SendTo(dataBytes, connSendGame);
        }

        public void WaitForAction()
        {
            new Thread(CoordsListener).Start();
        }

        public void getLevel()
        {
            //Aca se inicializa el hilo. Es un proceso en segundo plano, por eso requerí de un while que corriera hasta que se escuchara un valor, porque se necesita ese valor para seguir.
            Thread hiloLvl = new Thread(LevelListener);
            hiloLvl.IsBackground = true;
            hiloLvl.Start();
        }

        public void WaitPlayerReady()
        {
            new Thread(ReadyListener).Start();
        }

    }
}
