using OnlineFoodOrderingSystem.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class Order : BaseEntities.BaseEntity
    {
        public List<OrderItem> OrderItems { get; set; } 
        public OrderStatus Status { get; set; }
    }
}
