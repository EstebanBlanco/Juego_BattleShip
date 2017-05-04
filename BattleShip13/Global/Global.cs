using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip13.Global
{
    public static class Global
    {
        public static int nvlRecibido;
        public static int banderaListo = 0;
        public static bool running;
        public static bool enemySurrender = false;
        public static int resultado = 1; // Le puse valor x defecto 1, porque si viene en 0 quiere decir que no le dio a nada
        public static string coordenadas = "D";
        public static bool myTurn;

    }
}
