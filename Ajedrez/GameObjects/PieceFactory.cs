using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.GameObjects
{
    class PieceFactory
    {

        public static Pieza MakePiece(TipoPieza tipo, ColorFicha color, int idPieza)
        {
            switch (tipo)
            {
                case TipoPieza.Peon:
                    return new Peon
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int)tipo
                    };
                case TipoPieza.Torre:
                    return new Torre
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int) tipo
                    };
                case TipoPieza.Caballero:
                    return new Caballero
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int)tipo
                    };
                case TipoPieza.Alfil:
                    return new Alfil
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int)tipo
                    };
                case TipoPieza.Reina:
                    return new Reina
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int)tipo
                    };
                case TipoPieza.Rey:
                    return new Rey
                    {
                        Color = color,
                        Id = idPieza,
                        Tipo = (int)tipo
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
