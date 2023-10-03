using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2
{
    public class LoanApprovalModelRepository : ILoanApprovalModelRepository
    {
        private readonly string _connectionString;

        public LoanApprovalModelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO LoanApprovalModel (Identification, ProofOfIncome, CreditHistory, EmploymentDetails, CreditCheckPassed, LoanAmount, InterestRateRange, VehicleValue, LoanOfferAccepted, LoanDisbursed) " +
                               "VALUES (@Identification, @ProofOfIncome, @CreditHistory, @EmploymentDetails, @CreditCheckPassed, @LoanAmount, @InterestRateRange, @VehicleValue, @LoanOfferAccepted, @LoanDisbursed);" +
                               "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identification", loanApprovalModel.Identification);
                    command.Parameters.AddWithValue("@ProofOfIncome", loanApprovalModel.ProofOfIncome);
                    command.Parameters.AddWithValue("@CreditHistory", loanApprovalModel.CreditHistory);
                    command.Parameters.AddWithValue("@EmploymentDetails", loanApprovalModel.EmploymentDetails);
                    command.Parameters.AddWithValue("@CreditCheckPassed", loanApprovalModel.CreditCheckPassed);
                    command.Parameters.AddWithValue("@LoanAmount", loanApprovalModel.LoanAmount);
                    command.Parameters.AddWithValue("@InterestRateRange", loanApprovalModel.InterestRateRange);
                    command.Parameters.AddWithValue("@VehicleValue", loanApprovalModel.VehicleValue);
                    command.Parameters.AddWithValue("@LoanOfferAccepted", loanApprovalModel.LoanOfferAccepted);
                    command.Parameters.AddWithValue("@LoanDisbursed", loanApprovalModel.LoanDisbursed);

                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<LoanApprovalModel> GetLoanApprovalModel(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM LoanApprovalModel WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapLoanApprovalModel(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<LoanApprovalModel>> GetAllLoanApprovalModels()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM LoanApprovalModel";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<LoanApprovalModel> loanApprovalModels = new List<LoanApprovalModel>();

                        while (await reader.ReadAsync())
                        {
                            loanApprovalModels.Add(MapLoanApprovalModel(reader));
                        }

                        return loanApprovalModels;
                    }
                }
            }
        }

        public async Task UpdateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE LoanApprovalModel SET " +
                               "Identification = @Identification, " +
                               "ProofOfIncome = @ProofOfIncome, " +
                               "CreditHistory = @CreditHistory, " +
                               "EmploymentDetails = @EmploymentDetails, " +
                               "CreditCheckPassed = @CreditCheckPassed, " +
                               "LoanAmount = @LoanAmount, " +
                               "InterestRateRange = @InterestRateRange, " +
                               "VehicleValue = @VehicleValue, " +
                               "LoanOfferAccepted = @LoanOfferAccepted, " +
                               "LoanDisbursed = @LoanDisbursed " +
                               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identification", loanApprovalModel.Identification);
                    command.Parameters.AddWithValue("@ProofOfIncome", loanApprovalModel.ProofOfIncome);
                    command.Parameters.AddWithValue("@CreditHistory", loanApprovalModel.CreditHistory);
                    command.Parameters.AddWithValue("@EmploymentDetails", loanApprovalModel.EmploymentDetails);
                    command.Parameters.AddWithValue("@CreditCheckPassed", loanApprovalModel.CreditCheckPassed);
                    command.Parameters.AddWithValue("@LoanAmount", loanApprovalModel.LoanAmount);
                    command.Parameters.AddWithValue("@InterestRateRange", loanApprovalModel.InterestRateRange);
                    command.Parameters.AddWithValue("@VehicleValue", loanApprovalModel.VehicleValue);
                    command.Parameters.AddWithValue("@LoanOfferAccepted", loanApprovalModel.LoanOfferAccepted);
                    command.Parameters.AddWithValue("@LoanDisbursed", loanApprovalModel.LoanDisbursed);
                    command.Parameters.AddWithValue("@Id", loanApprovalModel.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteLoanApprovalModel(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM LoanApprovalModel WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private LoanApprovalModel MapLoanApprovalModel(SqlDataReader reader)
        {
            return new LoanApprovalModel
            {
                Id = (int)reader["Id"],
                Identification = reader["Identification"].ToString(),
                ProofOfIncome = reader["ProofOfIncome"].ToString(),
                CreditHistory = reader["CreditHistory"].ToString(),
                EmploymentDetails = reader["EmploymentDetails"].ToString(),
                CreditCheckPassed = (bool)reader["CreditCheckPassed"],
                LoanAmount = (decimal)reader["LoanAmount"],
                InterestRateRange = (decimal)reader["InterestRateRange"],
                VehicleValue = (decimal)reader["VehicleValue"],
                LoanOfferAccepted = (bool)reader["LoanOfferAccepted"],
                LoanDisbursed = (bool)reader["LoanDisbursed"]
            };
        }
    }
}