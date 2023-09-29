
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnetp2.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentVerificationController : ControllerBase
    {
        private readonly IDocumentVerificationService _documentVerificationService;

        public DocumentVerificationController(IDocumentVerificationService documentVerificationService)
        {
            _documentVerificationService = documentVerificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GreetUser()
        {
            // Greet the user with a welcoming message
            return Ok("Welcome to the Document Verification App!");
        }

        [HttpPost("VerifyIdentityAndAddress")]
        public async Task<IActionResult> VerifyIdentityAndAddress([FromBody] VerificationRequestDto requestDto)
        {
            // Verify identity and address using the provided input
            bool isIdentityVerified = await _documentVerificationService.VerifyIdentity(requestDto);
            bool isAddressVerified = await _documentVerificationService.VerifyAddress(requestDto);

            if (isIdentityVerified && isAddressVerified)
            {
                // Display success message if both are verified
                return Ok("Identity and address are verified. You are eligible for banking services.");
            }
            else
            {
                // Display message indicating incomplete verification and ineligibility for banking services
                return BadRequest("Document verification is incomplete. You are not eligible for banking services.");
            }
        }

        [HttpPost("EvaluateLoanEligibility")]
        public async Task<IActionResult> EvaluateLoanEligibility([FromBody] LoanEligibilityRequestDto requestDto)
        {
            // Validate customer's annual income and credit score for loan eligibility
            bool isEligible = await _documentVerificationService.EvaluateLoanEligibility(requestDto);

            if (isEligible)
            {
                // Display congratulatory message indicating eligibility for a loan with a high limit
                return Ok("Congratulations! You are eligible for a loan with a high limit.");
            }
            else
            {
                // Inform the customer about loan eligibility with a moderate limit
                return Ok("You are eligible for a loan with a moderate limit.");
            }
        }

        [HttpPost("DisbursePayment")]
        public async Task<IActionResult> DisbursePayment([FromBody] PaymentRequestDto requestDto)
        {
            // Determine payment approval based on the payment amount
            bool isPaymentApproved = await _documentVerificationService.ApprovePayment(requestDto);

            if (isPaymentApproved)
            {
                // Verify vendor information and confirm funds availability
                bool isVendorInfoValid = await _documentVerificationService.VerifyVendorInformation(requestDto);
                bool areFundsAvailable = await _documentVerificationService.CheckFundsAvailability(requestDto);

                if (isVendorInfoValid && areFundsAvailable)
                {
                    // Display successful disbursement message
                    return Ok("Payment disbursement process completed successfully.");
                }
                else if (!isVendorInfoValid)
                {
                    // Display invalid vendor information message
                    return BadRequest("Invalid vendor information. Payment disbursement failed.");
                }
                else
                {
                    // Display insufficient funds message
                    return BadRequest("Insufficient funds. Payment disbursement failed.");
                }
            }
            else
            {
                // Prompt for payment approval
                return Ok("Payment approval is required. Please provide approval.");
            }
        }
    }
}
