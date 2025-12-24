using OnlineFoodOrderingSystem.BLL.Dtos.CardItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Dtos.Cart
{
    public class CartResponseDto
    {
        public int CartId { get; set; }
        public List<CartItemResponseDto> Items { get; set; }
        public decimal Total { get; set; }
    }

}
