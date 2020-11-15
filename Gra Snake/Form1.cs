using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_Snake
{
        /// <summary>
        /// lista elementów reprezentujących węża oraz pojedynczy 
        /// <param name="Waz">element reprezentujacy weza.</param>
        /// <param name="jedzonko">elemnt reprezentujacy jedzenie</param>
        /// </summary>
    public partial class Form1 : Form
    {
        
        private List<Element> Waz = new List<Element>();
        private Element jedzonko = new Element();
        
        /// <summary>
        /// inicjalizacja formularza oraz tworzenie ustawień do gry
        /// </summary>

        public Form1()
        {
       
            InitializeComponent();
            new Ustawienia();
            timerGry.Interval = 1000 / Ustawienia.Szybkosc;
            timerGry.Tick += Odswiez;
            timerGry.Start();

            StartGry();
        }
        /// <summary>
        /// Rozpoczęcie gry
        /// </summary>

        private void StartGry()
        {
            koniecGryTekst.Visible = false;
            new Ustawienia();

            Waz.Clear();
            Element glowa = new Element();
            glowa.X = 10;
            glowa.Y = 5;
            Waz.Add(glowa);

            scoreText.Text = Ustawienia.Wynik.ToString();
            UtworzJedzonko();
        }
        /// <summary>
        /// metoda, która generuje randomowo na polu gry jedzenie dla węża
        /// </summary>
        private void UtworzJedzonko()
        {
            int maxX = snakeCanvas.Size.Width / Ustawienia.Szerokosc;
            int maxY = snakeCanvas.Size.Height / Ustawienia.Wysokosc;

            Random losuj = new Random();
            jedzonko = new Element { X = losuj.Next(0, maxX), Y = losuj.Next(0, maxY) };
            

        }

        private void Odswiez(object sender,EventArgs e)
        {
            if (Ustawienia.KoniecGry)
            {
                if (Odczyt.CzyWcisniety(Keys.Enter))
                {
                    StartGry();
                }
            }
            else
            {
                if (Odczyt.CzyWcisniety(Keys.Right) && Ustawienia.kierunek != Kierunek.Lewo)
                    Ustawienia.kierunek = Kierunek.Prawo;
                else if (Odczyt.CzyWcisniety(Keys.Left) && Ustawienia.kierunek != Kierunek.Prawo)
                    Ustawienia.kierunek = Kierunek.Lewo;
                else if (Odczyt.CzyWcisniety(Keys.Up) && Ustawienia.kierunek != Kierunek.Dol)
                    Ustawienia.kierunek = Kierunek.Gora;
                else if (Odczyt.CzyWcisniety(Keys.Down) && Ustawienia.kierunek != Kierunek.Gora)
                    Ustawienia.kierunek = Kierunek.Dol;

                PrzesunGracza();
            }

            snakeCanvas.Invalidate();
        }

        private void snakeCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (!Ustawienia.KoniecGry)
            {
                for (int i = 0; i < Waz.Count; i++)
                {
                    Brush kolorWeza;
                    if (i == 0) kolorWeza = Brushes.Black;
                    else kolorWeza = Brushes.Green;
                    canvas.FillEllipse(kolorWeza, new Rectangle(Waz[i].X * Ustawienia.Szerokosc, Waz[i].Y * Ustawienia.Wysokosc, Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                    canvas.FillEllipse(Brushes.Red, new Rectangle(jedzonko.X * Ustawienia.Szerokosc, jedzonko.Y * Ustawienia.Wysokosc, Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                }
            }
            else
            {
                String koniecGry = "Koniec gry\nTwój wynik to: " + Ustawienia.Wynik + "\nWciśnij enter aby spróbować ponownie";
                koniecGryTekst.Text = koniecGry;
                koniecGryTekst.Visible = true;
            }
        }

        private void PrzesunGracza()
        {
            for (int i=Waz.Count-1;i>=0;i--)
            {
                if (i == 0)
                {
                    switch (Ustawienia.kierunek)
                    {
                        case Kierunek.Prawo:
                            Waz[i].X++;
                            break;
                        case Kierunek.Lewo:
                            Waz[i].X--;
                            break;
                        case Kierunek.Gora:
                            Waz[i].Y--;
                            break;
                        case Kierunek.Dol:
                            Waz[i].Y++;
                            break;
                    }

                    int maxX = snakeCanvas.Size.Width / Ustawienia.Szerokosc;
                    int maxY = snakeCanvas.Size.Height / Ustawienia.Wysokosc;
                    ///<summary>
                    ///kolizja ze scianami
                    ///</summary>
                    if (Waz[i].X<0||Waz[i].Y<0 || Waz[i].X>=maxX ||Waz[i].Y>=maxY)
                    {
                        Gin();
                    }
                     /// <summary>
                    ///kolizja ze swoim cialem
                    /// </summary>
                    for (int j=1;j<Waz.Count;j++)
                    {
                        if(Waz[i].X == Waz[j].X && Waz[i].Y == Waz[j].Y)
                        {
                            Gin();
                        }
                    }
                     /// <summary>
                    ///kolizja z jedzeniem
                    /// </summary>
                    if (Waz[0].X==jedzonko.X && Waz[0].Y==jedzonko.Y)
                    {
                        Jedz();
                    }

                }
                else
                {
                    Waz[i].X = Waz[i - 1].X;
                    Waz[i].Y = Waz[i - 1].Y;
                }
            }
               
        }

        
        private void Jedz()
        {
            Element element = new Element { X = Waz[Waz.Count - 1].X, Y = Waz[Waz.Count - 1].Y };
            Waz.Add(element);

            Ustawienia.Wynik += Ustawienia.Punkty;
            scoreText.Text = Ustawienia.Wynik.ToString();
            UtworzJedzonko();
        }

        private void Gin()
        {
            Ustawienia.KoniecGry = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Odczyt.ZmienStatus(e.KeyCode,true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Odczyt.ZmienStatus(e.KeyCode, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
