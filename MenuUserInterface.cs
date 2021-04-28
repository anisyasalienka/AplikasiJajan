using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace AplikasiJajan
{
    class MenuUserInterface
    {
        public static void MainMenu()
        {
                Console.WriteLine("\tMain Menu");
                Console.WriteLine("1. Tambah pesanan pelanggan");
                Console.WriteLine("2. Tampilkan seluruh list pesanan");
                Console.WriteLine("3. Tampilkan pesanan yang sedang dipersiapkan");
                Console.WriteLine("4. Kurangi pesanan yang telah disajikan");
                Console.WriteLine("5. Log Out");
                Console.Write("Masukkan pilihan :");
        }

        public static void DrinkMenu()
        {
            Connect conn = new Connect();
            using(conn.Connection)
            {
                try
                {
                    conn.Connection.Open();

                    MySqlCommand command = conn.Connection.CreateCommand();
                    command.CommandText = System.Data.CommandType.Text.ToString();
                    command.CommandText = "Select * from tb_menu";

                    MySqlDataReader reader = command.ExecuteReader();

                    var data = "\tMenu Minuman\nNo\tNama Minuman\t\tUkuran";

                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            data +=  Environment.NewLine + reader.GetInt32(0) + " |\t" + reader.GetString(1) + "\t| " 
                            + reader.GetString(2) ;                         
                        }
                    }
                    Console.WriteLine(data);

                    conn.Connection.Close();
                    Console.WriteLine("Masukkan minuman pilihan Customer : ");
                }
                catch(MySql.Data.MySqlClient.MySqlException ex)
                {
                    System.Console.WriteLine("Error!" + ex.Message.ToString());
                }

            }

        }
        public string OptionExe()
        {
            string drinkOrder = "";
            DrinkMenu();
            var option = Console.ReadLine();
    
            switch(option)
            {
                case "1":
                    BigSize cup1 = new BigSize();
                    cup1.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup1.AddTopping(new Pearl());
                    Console.WriteLine(cup1.OrderInfo());
                    drinkOrder = "Milktea with Pearl";
                    break;
                case "2":
                    BigSize cup2 = new BigSize();
                    cup2.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup2.AddTopping(new Pudding());
                    Console.WriteLine(cup2.OrderInfo());
                    drinkOrder = "Thaitea with Pudding";
                    break;              
                case "3":
                    BigSize cup3 = new BigSize();
                    cup3.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup3.AddTopping(new GrassJelly());
                    Console.WriteLine(cup3.OrderInfo());
                    drinkOrder = "Matcha with Grass Jelly";
                    break;
                case "4":
                    RegularSize cup4 = new RegularSize();
                    cup4.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup4.AddTopping(new Pearl());
                    Console.WriteLine(cup4.OrderInfo());
                    drinkOrder = "Milktea with Pearl";
                    break;
                case "5":
                    RegularSize cup5 = new RegularSize();
                    cup5.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup5.AddTopping(new Pudding());
                    Console.WriteLine(cup5.OrderInfo());
                    drinkOrder = "Thaitea with Pudding";
                    break;
                case "6":
                    RegularSize cup6 = new RegularSize();
                    cup6.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup6.AddTopping(new GrassJelly());
                    Console.WriteLine(cup6.OrderInfo());
                    drinkOrder = "Matcha with Grass Jelly";                    
                    break;

                case "7":
                    SmallSize cup7 = new SmallSize();
                    cup7.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup7.AddTopping(new Pearl());
                    Console.WriteLine(cup7.OrderInfo());
                    drinkOrder = "Milktea with Pearl";
                    break;

                case "8":
                    SmallSize cup8 = new SmallSize();
                    cup8.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup8.AddTopping(new Pudding());
                    Console.WriteLine(cup8.OrderInfo());
                    drinkOrder = "Thaitea with Pudding";                    
                    break;
                case "9":
                    SmallSize cup9 = new SmallSize();
                    cup9.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup9.AddTopping(new GrassJelly());
                    Console.WriteLine(cup9.OrderInfo());
                    drinkOrder = "Matcha with Grass Jelly";                    
                    break;
                default:
                    Console.WriteLine("Pilihan tidak tersedia");
                    drinkOrder = "0";
                    break;

            }
            return drinkOrder;
        }
        public void OptionExe2()
        {
            var qCustomer = new Queue<Customer>();
            
            while(true)
            {
                MainMenu();

                var option2 = Console.ReadLine();

                switch (option2)
                {
                    case "1":
                        var customerOrder = new Customer();
                        Console.Write("Masukan nama pelanggan :");
                        customerOrder.Name = Console.ReadLine();
                        customerOrder.DrinkOrder = OptionExe();
                        if(customerOrder.DrinkOrder == "0")
                        {
                            Console.WriteLine("Pesanan gagal ditambahkan");

                        }
                        else
                        {
                            qCustomer.Enqueue(customerOrder);
                            Console.WriteLine("Pesanan pelanggan berhasil ditambahkan");
                        }

                        break;
                    case "2":
                        if (qCustomer.Count > 0)
                        {
                            foreach (var q in qCustomer)
                            Console.WriteLine($"Pesanan minuman {q.DrinkOrder} atas nama {q.Name}, nomor antrian  {q.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada pesanan yang masuk");
                        }
                        break;
                    case "3":
                        if (qCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {qCustomer.Peek().Name} sedang dipersiapkan sekarang");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada pesanan yang masuk");
                        }
                        break;
                    case "4":
                        if (qCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {qCustomer.Peek().Name} telah disajikan");
                            qCustomer.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada pesanan yang masuk");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Log Out dari Akun");
                        System.Environment.Exit(1);

                        break;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia");
                        break;
                }          
                Console.ReadKey();    
                Console.Clear();
            }
        }

    }
}