using System.Collections.Generic;
using System.Linq;

namespace Ajedrez.GameObjects
{
    public enum ColorFicha { Blanco, Negro };

    public abstract class Pieza
    {
        public int Id { set; get; }
        public int Tipo { set; get; }
        public ColorFicha Color { set; get; }
        public string Abreviacion { set; get; }

        private static int FilaOffset(Direccion direccion)
        {
            var filaOffset = 0;
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
            var columnaOffset = 0;
            switch (direccion)
            {
                case Direccion.LeftDown:
                case Direccion.LeftUp:
                case Direccion.Left:
                    columnaOffset = 1;
                    break;
                case Direccion.RightUp:
                case Direccion.RightDown:
                case Direccion.Right:
                    columnaOffset = -1;
                    break;
            }
            return columnaOffset;
        }

        public abstract List<Casilla> GetMovementRange(Casilla contenedor, List<Casilla> casillas);

        protected Casilla NextCasilla(Casilla origen, Casilla siguiente, Direccion direccion, IEnumerable<Casilla> casillas)
        {
            var filaOffset = FilaOffset(direccion);
            var columnaOffset = ColumnaOffset(direccion);
            return casillas.FirstOrDefault(casilla1 => casilla1.Fila == siguiente.Fila + filaOffset
                                            && casilla1.Columna == siguiente.Columna + columnaOffset
                                            && (casilla1.PiezaContenida == null
                                                || (casilla1.PiezaContenida.Color != origen.PiezaContenida.Color
                                                && (TipoPieza)origen.PiezaContenida.Tipo != TipoPieza.Peon))
                                           );
        }
    }
}
