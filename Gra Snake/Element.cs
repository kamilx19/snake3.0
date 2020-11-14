using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Snake
        /// <summary>
        /// klasa tworzy element o podanych współrzędnych x i y
        /// <param name="x">Coordinate X.</param>
        /// <param name="y">Coordinate Y.</param>
        /// </summary>
{
    class Element
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Element()
        {
            X = 0;
            Y = 0;
        }
    }
}
