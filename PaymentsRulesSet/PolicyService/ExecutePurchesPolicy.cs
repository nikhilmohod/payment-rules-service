using System;
using System.Threading.Tasks;

namespace PaymentsPolicys.PolicyService
{
    public class ExecutePurchesPolicy
    {
        /// <summary>
        /// Generate packaging slip for physical product
        /// </summary>
        public async virtual Task GeneratePackingSlip()
        {

            try
            {
                Console.WriteLine("Your Product shiping slip.");
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Generate duplicate packaging slip for royalti department
        /// </summary>
        public async virtual Task GenerateDuplicatePackingSlipRoyaltyDept()
        {

            try
            {
                Console.WriteLine("Yoyr Duplicate packaging slip for royalty department.");
               
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Activated use membership
        /// </summary>
        public async virtual Task ActivateMembership()
        {

            try
            {
                Console.WriteLine("Your Member ship activated.");
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Upgrade user membership
        /// </summary>
        public async virtual Task UpgradeToMembership()
        {

            try
            {
                Console.WriteLine("Your Mebership upgraded.");
              
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Generate activation or upgrade membership mail
        /// </summary>
        public async virtual Task SendActivationOrUpgradeEmail()
        {

            try
            {
                Console.WriteLine("Activation email sent.");
        
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Generate agent commision
        /// </summary>
        public async virtual Task GenerateCommissionToAgent()
        {

            try
            {
                Console.WriteLine("Agent commision generated.");
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

        /// <summary>
        /// Add free aid to user 
        /// </summary>
        public async virtual Task AddFirstAidToPackingSlip()
        {

            try
            {
                Console.WriteLine("Free 'First Aid' added to your package");
            }
            catch (System.Exception ex)
            {

                throw await Task.FromResult(ex);
            }
        }

    }

}
