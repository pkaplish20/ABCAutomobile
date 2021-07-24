using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCAutomotive.Models
{
    public class Car 
    {
        public string carId { get; set; }

        public string carMake { get; set; }
        public int carType { get; set; }
        public string carModel{get; set; }
        public decimal profit { get; set; }

        public bool isRed { get; set; }
        public bool isConvertible { get; set; }
        public decimal price { get; set; }

        public decimal sellingPrice { get; set; }

    }
}
