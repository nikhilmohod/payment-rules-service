using ProductPurchesPolicy.Models;
using ProductPurchesPolicy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompnayUserPolicys
{
    class Program
    {
        #region Private Members

        private static ProceedToPayment _proceedToPayment;
        private static ProductInformation _productList;

        #endregion

        #region Main Methods
        static async Task Main(string[] args)
        {
            try
            {
                _proceedToPayment = new ProceedToPayment();
                _productList = new ProductInformation();

                var productList = await _productList.GetProductList();

                if (productList.Count > 0)
                {
                    await ProcessProducts(productList);
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        // Process product purches
        private static async Task ProcessProducts(List<ProductModel> productList)
        {
            foreach (var product in productList)
            {
                Console.WriteLine($"{product.ProductId} : {product.ProducName}");
            }

            Console.WriteLine("Enter Product number for purches :");

            await TakeProductInput(productList);

            Console.WriteLine("You want another product ? Y/N");
            var input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                await ProcessProducts(productList);
            }
            else
            {
                Console.WriteLine("Thanks for shopping. Press any key for exit.");

            }


        }

        // Select product
        private static async Task TakeProductInput(List<ProductModel> productList)
        {
            var productId = 0;
            int.TryParse(Console.ReadLine(), out productId);

            if (productId > 0 && productId <= 5)
            {
                var applicatlePolicy = productList.Where(id => id.ProductId.Equals(productId)).FirstOrDefault();
                var result = await _proceedToPayment.ExecutePaymentProcess(applicatlePolicy.RulesCategoryId);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Please enter valid option");

                await TakeProductInput(productList);
            }
        }

        #endregion
    }
}
