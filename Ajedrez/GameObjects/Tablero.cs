using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.GameObjects
{

        public class Tablero
        {
            private const int MaxCasillas = 64;
            private const int MaxFichas = 24;
            private const int MaxFilas = 8;
            private const int MaxColumnas = 8;
            private readonly Dictionary<int,string> _filaLetraDictionary = new Dictionary<int, string>
            {
                {1,"A"},{2,"B"},{3,"C"},{4,"D"},{5,"E"},{6,"F"},{7,"G"},{8,"H"}
            };
            private List<Pieza> _piezas;
            private List<Casilla> _casillas;

            public Tablero()
            { 
                _piezas = new List<Pieza>(MaxFichas);
                _casillas = new List<Casilla>(MaxCasillas);

                CrearCasillas();
                LlenarCasillas();
                /*for (var i = 0; i < MaxCasillas; i++)
                {
                    var newCasilla = new Casilla();
                    newCasilla.Columna = tempColumna;
                    newCasilla.Fila = _filaLetraDictionary[tempFila];
                    newCasilla.Color = tempColor;
                    newCasilla.Id = i;
                    _casillas.Add(newCasilla);

                    tempColumna++;

                    if (tempFila <= 3 && tempColor == ColorCasilla.Negro)
                    {
                        var newPieza = new Pieza();
                        Casilla.PiezaContenida = newPieza;
                        newPieza.Id = _piezas.Count;
                        newPieza.Color = ColorFicha.Negro;
                        _piezas.Add(newPieza);
                    }

                    if (tempFila >= 6 && tempColor == ColorCasilla.Negro)
                    {
                        var newFicha = new Ficha();
                        newFicha.CasillaActual = newCasilla;
                        newFicha.ID = _fichas.Count;
                        newFicha.Color = ColorFicha.Blanco;
                        _fichas.Add(newFicha);
                    }

                    if (tempColumna > MaxColumnas)
                    {
                        tempFila += 1;
                        tempColumna = 1;
                    }
                    else
                        tempColor = (tempColor == ColorCasilla.Negro) ? ColorCasilla.Blanco : ColorCasilla.Negro;
                }*/

            }

            private void LlenarCasillas()
            {
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
                                    Fila = _filaLetraDictionary[fila]
                                }
                            );
                        tempColor = tempColor == ColorCasilla.Negro ? ColorCasilla.Blanco : ColorCasilla.Negro;
                    }
                }

            }
            /*
            private bool PermiteMover(int idCasillaAMover, Pieza fichaAMover)
            {
                //Validar que la casilla donde se quiere mover no exceda los limites del tablero
                if (idCasillaAMover < 0 || idCasillaAMover >= MaxCasillas)
                    return false;

                var tempCasilla = ObtenerCasilla(idCasillaAMover);
                if (tempCasilla == null)
                    return false;

                //Valida que la casilla donde se quiere mover sea siempre color NEGRO
                if (tempCasilla.Color == ColorCasilla.Blanco)
                    return false;

                //Valida que la fila a donde se quiere mover, se la que corresponde, segun la ficha.
                if (fichaAMover.Color == ColorFicha.Negro)
                {
                    if (tempCasilla.Fila != fichaAMover.CasillaActual.Fila + 1)
                        return false;
                }
                else
                {
                    if (tempCasilla.Fila != fichaAMover.CasillaActual.Fila - 1)
                        return false;
                }

                var ficha = ObtenerFichaDeCasilla(idCasillaAMover);
                if (ficha == null)
                    return true;

                //Si la ficha que esta en la casilla es del mismo color que la que se quiere mover, no se permite movimiento
                if (ficha.Color == fichaAMover.Color)
                    return false;

                if (ficha.DeadLock)
                    return false;

                return true;
            }

            private Pieza ObtenerFichaDeCasilla(int idCasilla)
            {
                var fichas = _piezas.AsEnumerable().Where(x => x.CasillaActual != null && x.CasillaActual.ID == idCasilla).ToArray();
                if (!fichas.Any())
                    return null;

                //SI una casilla tiene mas de 1 ficha, hay un ERROR
                if (fichas.Any())
                    return fichas.ElementAt(0);

                return null;
            }

            private Casilla ObtenerCasilla(int idCasilla)
            {
                var casilla = _casillas.AsEnumerable().Where(x => x.ID.Equals(idCasilla)).ToArray();
                if (!casilla.Any())
                    return null;

                return casilla[0];
            }

            public string MoverFicha(int idCasillaActual, int idCasillaAMover)
            {
                var fichaActual = ObtenerFichaDeCasilla(idCasillaActual);
                if (fichaActual == null)
                    return "Esta tratando de mover una ficha que no existe";

                if (!PermiteMover(idCasillaAMover, fichaActual))
                    return "Movimiento NO permitido";

                var fichaEnCasilla = ObtenerFichaDeCasilla(idCasillaAMover);
                if (fichaEnCasilla != null)
                    fichaEnCasilla.CasillaActual = null;

                var newCasilla = ObtenerCasilla(idCasillaAMover);
                fichaActual.CasillaActual = newCasilla;

                ActualizarDeadLockFicha(fichaActual);

                return "Movimiento Correcto";
            }

            private string ObtenerNombreCasilla(int Id)
            {
                var id = Id.ToString();
                if (id.Length == 1)
                    id = "0" + id;
                return id;
                //return "C" + id;
            }

            private string ObtenerNombreFicha(Ficha ficha)
            {
                var id = ficha.ID.ToString();
                if (id.Length == 1)
                    id = "0" + id;

                var nombre = (ficha.Color == ColorFicha.Negro) ? "N" : "B";

                return id;
                //return nombre + id;
            }

            public void DibujarTableroConsola()
            {
                var tempFila = 1;
                var tempColumna = 1;

                var delimitadorFila = "";
                for (int i = 0; i < (MaxColumnas * 4); i++)
                {
                    delimitadorFila += "-";
                }

                foreach (var casilla in _casillas)
                {
                    var ficha = ObtenerFichaDeCasilla(casilla.ID);

                    var datoImprimir = "";
                    var IDImprimir = ObtenerNombreCasilla(casilla.ID);

                    if (ficha == null)
                        datoImprimir = "C" + IDImprimir;
                    else
                        datoImprimir = ((ficha.Color == ColorFicha.Negro) ? "N" : "B") + IDImprimir;

                    Console.Write("{0}|", datoImprimir);

                    if (casilla.Columna == MaxColumnas)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(delimitadorFila);
                    }
                }
            }

            private void ActualizarDeadLockFicha(Ficha ficha)
            {
                if (ficha.Color == ColorFicha.Negro && ficha.CasillaActual.Fila == MaxFilas)
                    ficha.DeadLock = true;

                if (ficha.Color == ColorFicha.Blanco && ficha.CasillaActual.Fila == 1)
                    ficha.DeadLock = true;
            }

            public bool DeadLock()
            {
                var fichas = _fichas.AsEnumerable().Where(x => x.DeadLock).ToArray();

                if (!fichas.Any())
                    return false;

                if (fichas.Count() == MaxFichas)
                    return true;

                return false;
            }*/
        }
    }
