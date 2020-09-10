using Newtonsoft.Json;
using PaymentsPolicys.Models;
using PaymentsPolicys.PolicyService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductPurchesPolicy.Service
{
    public class ProceedToPayment : IProceedToPayment
    {

        #region Public Method

        /// <summary>
        /// Execute payment rule for product
        /// </summary>
        /// <param name="policyIds"></param>
        public async Task<string> ExecutePaymentProcess(List<int> policyIds)
        {
            
          var result =   await ProcessRules(policyIds);

            if(result)
            {
                return await ProcessPayment();
            }
            else
            {
                return "Issue in processing rules. Please contact with support.";
            }

        }

        public async Task<string> ProcessPayment()
        {
            return await Task.FromResult("Payment Successfull.");
        }

        /// <summary>
        /// Processing rules
        /// </summary>
        /// <param name="policyIds"></param>
        private async Task<bool> ProcessRules(List<int> policyIds)
        {
            try
            {
                var sr = GetJsonString("PolicyDescription");
                var jsonResp = JsonConvert.DeserializeObject<PolicyModel>(sr);
                var applicableRules = jsonResp.Policys.Where(cond => policyIds.Contains(cond.PolicyId)).ToList();
                var executeRulesSetInstance = new ExecutePurchesPolicy();

                foreach (var rule in applicableRules)
                {
                    // Call method through class object
                    MethodInfo methodInfo = typeof(ExecutePurchesPolicy).GetMethod(rule.PolicyOperation);

                    // Invoke the method on the instance we created above
                    methodInfo.Invoke(executeRulesSetInstance, null);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        #endregion

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
