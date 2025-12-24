using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Models
{
    public class Category : BaseEntities.BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public List<FoodItem> FoodItems { get; set; }
    }
}
