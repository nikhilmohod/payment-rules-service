using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPurchesPolicy.Service
{
    public interface IProceedToPayment
    {
        Task<string> ExecutePaymentProcess(List<int> productId);

        Task<string> ProcessPayment();
    }
}
