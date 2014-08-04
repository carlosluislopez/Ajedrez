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
        private readonly Tablero _tablero;
        private readonly Dictionary<int, string> _diccionarioColumnas;

        public Game()
        {
            _tablero = new Tablero();
            _diccionarioColumnas = _tablero.ColumnaLetraDictionary;
        }

        private string ObtenerNombreCasilla(Casilla casilla)
        {
            var fila = _diccionarioColumnas[casilla.Fila];

            var id = fila + casilla.Columna;

            var nombre = (casilla.Color == ColorCasilla.Negro) ? "N" : "B";

            return "___";
            //return id + nombre;
        }

        private string ObtenerNombreFicha(Pieza pieza)
        {
            var id = pieza.Tipo;
            var diccionario = _tablero.PiezasDictionary;
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

            return "▲" + prefijo + nombre;
        }

        public void DibujarTableroConsola()
        {
            var delimitadorFila = "";
            for (int i = 0; i < (MaxColumnas * 4); i++)
            {
                delimitadorFila += "-";
            }            
            
            for (int fila = MaxFilas; fila >= 1; fila--)
            {
                //var filaName = diccionarioColumnas[fila];
                Console.Write("{0}  ", fila);
                for (int col = 1; col <= MaxColumnas; col++)
                {
                    var casilla = _tablero.GetCasilla(fila, col);
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
            Console.Write(" A   B   C   D   E   F   G   H");
            Console.WriteLine("");
        }

        private void convertirCasillaAFilaColumna(ref int fila, ref int columna, string casilla)
        {
            char col = casilla[0];
            fila = int.Parse(casilla[1].ToString());
            switch (Char.ToLower(col))
            {
                case 'a':
                    columna = 1;
                    return;
                case 'b':
                    columna = 2;
                    return;
                case 'c':
                    columna = 3;
                    return;
                case 'd':
                    columna = 4;
                    return;
                case 'e':
                    columna = 5;
                    return;
                case 'f':
                    columna = 6;
                    return;
                case 'g':
                    columna = 7;
                    return;
                case 'h':
                    columna = 8;
                    return;
            }
        }

        private string ConvertirFilaColumnaACasilla(int fila, int columna)
        {
            return _diccionarioColumnas[columna] + fila;
        }

        public void renderGame()
        {
            int respuesta = 0;
            int filaOrigen = 0;
            int columnaOrigen = 0;
            int filaDestino = 0;
            int columnaDestino = 0;
            Casilla casillaOrigen, casillaDestino;
            string piezaOrigen, piezaDestino;
            string colorJugador = "blanco";
            string respuesta2 = null;
            do
            {


                do
                {
                    DibujarTableroConsola();
                    Console.WriteLine("Turno del jugador " + colorJugador);
                    Console.WriteLine("Seleccione la pieza a mover");
                    piezaOrigen = Console.ReadLine();
                    convertirCasillaAFilaColumna(ref filaOrigen, ref columnaOrigen, piezaOrigen);
                    casillaOrigen = _tablero.GetCasilla(filaOrigen, columnaOrigen);
                    Console.WriteLine("Estas son sus posibles movimientos: ");
                    foreach (var posibilidades in _tablero.MovementPosibilitiesList(casillaOrigen))
                        Console.WriteLine(ConvertirFilaColumnaACasilla(posibilidades.Fila, posibilidades.Columna));

                    Console.WriteLine("Que quiere hacer?: ");
                    Console.WriteLine(" 1. Mover la pieza: ");
                    Console.WriteLine(" 2. Seleccionar otra pieza: ");
                    respuesta2 = Console.ReadLine();
                } while (respuesta2 != "1");

                Console.WriteLine("Seleccione lugar de destino: ");
                piezaDestino = Console.ReadLine();
                convertirCasillaAFilaColumna(ref filaDestino, ref columnaDestino, piezaDestino);
                casillaDestino = _tablero.GetCasilla(filaDestino, columnaDestino);
                var response = _tablero.MovePiece(casillaOrigen, casillaDestino);
                Console.WriteLine(response.ToString());
                if (colorJugador.Equals("blanco"))
                    colorJugador = "negro";
                else
                    colorJugador = "blanco";
            } while (respuesta != 3);
        }
    }
}

