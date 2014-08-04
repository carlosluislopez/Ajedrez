/* Esta es la parte grafica, este es el que debe de imprimir a consola */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ajedrez.GameObjects
{
    public class Game
    {
        private const int MaxCasillas = 64;
        private const int MaxFichas = 24;
        private const int MaxFilas = 8;
        private const int MaxColumnas = 8;
        private int _piezaContador;
        private Tablero tablero;
        private Dictionary<int, string> diccionarioFilas;

        public Game()
        {
            tablero = new Tablero();
            diccionarioFilas = tablero.ColumnaLetraDictionary;
        }

        private string ObtenerNombreCasilla(Casilla casilla)
        {
            var fila = diccionarioFilas[casilla.Fila].ToString();

            var id = fila + casilla.Columna.ToString();

            var nombre = (casilla.Color == ColorCasilla.Negro) ? "N" : "B";

            return "___";
            //return id + nombre;
        }

        private string ObtenerNombreFicha(Pieza pieza)
        {
            var id = pieza.Tipo;
            var diccionario = tablero.PiezasDictionary;
            var tipo = diccionario[id];
            var prefijo = "";

            switch (tipo)
            {
                case "Peon":
                    prefijo = "P";
                    break;
                case "Torre":
                    prefijo = "R";
                    break;
                case "Caballero":
                    prefijo = "N";
                    break;
                case "Alfil":
                    prefijo = "B";
                    break;
                case "Reina":
                    prefijo = "Q";
                    break;
                case "Rey":
                    prefijo = "K";
                    break;
            }

            var nombre = (pieza.Color == ColorFicha.Negro) ? "N" : "B";

            return prefijo + nombre + "1";
        }

        public void DibujarTableroConsola()
        {
            var delimitadorFila = "";
            for (int i = 0; i < (MaxColumnas * 4); i++)
            {
                delimitadorFila += "-";
            }            
            
            for (int fila = 1; fila <= MaxFilas; fila++)
            {
                var filaName = diccionarioFilas[fila];
                Console.Write("{0}  ", filaName);
                for (int col = 1; col <= MaxColumnas; col++)
                {
                    var casilla = tablero.GetCasilla(fila, col);
                    Pieza pieza = null;

                    if (casilla.PiezaContenida != null)
                        pieza = casilla.PiezaContenida;

                    var datoImprimir = ObtenerNombreCasilla(casilla);

                    if (pieza != null)
                        datoImprimir = ObtenerNombreFicha(pieza);

                    Console.Write("{0}|", datoImprimir);
                }

                Console.WriteLine("");
                Console.Write("   ");
                Console.WriteLine(delimitadorFila);
            }
            Console.Write("   ");
            Console.Write(" 1   2   3   4   5   6   7   8");
            Console.WriteLine("");
        }


        public void CoordenadasParaMoverPieza(string casillaOrigen, string casillaDestino) 
        { 
            int filaOrigen = 0;
            int columnaOrigen = 0; 
            int filaDestino = 0; 
            int columnaDestino = 0; 
            convertirCasillaAFilaColumna(ref filaOrigen, ref columnaOrigen, casillaOrigen);
            convertirCasillaAFilaColumna(ref filaDestino, ref columnaDestino, casillaDestino); 
        }

        private void convertirCasillaAFilaColumna(ref int fila, ref int columna, string casilla)
        {
            char fil = casilla.ElementAt(0);
            columna = Convert.ToInt32(casilla.ElementAt(1));
            switch (Char.ToLower(fil))
            {
                case 'a':
                    fila = 0;
                    return;
                case 'b':
                    fila = 1;
                    return;
                case 'c':
                    fila = 2;
                    return;
                case 'd':
                    fila = 3;
                    return;
                case 'e':
                    fila = 4;
                    return;
                case 'f':
                    fila = 5;
                    return;
                case 'g':
                    fila = 6;
                    return;
                case 'h':
                    fila = 7;
                    return;
            }
        }
    }
}
