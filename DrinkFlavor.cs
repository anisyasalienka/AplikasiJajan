using System;
using System.Collections.Generic;

namespace AplikasiJajan
{
    public enum Flavor { Milktea, Thaitea, Matcha}
    
    public class DrinkFlavor : IMenu
    {
        public Flavor flavor;
        public int price { get; set; }
        public string name
        {
            get { return this.flavor.ToString(); }
        }

        public DrinkFlavor() : this(Flavor.Milktea)
        {
            //Default rasa Milktea
        }
        public DrinkFlavor(Flavor f)
        {
            this.price = 3000;
            this.flavor = f;
        }

        public string Info()
        {
            return $"{this.flavor}\t{this.price}\n";
        }
    }
}
