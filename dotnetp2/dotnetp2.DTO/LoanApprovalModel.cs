namespace dotnetp2
{
    public class LoanApprovalModel
    {
        public int Id { get; set; }
        
        public string Identification { get; set; }
        
        public string ProofOfIncome { get; set; }
        
        public string CreditHistory { get; set; }
        
        public string EmploymentDetails { get; set; }
        
        public decimal LoanAmount { get; set; }
        
        public decimal InterestRate { get; set; }
        
        public decimal VehicleValue { get; set; }
        
        public bool LoanAccepted { get; set; }
        
        public bool LoanDisbursed { get; set; }
    }
}