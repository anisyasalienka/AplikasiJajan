using System;
using System.Collections.Generic;


namespace AplikasiJajan
{
    class MenuScreen
    {
        public static void ShowMenu1()
        {
                Console.WriteLine(" Selamat Datang... ");
                Console.WriteLine("1. Tambah pesanan Customer");
                Console.WriteLine("2. Tampilkan seluruh pesanan Customer");
                Console.WriteLine("3. Tampilkan pesanan yang sedang dipersiapkan");
                Console.WriteLine("4. Kurangi pesanan yang sudah selesai");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your option:");
        }

        public static void ShowMenu2()
        {
            Console.WriteLine(" --------------------------------List Menu JajanBoba-------------------------------- ");
            Console.WriteLine("|         Big Size          |       Regular Size        |         Small Size        |");
            Console.WriteLine("| 1. Milktea with Pearl     | 4. Milktea with Pearl     | 7. Milktea with Pearl     |");
            Console.WriteLine("| 2. Thaitea with Pudding   | 5. Thaitea with Pudding   | 8. Thaitea with Pudding   |");
            Console.WriteLine("| 3. Matcha with Grass Jelly| 6. Matcha with Grass Jelly| 9. Matcha with Grass Jelly|");
            Console.WriteLine("\n Masukkan pesanan Customer dengan memasukkan angka : ");
        }
        public string Excecute1()
        {
            string drinkName = "";
            ShowMenu2();
            var opt1 = Console.ReadLine();
    
            switch(opt1)
            {
                case "1":
                    BigSize cup1 = new BigSize();
                    cup1.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup1.AddTopping(new Pearl());
                    Console.WriteLine(cup1.Info());
                    drinkName = "Milktea with Pearl";
                    break;
                case "2":
                    BigSize cup2 = new BigSize();
                    cup2.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup2.AddTopping(new Pudding());
                    Console.WriteLine(cup2.Info());
                    drinkName = "Thaitea with Pudding";
                    break;              
                case "3":
                    BigSize cup3 = new BigSize();
                    cup3.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup3.AddTopping(new GrassJelly());
                    Console.WriteLine(cup3.Info());
                    drinkName = "Matcha with Grass Jelly";
                    break;
                case "4":
                    RegularSize cup4 = new RegularSize();
                    cup4.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup4.AddTopping(new Pearl());
                    Console.WriteLine(cup4.Info());
                    drinkName = "Milktea with Pearl";
                    break;
                case "5":
                    RegularSize cup5 = new RegularSize();
                    cup5.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup5.AddTopping(new Pudding());
                    Console.WriteLine(cup5.Info());
                    drinkName = "Thaitea with Pudding";
                    break;
                case "6":
                    RegularSize cup6 = new RegularSize();
                    cup6.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup6.AddTopping(new GrassJelly());
                    Console.WriteLine(cup6.Info());
                    drinkName = "Matcha with Grass Jelly";                    
                    break;

                case "7":
                    SmallSize cup7 = new SmallSize();
                    cup7.AddDrink(new DrinkFlavor(Flavor.Milktea));
                    cup7.AddTopping(new Pearl());
                    Console.WriteLine(cup7.Info());
                    drinkName = "Milktea with Pearl";
                    break;

                case "8":
                    SmallSize cup8 = new SmallSize();
                    cup8.AddDrink(new DrinkFlavor(Flavor.Thaitea));
                    cup8.AddTopping(new Pudding());
                    Console.WriteLine(cup8.Info());
                    drinkName = "Thaitea with Pudding";                    
                    break;
                case "9":
                    SmallSize cup9 = new SmallSize();
                    cup9.AddDrink(new DrinkFlavor(Flavor.Matcha));
                    cup9.AddTopping(new GrassJelly());
                    Console.WriteLine(cup9.Info());
                    drinkName = "Matcha with Grass Jelly";                    
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    drinkName = "0";
                    break;

            }
            return drinkName;
        }
        public void Excecute2()
        {
            var queueCustomer = new Queue<Customer>();
            
            while(true)
            {
                ShowMenu1();

                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        var custOrder = new Customer();
                        Console.Write("Masukan nama Customer:");
                        custOrder.Name = Console.ReadLine();

                        custOrder.DrinkName = Excecute1();
                        if(custOrder.DrinkName == "0")
                        {
                            Console.WriteLine("Gagal memasukkan pesanan Customer.");
                        }
                        else
                        {
                            queueCustomer.Enqueue(custOrder);
                            Console.WriteLine("Pesanan Customer sudah ditambahkan.");
                        }

                        break;
                    case "2":
                        if (queueCustomer.Count > 0)
                        {
                            foreach (var q in queueCustomer)
                            Console.WriteLine($"{q.Name} memesan {q.DrinkName}. Nomor antrian {q.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "3":
                        if (queueCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {queueCustomer.Peek().Name} sedang dipersiapkan.");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "4":
                        if (queueCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {queueCustomer.Peek().Name} sudah selesai.");
                            queueCustomer.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Exiting program now.");
                        System.Environment.Exit(1);

                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }          
                Console.ReadKey();    
                Console.Clear();
            }
        }

    }
}