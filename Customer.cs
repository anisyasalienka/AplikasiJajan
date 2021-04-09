using System.Globalization;
using System;
using System.Collections.Generic;

namespace AplikasiJajan
{
    class Customer
    {
        private static int StartingId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string DrinkName { get; set; }

        public Customer()
        {
            this.Id = GetId();
        }

        private static int GetId()
        {
            return StartingId++;
        }
    }
}