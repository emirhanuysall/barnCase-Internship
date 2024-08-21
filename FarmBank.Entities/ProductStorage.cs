using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarnCase.Entities
{
    public static class ProductStorage
    {
        public static Dictionary<string, int> ProductQuantities { get; set; } = new Dictionary<string, int>
        {
            { "Milk", 0 },
            { "Wool", 0 },
            { "Egg", 0 }
        };

        public static Dictionary<string, int> ProgressBars { get; set; } = new Dictionary<string, int>
        {
            { "Milk", 0 },
            { "Wool", 0 },
            { "Egg", 0 }
        };

        public static int TotalSales { get; set; } = 0;
    }
}

