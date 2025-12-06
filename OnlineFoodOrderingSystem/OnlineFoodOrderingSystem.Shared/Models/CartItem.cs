using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class CartItem : BaseEntities.BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
