using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapUserModelFromReader(reader);
                    }
                }
            }

            return null;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            List<UserModel> users = new List<UserModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(MapUserModelFromReader(reader));
                    }
                }
            }

            return users;
        }

        public async Task<int> CreateAsync(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("INSERT INTO Users (CreditCardNumber, CVVCode, IssuerIdentificationNumber, AmountInMalaysianRinggit, AmountInUSD, AmountInSGD, Browser, Token, BillingAddress, ExpirationDate, TransactionLimit, IsTransactionValid, PaymentConfirmationMessage, ErrorMessage, IsPaymentDetailsValid, IsSecurityAuditPassed, IsDataBreach, BreachNotificationProtocol) " +
                                                    "VALUES (@CreditCardNumber, @CVVCode, @IssuerIdentificationNumber, @AmountInMalaysianRinggit, @AmountInUSD, @AmountInSGD, @Browser, @Token, @BillingAddress, @ExpirationDate, @TransactionLimit, @IsTransactionValid, @PaymentConfirmationMessage, @ErrorMessage, @IsPaymentDetailsValid, @IsSecurityAuditPassed, @IsDataBreach, @BreachNotificationProtocol);" +
                                                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", connection);

                AddUserModelParameters(user, command);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<bool> UpdateAsync(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("UPDATE Users SET CreditCardNumber = @CreditCardNumber, CVVCode = @CVVCode, IssuerIdentificationNumber = @IssuerIdentificationNumber, AmountInMalaysianRinggit = @AmountInMalaysianRinggit, AmountInUSD = @AmountInUSD, AmountInSGD = @AmountInSGD, Browser = @Browser, Token = @Token, BillingAddress = @BillingAddress, ExpirationDate = @ExpirationDate, TransactionLimit = @TransactionLimit, " +
                                                    "IsTransactionValid = @IsTransactionValid, PaymentConfirmationMessage = @PaymentConfirmationMessage, ErrorMessage = @ErrorMessage, IsPaymentDetailsValid = @IsPaymentDetailsValid, IsSecurityAuditPassed = @IsSecurityAuditPassed, IsDataBreach = @IsDataBreach, BreachNotificationProtocol = @BreachNotificationProtocol WHERE Id = @Id", connection);

                AddUserModelParameters(user, command);
                command.Parameters.AddWithValue("@Id", user.Id);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        private UserModel MapUserModelFromReader(SqlDataReader reader)
        {
            return new UserModel
            {
                Id = (int)reader["Id"],
                CreditCardNumber = (string)reader["CreditCardNumber"],
                CVVCode = (string)reader["CVVCode"],
                IssuerIdentificationNumber = (string)reader["IssuerIdentificationNumber"],
                AmountInMalaysianRinggit = (decimal)reader["AmountInMalaysianRinggit"],
                AmountInUSD = (decimal)reader["AmountInUSD"],
                AmountInSGD = (decimal)reader["AmountInSGD"],
                Browser = (string)reader["Browser"],
                Token = (string)reader["Token"],
                BillingAddress = (string)reader["BillingAddress"],
                ExpirationDate = (DateTime)reader["ExpirationDate"],
                TransactionLimit = (decimal)reader["TransactionLimit"],
                IsTransactionValid = (bool)reader["IsTransactionValid"],
                PaymentConfirmationMessage = (string)reader["PaymentConfirmationMessage"],
                ErrorMessage = (string)reader["ErrorMessage"],
                IsPaymentDetailsValid = (bool)reader["IsPaymentDetailsValid"],
                IsSecurityAuditPassed = (bool)reader["IsSecurityAuditPassed"],
                IsDataBreach = (bool)reader["IsDataBreach"],
                BreachNotificationProtocol = (string)reader["BreachNotificationProtocol"]
            };
        }

        private void AddUserModelParameters(UserModel user, SqlCommand command)
        {
            command.Parameters.AddWithValue("@CreditCardNumber", user.CreditCardNumber);
            command.Parameters.AddWithValue("@CVVCode", user.CVVCode);
            command.Parameters.AddWithValue("@IssuerIdentificationNumber", user.IssuerIdentificationNumber);
            command.Parameters.AddWithValue("@AmountInMalaysianRinggit", user.AmountInMalaysianRinggit);
            command.Parameters.AddWithValue("@AmountInUSD", user.AmountInUSD);
            command.Parameters.AddWithValue("@AmountInSGD", user.AmountInSGD);
            command.Parameters.AddWithValue("@Browser", user.Browser);
            command.Parameters.AddWithValue("@Token", user.Token);
            command.Parameters.AddWithValue("@BillingAddress", user.BillingAddress);
            command.Parameters.AddWithValue("@ExpirationDate", user.ExpirationDate);
            command.Parameters.AddWithValue("@TransactionLimit", user.TransactionLimit);
            command.Parameters.AddWithValue("@IsTransactionValid", user.IsTransactionValid);
            command.Parameters.AddWithValue("@PaymentConfirmationMessage", user.PaymentConfirmationMessage);
            command.Parameters.AddWithValue("@ErrorMessage", user.ErrorMessage);
            command.Parameters.AddWithValue("@IsPaymentDetailsValid", user.IsPaymentDetailsValid);
            command.Parameters.AddWithValue("@IsSecurityAuditPassed", user.IsSecurityAuditPassed);
            command.Parameters.AddWithValue("@IsDataBreach", user.IsDataBreach);
            command.Parameters.AddWithValue("@BreachNotificationProtocol", user.BreachNotificationProtocol);
        }
    }
}