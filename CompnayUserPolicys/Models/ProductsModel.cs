using System.Collections.Generic;

namespace ProductPurchesPolicy.Models
{

    public class ProductsModel
    {
        public List<ProductModel> ProductList { get; set; }
    }

    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProducName { get; set; }

        public List<int> RulesCategoryId { get; set; }

    }

}
