using System;
using MySql.Data.MySqlClient;


namespace AplikasiJajan
{
    
    class Login
    {
        public string Username{ get; set; }
        public string Password{ get; set; }

        public void login()
        {
            Connect conn = new Connect();
            using(conn.Connection)
            {
                conn.Connection.Open();
                Console.WriteLine("Lakukan login!");
                Console.WriteLine("Masukkan Username : ");
                Username = Console.ReadLine();
                Console.WriteLine("Masukkan Password : ");
                Password = Console.ReadLine();

                MySqlCommand command = conn.Connection.CreateCommand();
                command.CommandText = System.Data.CommandType.Text.ToString();
                command.CommandText = "Select * from tb_login where username = '"+Username+"' and password = '"+Password+"'";
                MySqlDataReader check = command.ExecuteReader();
                if(check.HasRows)
                {
                    Console.Clear();
                    Console.WriteLine("Login berhasil");
                    conn.Connection.Close();
                    MenuUserInterface menu = new MenuUserInterface();
                    menu.OptionExe2();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Login gagal");
                    conn.Connection.Close();
                    Login login1 = new Login();
                    login1.login();
                }
            }

        }

    }
}
