using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.GameObjects;

namespace Ajedrez
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.RenderGame();
            Console.ReadLine();
        }
    }


}
