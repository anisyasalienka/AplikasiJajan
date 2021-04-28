using System;
using System.Collections.Generic;

namespace AplikasiJajan
{
    public abstract class Drink
    {
        public int price {get; set;}

        public List<Topping> topping;
        public List<DrinkFlavor> drinkFlavor;

        public Drink()
        {
            this.price = 10000;
            this.topping = new List<Topping>();
            this.drinkFlavor = new List<DrinkFlavor>();
        }

        public int CalculateDrinkPrice()
        {
          int totalPrice = this.price;

          foreach(var t in this.topping)
          {
              totalPrice += t.price;
          }
          foreach(var d in this.drinkFlavor)
          {
              totalPrice += d.price;
          }
            return totalPrice;
        }

        public void AddDrink(DrinkFlavor d)
        {
            this.drinkFlavor.Add(d);
        }

        public void AddTopping(Topping t)
        {
            this.topping.Add(t);
        }

        public string GetDrink()
        {
           string infoDrink = string.Empty; 
           foreach(DrinkFlavor df in this.drinkFlavor)
           {
               infoDrink += df.Info();
           }
           return infoDrink;
        }

        public string GetTopping()
        {
            string infoTopping =string.Empty;
            foreach(Topping df in this.topping)
           {
               infoTopping += df.Info();
           }
           return infoTopping;
        }

       public string OrderInfo()
       {
           string info = "\tNota Pesanan\n";
           info += "Rincian\t\tHarga\n";
           info += $"{this.ToString()}\t{this.price}\n";

           info += this.GetDrink();

           info += this.GetTopping();
           info += "------------------------------ +\n";

           info += $"total\t{this.CalculateDrinkPrice()}\n";
           return info;
       }


    }
}
