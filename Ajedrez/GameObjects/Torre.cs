using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.GameObjects
{
    class Torre : Pieza
    {
        public override List<Casilla> GetMovementRange(Casilla contenedor,List<Casilla> casillas)
        {
            var output = new List<Casilla>();
            output.AddRange(GetRangeForDirection(contenedor,contenedor,Direccion.Up,casillas));
            output.AddRange(GetRangeForDirection(contenedor,contenedor,Direccion.Down,casillas));
            output.AddRange(GetRangeForDirection(contenedor,contenedor,Direccion.Left,casillas));
            output.AddRange(GetRangeForDirection(contenedor,contenedor,Direccion.Right,casillas));
            return output;
        }

        private IEnumerable<Casilla> GetRangeForDirection(Casilla origen, Casilla siguiente, Direccion direccion, IEnumerable<Casilla> casillas, int maximumRange = 9)
        {
            var output = new List<Casilla>();
            if (maximumRange == 0) return output;
            siguiente = NextCasilla(origen, siguiente, direccion,casillas);
            return output;
        }

       
    }
}
