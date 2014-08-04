using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.GameObjects;
using PetaTest;

namespace UniteTest
{
    using Print = Console;
    
    [TestFixture]
    public class MyTests
    {
        
        [Test]
        public void PeonTest()
        {
            Print.WriteLine("Test de Seleccion del Peon en C2");
            var board = new Tablero();
            var fila = 2;
            var columna = 3;
            IEnumerable<Casilla> movesPossible = board.SelectPiece(fila,columna);
            foreach (var casilla in movesPossible)
            {
                Assert.IsTrue(casilla.Columna == 3);
                Assert.IsTrue(casilla.Fila == 3||casilla.Fila == 4);
            }
        }
        [Test]
        public void KnightTest()
        {
            Print.WriteLine("Test de Seleccion del Caballero en B1");
            var board = new Tablero();
            var fila = 1;
            var columna = 2;
            
            IEnumerable<Casilla> movesPossible = board.SelectPiece(fila, columna);
            foreach (var casilla in movesPossible)
            {
                Assert.IsTrue(casilla.Fila == 3);
                Assert.IsTrue(casilla.Columna == 1 || casilla.Columna == 3);
            }
        }


    }
}
