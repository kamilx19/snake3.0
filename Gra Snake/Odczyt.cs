using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_Snake
       
{
        /// <summary>
        /// klasa zawiera 2 metody, 1 sprawdza czy przycisk jest wciśnięty a druga jest do zmieniania stanu przycisku
        /// <param name="CzyWcisniety">Czy przycisk jest wciśnięty.</param>
        /// <param name="ZmienStatus">Zmiana statusu.</param>
        /// </summary>
        
    class Odczyt
    {
        
        private static Hashtable tablicaKlawiszy = new Hashtable();
           
           /// <summary>
           /// Sprawdzanie czy przycisk jest wciśnięty
           /// </summary>

        public static bool CzyWcisniety(Keys przycisk)
        {
            if (tablicaKlawiszy[przycisk]==null)
            {
                return false;
            }
            return (bool)tablicaKlawiszy[przycisk];
        }
           
           /// <summary>
           /// zmienianie stanu przycisku
           /// </summary>

        public static void ZmienStatus(Keys przycisk, bool stan)
        {
            tablicaKlawiszy[przycisk] = stan;
        }
    }
}
