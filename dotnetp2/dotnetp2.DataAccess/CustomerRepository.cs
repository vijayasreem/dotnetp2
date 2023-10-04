using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2
{
    public class CustomerService : ICustomerService
    {
        private readonly string connectionString;

        public CustomerService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("INSERT INTO Customers (Identification, Income, CreditHistory, EmploymentDetails) VALUES (@Identification, @Income, @CreditHistory, @EmploymentDetails); SELECT SCOPE_IDENTITY();", connection);

                command.Parameters.AddWithValue("@Identification", customer.Identification);
                command.Parameters.AddWithValue("@Income", customer.Income);
                command.Parameters.AddWithValue("@CreditHistory", customer.CreditHistory);
                command.Parameters.AddWithValue("@EmploymentDetails", customer.EmploymentDetails);

                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Identification = reader["Identification"].ToString(),
                        Income = Convert.ToDecimal(reader["Income"]),
                        CreditHistory = reader["CreditHistory"].ToString(),
                        EmploymentDetails = reader["EmploymentDetails"].ToString()
                    };
                }

                return null;
            }
        }

        public async Task<List<CustomerModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<CustomerModel> customers = new List<CustomerModel>();

                while (await reader.ReadAsync())
                {
                    customers.Add(new CustomerModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Identification = reader["Identification"].ToString(),
                        Income = Convert.ToDecimal(reader["Income"]),
                        CreditHistory = reader["CreditHistory"].ToString(),
                        EmploymentDetails = reader["EmploymentDetails"].ToString()
                    });
                }

                return customers;
            }
        }

        public async Task<bool> UpdateAsync(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("UPDATE Customers SET Identification = @Identification, Income = @Income, CreditHistory = @CreditHistory, EmploymentDetails = @EmploymentDetails WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", customer.Id);
                command.Parameters.AddWithValue("@Identification", customer.Identification);
                command.Parameters.AddWithValue("@Income", customer.Income);
                command.Parameters.AddWithValue("@CreditHistory", customer.CreditHistory);
                command.Parameters.AddWithValue("@EmploymentDetails", customer.EmploymentDetails);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("DELETE FROM Customers WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
}