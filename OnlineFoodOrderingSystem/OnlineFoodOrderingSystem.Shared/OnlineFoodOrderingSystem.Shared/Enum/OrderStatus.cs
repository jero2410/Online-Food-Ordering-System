using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Shared.Enum
{
    public enum OrderStatus
    {
        Preparing = 1,
        OutForDelivery,
        arrived,
        completed,
        cancelled
    }
}
