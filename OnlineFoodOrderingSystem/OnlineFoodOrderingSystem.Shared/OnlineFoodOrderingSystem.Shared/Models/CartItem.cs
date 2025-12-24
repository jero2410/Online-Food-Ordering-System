using OnlineFoodOrderingSystem.Shared.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class CartItem : BaseEntity
    {
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
