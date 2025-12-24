using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class OrderItem : BaseEntities.BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
