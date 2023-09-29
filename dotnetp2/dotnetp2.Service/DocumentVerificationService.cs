using System;
using System.Threading.Tasks;
using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class DocumentVerificationService : IDocumentVerificationService
    {
        private readonly IDocumentVerificationRepository _repository;

        public DocumentVerificationService(IDocumentVerificationRepository repository)
        {
            _repository = repository;
        }

        public async Task DocumentVerificationProcess()
        {
            Console.WriteLine("Welcome to the Document Verification App!");

            // Verify identity and address
            DocumentVerificationModel document = await _repository.GetById(1);
            if (document != null && document.IsIdentityVerified && document.IsAddressVerified)
            {
                Console.WriteLine("Document verification successful!");

                // Validate annual income and credit score
                if (document.AnnualIncome >= 30000 && document.CreditScore >= 700)
                {
                    Console.WriteLine("Congratulations! You are eligible for a loan with a high limit.");
                }
                else if (document.AnnualIncome >= 20000 && document.CreditScore >= 600)
                {
                    Console.WriteLine("You are eligible for a loan with a moderate limit.");
                }
                else
                {
                    Console.WriteLine("You are not eligible for a loan.");
                }

                // Close the app and clean up resources
                CloseApp();
            }
            else
            {
                Console.WriteLine("Document verification incomplete. You are not eligible for banking services.");
            }
        }

        private void CloseApp()
        {
            // Close any resources like the Scanner here
            Console.WriteLine("Closing the Document Verification App...");
        }
    }
}