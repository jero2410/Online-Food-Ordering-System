using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class Cart : BaseEntities.BaseEntity
    {
        public List<CartItem> CartItems { get; set; } 
        public List<OrderItem> OrderItems { get; set; }
    }
}
