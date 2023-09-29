namespace dotnetp2
{
    public class DocumentVerificationModel
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string Address { get; set; }
        public decimal AnnualIncome { get; set; }
        public int CreditScore { get; set; }
        public decimal PaymentAmount { get; set; }
        public string VendorInformation { get; set; }
        public bool PaymentApproval { get; set; }
    }
}