using System;
using System.Collections.Generic;

namespace AplikasiJajan
{
    class Program
    {

        static void Main(string[] args)
        {   
            Console.WriteLine("\tAplikasi JajanBoba");
            Login login  = new Login();
            login.login();

        }
    }
}
