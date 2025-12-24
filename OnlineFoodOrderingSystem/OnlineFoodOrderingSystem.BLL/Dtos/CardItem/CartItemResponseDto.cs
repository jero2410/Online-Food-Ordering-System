using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Dtos.CardItem
{
    public class CartItemResponseDto
    {
        public int CartItemId { get; set; }
        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
