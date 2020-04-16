using System;

namespace PaymentCreditCard
{
    public class Purchase
    {
        public Purchase()
        {
            AuthorizatonCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        }

        public string AuthorizatonCode
        {
            get;
            private set;
        }
        public string PurchaseId { get; set; }
        public decimal Amount { get; set; }
    }
}
