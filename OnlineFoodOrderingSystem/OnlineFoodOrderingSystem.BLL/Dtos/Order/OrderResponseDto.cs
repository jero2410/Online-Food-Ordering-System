using OnlineFoodOrderingSystem.BLL.Dtos.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Dtos.Order
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public List<OrderItemResponseDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
