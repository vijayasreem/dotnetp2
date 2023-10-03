
namespace dotnetp2
{
    public class LoanApprovalModel
    {
        public int Id { get; set; }
        public string Identification { get; set; } // Valid identification provided by the customer
        public string ProofOfIncome { get; set; } // Proof of income provided by the customer
        public string CreditHistory { get; set; } // Credit history provided by the customer
        public string EmploymentDetails { get; set; } // Employment details provided by the customer
        public bool CreditCheckPassed { get; set; } // Indicates if the credit check is passed by the bank
        public decimal LoanAmount { get; set; } // Pre-qualified loan amount for the applicant
        public decimal InterestRateRange { get; set; } // Range of interest rate for the loan
        public decimal VehicleValue { get; set; } // Value of the vehicle for used vehicle assessment
        public bool LoanOfferAccepted { get; set; } // Indicates if the loan offer is accepted by the applicant
        public bool LoanDisbursed { get; set; } // Indicates if the approved loan amount is disbursed by the bank
    }
}
