using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Services
{
    public interface ICheckoutService
    {
        Task<int> CheckoutAsync(int cartId, int userId);
    }
}
