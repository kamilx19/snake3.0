using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Snake
{
   /// <summary>
   /// Ustawienia gry
   /// </summary>
    
   
    public enum Kierunek {
        Gora,
        Dol,
        Lewo,
        Prawo
    };
        /// <summary>
        /// klasa zawiera ustawienia gry
         /// </summary>
        /// <param name="Kierunek">Kierunek ruchu.</param>
        /// <param name="Szybkosc">Szybkosc węża.</param>
        /// </summary>

    class Ustawienia
    {
      
        public static int Szerokosc { get; set; }
        public static int Wysokosc { get; set; }
        public static int Szybkosc { get; set; }
        public static int Wynik { get; set; }
        public static int Punkty { get; set; }
        public static bool KoniecGry { get; set; }
        public static Kierunek kierunek { get; set; }

        /// <summary>
        /// Bieżące ustawienia
        /// </summary>
        public Ustawienia()
        {

            Szerokosc = 16;
            Wysokosc = 16;
            Szybkosc = 16;
            Wynik = 0;
            Punkty = 1;
            KoniecGry = false;
            kierunek = Kierunek.Dol;
        }
    }
}
