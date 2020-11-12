using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Gra_Snake
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
#if DEBUG
            unittest1();
            unittest2();
            unittest3();
            unittest4();
            unittest5();
            unittest6();
#else
#endif        
        }
            void unittest1()
        {
            int wynik;
            
            String login;
            String haslo;
            login = "Kamil";
            haslo = "snake";
            bool zwrotfunkcji = zaloguj(login, haslo);
            if (zwrotfunkcji == true)
            {
                wynik = 1;
            }
            else
            {
                wynik = 0;
            }
            MessageBox.Show("Login: "+login + " Haslo:" + haslo);
            wyniki(wynik);  

        }
        void unittest2()
        {
            int wynik;
            String login;
            String haslo;
            login = "Kamfdafil";
            haslo = "hjkh";
            if (zaloguj(login, haslo) == true)
            {
                wynik = 0;
            }
            else
            {
                wynik = 3;
            }
            MessageBox.Show("Login: " + login + " Haslo:" + haslo);
            wyniki(wynik);
        }
        void unittest3()
        {
            int wynik;
            String login;
            String haslo;
            login = "Kamil";
            haslo = "";
            if (zaloguj(login, haslo) == true)
            {
                wynik = 0;
            }
            else
            {
                wynik = 4;
            }
            MessageBox.Show("Login: " + login + " Haslo:" + haslo);
            wyniki(wynik);
        }
        void unittest4()
        {
            int wynik;
            String login;
            String haslo;
            login = "Kamil";
            haslo = "hjkh";
            if (zaloguj(login, haslo) == true)
            {
                wynik = 0;
            }
            else
            {
                wynik = 2;
            }
            MessageBox.Show("Login: " + login + " Haslo:" + haslo);
            wyniki(wynik);
        }
        void unittest5()
        {
            int wynik;
            String login;
            String haslo;
            login = "";
            haslo = "snake";
            if (zaloguj(login, haslo) == true)
            {
                wynik = 0;
            }
            else
            {
                wynik = 4;
            }
            MessageBox.Show("Login: " + login + " Haslo:" + haslo);
            wyniki(wynik);
        }
        void unittest6()
        {
            int wynik;
            String login;
            String haslo;
            login = "";
            haslo = "";
            if (zaloguj(login, haslo) == true)
            {
                wynik = 0;
            }
            else
            {
                wynik = 5;
            }
            MessageBox.Show("Login: " + login + " Haslo:" + haslo);
            wyniki(wynik);
        }
       
        void wyniki(int wynik2)
        {
            switch(wynik2)
            {
                case 0:
                    MessageBox.Show("Test nie wykonał sie poprawnie");
                    break;
                case 1:
                    MessageBox.Show("Podałes dobry login i dobre haslo");
                    break;
                case 2:
                    MessageBox.Show("Podałes złe hasło lub zły login");
                    break;
                case 3:
                    MessageBox.Show("Podałes złe hasło i zły login");
                    break;
                case 4:
                    MessageBox.Show("Podałes pust hasło lub pusty login");
                    break;
                case 5:
                    MessageBox.Show("Podałes puste hasło i pusty login");
                    break;
                
               

            }
          
        }
        void akcjaPoZalogowaniu()
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
        bool zaloguj(String log, String has)
        {
            int uzytkownik_id;
            bool res = false;
            
            MySqlConnection connection;
            string server;
            string database;
           string uid;
         string password;
        server = "localhost";
            database = "snake";
            uid = "root";
            password = "bazydanych";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            try
            {
               
                    string query = "SELECT user_id FROM snake.user WHERE login = '" + log + "' AND password = password('" + has + "');";

                    connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    uzytkownik_id = dataReader.GetInt32("user_id");
                    if (uzytkownik_id > 0)
                    {
                        res = true;
                    }
                }

                    connection.Close();

                
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
            return res;
            }
        private void buttonZaloguj_Click(object sender, EventArgs e)
        {

  

            String login = textLogin.Text;
            String haslo = textPassword.Text;
            bool wynik_logowania = zaloguj(login,haslo);
            if (wynik_logowania == true)
            {
                akcjaPoZalogowaniu();
            }
            else
            {
                MessageBox.Show("Chujowy login lub hasło"); 
            }
            

            
        }
    }
}
