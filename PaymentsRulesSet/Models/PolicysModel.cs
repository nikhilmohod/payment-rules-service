using System.Collections.Generic;

namespace PaymentsPolicys.Models
{
    public class PolicyModel
    {
        public List<PolicysModel> Policys { get; set; }

    }

    public class PolicysModel
    {
        public int PolicyId { get; set; }

        public string PolicyDescription { get; set; }

        public string PolicyOperation { get; set; }
    }
    
}
