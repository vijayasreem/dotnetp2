using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2
{
    public class LoanApprovalModelRepository : ILoanApprovalModelService
    {
        private readonly string _connectionString;

        public LoanApprovalModelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO LoanApprovalModel (Identification, ProofOfIncome, CreditHistory, EmploymentDetails, LoanAmount, InterestRate, VehicleValue, LoanAccepted, LoanDisbursed) " +
                               "VALUES (@Identification, @ProofOfIncome, @CreditHistory, @EmploymentDetails, @LoanAmount, @InterestRate, @VehicleValue, @LoanAccepted, @LoanDisbursed); " +
                               "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Identification", loanApprovalModel.Identification);
                command.Parameters.AddWithValue("@ProofOfIncome", loanApprovalModel.ProofOfIncome);
                command.Parameters.AddWithValue("@CreditHistory", loanApprovalModel.CreditHistory);
                command.Parameters.AddWithValue("@EmploymentDetails", loanApprovalModel.EmploymentDetails);
                command.Parameters.AddWithValue("@LoanAmount", loanApprovalModel.LoanAmount);
                command.Parameters.AddWithValue("@InterestRate", loanApprovalModel.InterestRate);
                command.Parameters.AddWithValue("@VehicleValue", loanApprovalModel.VehicleValue);
                command.Parameters.AddWithValue("@LoanAccepted", loanApprovalModel.LoanAccepted);
                command.Parameters.AddWithValue("@LoanDisbursed", loanApprovalModel.LoanDisbursed);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<LoanApprovalModel> GetLoanApprovalModelAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM LoanApprovalModel WHERE Id = @Id;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new LoanApprovalModel
                    {
                        Id = (int)reader["Id"],
                        Identification = (string)reader["Identification"],
                        ProofOfIncome = (string)reader["ProofOfIncome"],
                        CreditHistory = (string)reader["CreditHistory"],
                        EmploymentDetails = (string)reader["EmploymentDetails"],
                        LoanAmount = (decimal)reader["LoanAmount"],
                        InterestRate = (decimal)reader["InterestRate"],
                        VehicleValue = (decimal)reader["VehicleValue"],
                        LoanAccepted = (bool)reader["LoanAccepted"],
                        LoanDisbursed = (bool)reader["LoanDisbursed"]
                    };
                }
                return null;
            }
        }

        public async Task<List<LoanApprovalModel>> GetAllLoanApprovalModelsAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM LoanApprovalModel;";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<LoanApprovalModel> loanApprovalModels = new List<LoanApprovalModel>();
                while (await reader.ReadAsync())
                {
                    loanApprovalModels.Add(new LoanApprovalModel
                    {
                        Id = (int)reader["Id"],
                        Identification = (string)reader["Identification"],
                        ProofOfIncome = (string)reader["ProofOfIncome"],
                        CreditHistory = (string)reader["CreditHistory"],
                        EmploymentDetails = (string)reader["EmploymentDetails"],
                        LoanAmount = (decimal)reader["LoanAmount"],
                        InterestRate = (decimal)reader["InterestRate"],
                        VehicleValue = (decimal)reader["VehicleValue"],
                        LoanAccepted = (bool)reader["LoanAccepted"],
                        LoanDisbursed = (bool)reader["LoanDisbursed"]
                    });
                }
                return loanApprovalModels;
            }
        }

        public async Task UpdateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE LoanApprovalModel SET Identification = @Identification, ProofOfIncome = @ProofOfIncome, CreditHistory = @CreditHistory, " +
                               "EmploymentDetails = @EmploymentDetails, LoanAmount = @LoanAmount, InterestRate = @InterestRate, VehicleValue = @VehicleValue, " +
                               "LoanAccepted = @LoanAccepted, LoanDisbursed = @LoanDisbursed WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", loanApprovalModel.Id);
                command.Parameters.AddWithValue("@Identification", loanApprovalModel.Identification);
                command.Parameters.AddWithValue("@ProofOfIncome", loanApprovalModel.ProofOfIncome);
                command.Parameters.AddWithValue("@CreditHistory", loanApprovalModel.CreditHistory);
                command.Parameters.AddWithValue("@EmploymentDetails", loanApprovalModel.EmploymentDetails);
                command.Parameters.AddWithValue("@LoanAmount", loanApprovalModel.LoanAmount);
                command.Parameters.AddWithValue("@InterestRate", loanApprovalModel.InterestRate);
                command.Parameters.AddWithValue("@VehicleValue", loanApprovalModel.VehicleValue);
                command.Parameters.AddWithValue("@LoanAccepted", loanApprovalModel.LoanAccepted);
                command.Parameters.AddWithValue("@LoanDisbursed", loanApprovalModel.LoanDisbursed);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteLoanApprovalModelAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM LoanApprovalModel WHERE Id = @Id;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}