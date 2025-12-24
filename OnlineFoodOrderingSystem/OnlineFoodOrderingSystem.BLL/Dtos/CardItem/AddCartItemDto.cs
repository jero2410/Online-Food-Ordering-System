using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Dtos.CardItem
{
    public class AddCartItemDto
    {
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }
    }
}
