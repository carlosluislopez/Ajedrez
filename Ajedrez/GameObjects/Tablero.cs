using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.GameObjects
{

    public enum ErrorCode
    {
        NoError,OutOfBounds,InvalidMove,CancelledMove
    }

    enum Direccion
    {
        Up,Down,Left,Right,RightUp,LeftUp,RightDown,LeftDown    
    }
    enum TipoPieza
    {
        Peon,Torre,Caballero,Alfil,Reina,Rey
    }
        public class Tablero
        {
            private readonly Dictionary<int, string> _columnaLetraDictionary = new Dictionary<int, string>
            {
                {1,"A"},{2,"B"},{3,"C"},{4,"D"},{5,"E"},{6,"F"},{7,"G"},{8,"H"}
            };
            private readonly Dictionary<int, string> _piezasDictionary = new Dictionary<int, string>
            {
                {0, "Peon"},{1, "Torre"},{2, "Caballero"},{3, "Alfil"},{4, "Reina"},{5, "Rey"}
            };
            public Dictionary<int, string> ColumnaLetraDictionary{get { return _columnaLetraDictionary; }}
            public Dictionary<int, string> PiezasDictionary{get { return _piezasDictionary; }}
            private const int MaxCasillas = 64;
            private const int MaxFichas = 24;
            private const int MaxFilas = 8;
            private const int MaxColumnas = 8;
            private int PiezaContador = 0;

            
            private List<Pieza> _piezas;
            private List<Casilla> _casillas;

            public Tablero()
            { 
                _piezas = new List<Pieza>(MaxFichas);
                _casillas = new List<Casilla>(MaxCasillas);

                CrearCasillas();
                LlenarCasillas();
               //
            }

            private void LlenarCasillas()
            {
                foreach (var casilla in _casillas)
                {
                    InitialPosition(casilla);
                }
            }

            private void InitialPosition(Casilla casilla)
            {
                //Colocar la pieza correcta en la casilla.
                //El contador de piezas provee el ID
                throw new NotImplementedException();
            }

            private void CrearCasillas()
            {
                var tempColor = ColorCasilla.Negro;

                for (var columna = 1; columna <= MaxColumnas; columna++)
                {
                    for (var fila = 1; fila <= MaxFilas; fila++)
                    {
                        _casillas.Add
                            (
                            new Casilla
                                {
                                    Color = tempColor,
                                    Columna = columna,
                                    Fila = fila
                                }
                            );
                        tempColor = tempColor == ColorCasilla.Negro ? ColorCasilla.Blanco : ColorCasilla.Negro;
                    }
                }

            }
            

            private Pieza GetPiezaDeCasilla(int idCasilla)
            {
                var piezas = _casillas.AsEnumerable().Where(x => x.PiezaContenida != null).ToArray();
                return piezas.Any() ? piezas[0].PiezaContenida : null;
                //SI una casilla tiene mas de 1 ficha, hay un ERROR
            }
            private Pieza GetPiezaDeCasilla(int fila, int columna)
            {
                return GetPiezaDeCasilla(GetCasilla(fila,columna).Id);
            }
            private Casilla GetCasilla(int fila, int columna)
            {
                var casillas = _casillas.AsEnumerable().Where(casilla => casilla.Columna == fila && casilla.Fila == columna).ToArray();
                return casillas.Any() ? casillas[0]: null;
            }
            private Casilla GetCasilla(int id)
            {
                return _casillas.Find(casilla => casilla.Id == id);
            }

            /* Esto debe ser int Queremos separar Grafico/logico, que los strings esten en el "program", el retorno  solo sera un "codigo"
             * para que "game" sepa que escribir"
             */
            public ErrorCode MoverPieza(int idCasillaOrigen, int idCasillaDestuno)
            {
                return ErrorCode.NoError;
            }

            public ErrorCode MoverPieza(int filaOrigen, int columnaOrigen, int destinoFila, int destinoColumna)
            {
                return ErrorCode.NoError;
            }
          public bool DeadLock()
            {
             //Verificar cada pieza para ver si esta locked.
                return false;
            }

            public List<Casilla> MovementPosibilitiesList(Casilla casilla)
            {
                var piezaEnCasilla = casilla.PiezaContenida;
                return piezaEnCasilla == null ? new List<Casilla>() : MovimientoPieza(casilla);
                //Retorna null si no hay pizas en la casilla, retorna vacio si la pieza no tienen movimientos disponibles, o retorna los movimientos 
                //disponibles cuando los hay
                //Aqui es donde ingresamos la casilla seleccionada para ver que opciones de movimiento tenemos, si no hay opciones retorna
                //null y asi sabemos que esta pieza no se puede mover en este momento. aqui entran en juego los algoritmos de pathing.
                //ejemplo peon solo puede mover 1 cuadrado excepto si esta en su posicion inicial, is hay piezas en diagonal a el, puede mover
                //y comer. Como las piezas se accesaran desde su casilla, simplemente quitar la pieza de la casilla deberia tomalra como borrada
            }

            private List<Casilla> MovimientoPieza(Casilla casilla)
            {
                var returnList = new List<Casilla>();
                switch ((TipoPieza)casilla.PiezaContenida.Tipo)
                {
                    case TipoPieza.Peon:
                        break;
                    case TipoPieza.Torre:
                        returnList.AddRange(RangeCheck(casilla,casilla,Direccion.Up));
                        returnList.AddRange(RangeCheck(casilla,casilla,Direccion.Down));
                        returnList.AddRange(RangeCheck(casilla,casilla,Direccion.Left));
                        returnList.AddRange(RangeCheck(casilla,casilla,Direccion.Right));
                        break;
                    case TipoPieza.Caballero:
                        break;
                    case TipoPieza.Alfil:
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftUp));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftDown));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightDown));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightUp));
                        break;
                    case TipoPieza.Reina:
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Up));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightUp));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Right));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightDown));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Down));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftDown));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Left));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftUp));
                        break;
                    case TipoPieza.Rey:
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Up,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightUp,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Right,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.RightDown,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Down,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftDown,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.Left,1));
                        returnList.AddRange(RangeCheck(casilla, casilla, Direccion.LeftUp,1));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return returnList;
            }

            private IEnumerable<Casilla> RangeCheck(Casilla casillaOrigen,Casilla nextCasilla, Direccion direccion,int maximumRange = 9)
            {
                var returnList = new List<Casilla>();
                if (maximumRange == 0) return returnList;
                nextCasilla = NextCasilla(casillaOrigen, nextCasilla,direccion);
                if (nextCasilla == null) return returnList;
                returnList.Add(nextCasilla);
                maximumRange--;
                if(nextCasilla.PiezaContenida != null)
                    returnList.AddRange(RangeCheck(casillaOrigen,nextCasilla,direccion,maximumRange));
                return returnList;
            }

            private Casilla NextCasilla(Casilla casillaOrigen, Casilla nextCasilla, Direccion direccion)
            {
                var filaOffset = FilaOffset(direccion);
                var columnaOffset = ColumnaOffset(direccion);

                return _casillas.First(casilla1 => casilla1.Fila == nextCasilla.Fila + filaOffset 
                    && casilla1.Columna == nextCasilla.Columna + columnaOffset
                    && casilla1.PiezaContenida.Color != casillaOrigen.PiezaContenida.Color);
            }

            private static int FilaOffset(Direccion direccion)
            {
                int filaOffset = 0;
                switch (direccion)
                {
                    case Direccion.LeftUp:
                    case Direccion.RightUp:
                    case Direccion.Up:
                        filaOffset = 1;
                        break;
                    case Direccion.RightDown:
                    case Direccion.LeftDown:
                    case Direccion.Down:
                        filaOffset = -1;
                        break;
                }
                return filaOffset;
            }

            private static int ColumnaOffset(Direccion direccion)
            {
                int columnaOffset = 0;
                switch (direccion)
                {
                    case Direccion.Left:
                    case Direccion.LeftUp:
                    case Direccion.LeftDown:
                        columnaOffset = 1;
                        break;
                    case Direccion.Right:
                    case Direccion.RightDown:
                    case Direccion.RightUp:
                        columnaOffset = -1;
                        break;
                }
                return columnaOffset;
            }


            private bool DeadLock(Pieza pieza)
            {
                //ver cuantas opciones retorna 
                return false;
            }
        }
    }
