using System;

namespace CaptureCreditCard
{
    public class Purchase
    {
        public Purchase(decimal amount)
        {
            Amount = amount;
            PurchaseId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        }

        public string PurchaseId
        {
            get;
            private set;
        }

        public decimal Amount { get; set; }
    }
}
