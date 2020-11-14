using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
       
namespace Gra_Snake
        
{
         /// <summary>
         /// Główny punkt wejścia dla aplikacji.
         /// </summary>
        
    static class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Application.Run(new Form2());
        }
        
    }
}
