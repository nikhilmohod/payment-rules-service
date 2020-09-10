using Newtonsoft.Json;
using ProductPurchesPolicy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductPurchesPolicy.Service
{
    public class ProductInformation
    {

        /// <summary>
        /// Get all product list with there policy
        /// </summary>
        public async Task<List<ProductModel>> GetProductList()
        {
            try
            {
                // Read json file 
                var jsonResult = GetJsonString("ProductList");

                // Deserialize json object response
                var productsListData = JsonConvert.DeserializeObject<ProductsModel>(jsonResult);

                return await Task.FromResult(productsListData.ProductList);
            }
            catch (Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        #region Private Methods

        //Get json srting fron json file
        private string GetJsonString(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePrth = $"ProductPurchesPolicy.{path}.json";
            using (Stream read = assembly.GetManifestResourceStream(resourcePrth))
            using (StreamReader reader = new StreamReader(read))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion
    }
}
