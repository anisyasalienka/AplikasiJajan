using System;
using System.Collections.Generic;

namespace AplikasiJajan
{
    public class Pudding  : Topping
    {
        public Pudding()
        {
            this.name = "Pudding";
            this.price += 2000;
        }
    }
}