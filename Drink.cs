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

        public int CalculatePrice()
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
           string infDrink = string.Empty; 
           foreach(DrinkFlavor df in this.drinkFlavor)
           {
               infDrink += df.Info();
           }
           return infDrink;
        }

        public string GetTopping()
        {
            string infTopping =string.Empty;
            foreach(Topping df in this.topping)
           {
               infTopping += df.Info();
           }
           return infTopping;
        }

       public string Info()
       {
           string info = "Drink Order\n";
           info += "Item\t\tPrice\n";
           info += $"{this.ToString()}\t{this.price}\n";

           info += this.GetDrink();

           info += this.GetTopping();
           info += "-------------------------------\n";

           info += $"total\t{this.CalculatePrice()}\n";
           return info;
       }


    }
}
