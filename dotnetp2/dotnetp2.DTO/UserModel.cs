namespace dotnetp2
{
    public class UserModel
    {
        public int Id { get; set; }
        
        public string CreditCardNumber { get; set; }
        
        public string CVVCode { get; set; }
        
        public string IssuerIdentificationNumber { get; set; }
        
        public decimal AmountInMalaysianRinggit { get; set; }
        
        public decimal AmountInUSD { get; set; }
        
        public decimal AmountInSGD { get; set; }
        
        public string Browser { get; set; }
        
        public string Token { get; set; }
        
        public string BillingAddress { get; set; }
        
        public DateTime ExpirationDate { get; set; }
        
        public decimal TransactionLimit { get; set; }
        
        public bool IsTransactionValid { get; set; }
        
        public string PaymentConfirmationMessage { get; set; }
        
        public string ErrorMessage { get; set; }
        
        public bool IsPaymentDetailsValid { get; set; }
        
        public bool IsSecurityAuditPassed { get; set; }
        
        public bool IsDataBreach { get; set; }
        
        public string BreachNotificationProtocol { get; set; }
    }
}