using System;

namespace StoreLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Warehouse
    {
        public int Id { get; set; }
        public decimal Semolina { get; set; } // манная крупа в граммах
        public decimal Butter { get; set; } // сливочное масло в граммах
        public decimal Sugar { get; set; } // сахар в граммах
        public decimal Cocoa { get; set; } // какао-порошок в столовых ложках
        public decimal Water { get; set; } // вода в миллилитрах

        public int CalculatePossibleProducts()
        {
            int possibleBySemolina = (int)(Semolina / 130);
            int possibleByButter = (int)(Butter / 60);
            int possibleBySugar = (int)(Sugar / 60);
            int possibleByCocoa = (int)(Cocoa / 3.5m);
            int possibleByWater = (int)(Water / 180);

            return Math.Min(Math.Min(Math.Min(possibleBySemolina, possibleByButter), Math.Min(possibleBySugar, possibleByCocoa)), possibleByWater) * 6;
        }
    }

    public class Logistics
    {
        public static decimal CalculateLogisticsCost(decimal distance, decimal costPerKm)
        {
            return distance * costPerKm;
        }
    }
}
