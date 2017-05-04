using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace BattleShip13.Controlador
{
    public class controlador
    {
        private Modelos.Objeto[,] aliados;
        private Modelos.Objeto[,] tercerReich;
        private int tamaño;
        private Vista.Sea campoBatalla;
        private int cantidadArmasGuerra;
        private SocketConn.Conexion conexion;
        private bool gameRunning;

        /// <summary>
        /// Constructor de la clase controlador
        /// </summary>
        /// <param name="tamaño">Tamaño del campo de batalla(matriz)</param>
        public controlador(int tamaño, int player)
        {
            cantidadArmasGuerra = 1; // 1 para pruebas, es 6
            this.tamaño = tamaño;
            aliados = new Modelos.Objeto[this.tamaño, this.tamaño];
            tercerReich = new Modelos.Objeto[this.tamaño, this.tamaño];
            conexion = new SocketConn.Conexion();
            gameRunning = true;
            if (player == 1)
            {
                Global.Global.myTurn = true;
            }
            else
            {
                Global.Global.myTurn = false;
            }
            
        }

        public void Playing()
        {
            // En este punto no esta sirviendo porque el while bloquea el flujo de datos y no permite utilizar los botones, hay que intentar meter todo este while en un hilo.
            while (gameRunning)
            {
                if (Global.Global.enemySurrender == true)//el jugador se rinde. Falta programar boton de rendicion
                {
                    gameRunning = false;
                }
                else if (Global.Global.resultado != 1) //Se escuchó una respuesta de si le dimos o no a un barco 
                {
                    if (Global.Global.resultado == 0)
                    {
                        MessageBox.Show("No le has acertado a ningun enemigo...");
                    }
                    else if (Global.Global.resultado == 6)
                    {
                        MessageBox.Show("Le acertaste a un barco!");
                    }
                    else if (Global.Global.resultado == 8)
                    {
                        MessageBox.Show("Le acertaste a un avión!");
                    }
                    else if (Global.Global.resultado == 10)
                    {
                        MessageBox.Show("Le acertaste a un submarino!");
                    }
                    Global.Global.resultado = 1;
                }
                else if (Global.Global.coordenadas != "D")
                {
                    string[] resCoords = Global.Global.coordenadas.Split(',');
                    int points = elementoEnemigoSeleccionado(Int32.Parse(resCoords[0]),Int32.Parse(resCoords[1]));
                    //Hacer la misma validacion de arriba, pero con la variable points, para mostrar la imagen del arma destruida, si es que se destruyo
                    conexion.EnviarGame(points.ToString());
                    Global.Global.coordenadas = "D";
                    Global.Global.myTurn = true;
                }
                
            }
        }

        /// <summary>
        /// Pide la ventana donde se pintara el juego.
        /// </summary>
        /// <param name="campo">La ventana ya instanciada</param>
        public void setCampoBatalla(Vista.Sea campo)
        {
            this.campoBatalla = campo;
            this.campoBatalla.Size = new System.Drawing.Size(900, 600);
        }

        /// <summary>
        /// Recorre las matrices y crea objetos nuevos de tipo empty.
        /// </summary>
        public void crearMatriz()
        {
            for (int i = 0; i < tamaño; i++)
                for (int j = 0; j < tamaño; j++)
                {
                    Modelos.empty vacio = new Modelos.empty(i, j);
                    aliados[i, j] = vacio;
                }
            //Llena la matriz del enemigo.
            for (int i = 0; i < tamaño; i++)
                for (int j = 0; j < tamaño; j++)
                {
                    Modelos.enemy enemigo = new Modelos.enemy(i, j);
                    tercerReich[i, j] = enemigo;
                }
        }

        /// <summary>
        /// Este llama a la ventana y le mete los botones de la matriz con sus posiciones.
        /// </summary>
        public void MeterComponentesEnVentana()
        {
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    aliados[i, j].setControlador(this);
                    campoBatalla.insertarObjetos(aliados[i, j].getBoton());
                }
                Console.WriteLine();
            }
            ///Esta se tiene que pintar por medio del socket.
            for (int i = 0; i < tamaño; i++)
                for (int j = 0; j < tamaño; j++)
                {
                    Console.Write(tercerReich[i, j].getTipo());
                    tercerReich[i, j].setControlador(this);
                    tercerReich[i, j].setConexion(conexion);
                    campoBatalla.insertarObjetos2matriz(tercerReich[i, j].getBoton());
                }
            Console.WriteLine();
        }

        /// <summary>
        /// Modifica el tipo de objeto especificado por el usuario.
        /// </summary>
        /// <param name="fila">Ubicacion Y</param>
        /// <param name="Columna">Ubicacion X</param>
        public void modificarTipo(int fila, int Columna)
        {
            Vista.opciones escogerArmamento = new Vista.opciones(this, conexion, fila, Columna);
            escogerArmamento.StartPosition = FormStartPosition.CenterScreen;
            escogerArmamento.Show(campoBatalla);

        }

        /// <summary>
        /// Ingresa el objeto nuevo, a la matriz de los aliados.
        /// </summary>
        /// <param name="objeto">Objeto creado</param>
        /// <param name="fila">Ubicacion Y</param>
        /// <param name="Columna">Ubicacion X</param>
        public void objetoCreado(Modelos.Objeto objeto, int fila, int Columna)
        {
            campoBatalla.ladoAliado.Controls.Remove(aliados[fila, Columna].getBoton());
            objeto.setControlador(this);
            aliados[fila, Columna] = objeto;
            campoBatalla.ladoAliado.Controls.Add(objeto.getBoton());
        }

        //Nuevas..
        /// <summary>
        /// Abre la conexion con el archivo de pl.
        /// </summary>
        public void abrirConexionProlog()
        {
            //Lee las variables del entorno, donde se encuentra Ubicado prolog.exe.
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\\bin");
            String[] param = { "-q", "-f", @"conexion.pl" };//Busca el archivo de conocimiento, esta dentro de debug 
            PlEngine.Initialize(param);//Inicializa el archivo de conocimiento.
        }

        public void cargarArchvioProlog()
        {
            abrirConexionProlog();
            PlQuery eliminar = new PlQuery("borrar");
            eliminar.NextSolution();
            PlEngine.PlCleanup();

            string fila = "";
            for (int i = 0; i < this.tamaño; i++)
            {
                fila = "[";
                for (int j = 0; j < this.tamaño; j++)
                {
                    if(j == this.tamaño-1)
                    {
                        fila += aliados[i, j].getTipo().ToString() + "]";
                    }
                    else
                    {
                        fila += aliados[i, j].getTipo().ToString() + ",";
                    }
                }
                abrirConexionProlog();
                Console.WriteLine(i.ToString() +" "+ fila);
                PlQuery insert = new PlQuery("insertarFila(" + i.ToString() + "," + fila.ToString() + ")");//Ejecuta la consulta a prolog. devolviendo n resultados.
                insert.NextSolution();
                PlEngine.PlCleanup();
            }
            Console.WriteLine("Se escribio la matriz en prolog.");
            //Desactivas los botones
            for (int i = 0; i < tamaño; i++)
                for (int j = 0; j < tamaño; j++)
                {
                    aliados[i, j].desactivarBoton();
                }
            Console.WriteLine("Se desactivaron los botones de los aliados.");
        }

        public int elementoEnemigoSeleccionado(int i,int j)
        {
            //Esto hace la pregunta y devuelve lo que se encuentra en la posicion deseada.
            //Todo lo hace en el archivo de prolog, no usa nada de C#.Aqui es donde se tiene que implementar lo del socket,
            //Debe de realizar la llamada al segundo jugador y viceversa. El segundo jugador debe de tener un metodo que reciba estos parametros,
            //i,j y realizar este metodo de abajo, en su archivo de prolog, luego tiene que retornar el tipo y el puntaje ganado. 
            string tipoBarco = "";
            string puntosBarco = "";
            abrirConexionProlog();
            PlQuery consultaTipoPuntosBarco = new PlQuery("buscarBarco(" + i.ToString() + "," + j.ToString() + ",R,P)");//Ejecuta la consulta a prolog. devolviendo n resultados.
            foreach (PlQueryVariables n in consultaTipoPuntosBarco.SolutionVariables)//Recorre todos los resultados devueltos.
            {
                tipoBarco = n["R"].ToString();
                puntosBarco = n["P"].ToString();
            }
            PlEngine.PlCleanup();
            Console.WriteLine("Esto devuelve: " + tipoBarco + " " + puntosBarco);//Los imprime en pantalla.
            return Int32.Parse(puntosBarco);
        }

        public void reducirCantArmas()
        {
            cantidadArmasGuerra -= 1;
        }

        public int getCantArmas()
        {
            return cantidadArmasGuerra;
        }

        
    }
}

