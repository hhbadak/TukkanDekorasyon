using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Filament
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string Color { get; set; } 
        public decimal Price { get; set; } 
        public decimal Weight { get; set; } 
        public decimal WeightPrice { get; set; } 
    }
}
