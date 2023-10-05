namespace dotnetp2.Repository
{
    using dotnetp2.DTO;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class ReportDeliveryConfigurationRepository : IReportDeliveryConfigurationRepository
    {
        private readonly string _connectionString;
        public ReportDeliveryConfigurationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Async CRUD Operations
        public async Task<ReportDeliveryConfigurationModel> GetReportDeliveryConfiguration(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);
                var reportDeliveryConfiguration = await conn.QuerySingleAsync<ReportDeliveryConfigurationModel>("GET_REPORT_DELIVERY_CONFIGURATION", param, commandType: CommandType.StoredProcedure);
                return reportDeliveryConfiguration;
            }
        }

        public async Task<IEnumerable<ReportDeliveryConfigurationModel>> GetAllReportDeliveryConfigurations()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var reportDeliveryConfigurations = await conn.QueryAsync<ReportDeliveryConfigurationModel>("GET_ALL_REPORT_DELIVERY_CONFIGURATIONS", commandType: CommandType.StoredProcedure);
                return reportDeliveryConfigurations;
            }
        }

        public async Task<int> CreateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@DestinationType", reportDeliveryConfiguration.DestinationType);
                param.Add("@DestinationAddress", reportDeliveryConfiguration.DestinationAddress);
                param.Add("@DayOfWeek", reportDeliveryConfiguration.DayOfWeek);
                param.Add("@DayOfMonth", reportDeliveryConfiguration.DayOfMonth);
                param.Add("@DeliveryTime", reportDeliveryConfiguration.DeliveryTime);
                var id = await conn.QuerySingleAsync<int>("CREATE_REPORT_DELIVERY_CONFIGURATION", param, commandType: CommandType.StoredProcedure);
                return id;
            }
        }

        public async Task<bool> UpdateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@Id", reportDeliveryConfiguration.Id);
                param.Add("@DestinationType", reportDeliveryConfiguration.DestinationType);
                param.Add("@DestinationAddress", reportDeliveryConfiguration.DestinationAddress);
                param.Add("@DayOfWeek", reportDeliveryConfiguration.DayOfWeek);
                param.Add("@DayOfMonth", reportDeliveryConfiguration.DayOfMonth);
                param.Add("@DeliveryTime", reportDeliveryConfiguration.DeliveryTime);
                var isUpdated = await conn.ExecuteAsync("UPDATE_REPORT_DELIVERY_CONFIGURATION", param, commandType: CommandType.StoredProcedure);
                return isUpdated > 0;
            }
        }

        public async Task<bool> DeleteReportDeliveryConfiguration(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);
                var isDeleted = await conn.ExecuteAsync("DELETE_REPORT_DELIVERY_CONFIGURATION", param, commandType: CommandType.StoredProcedure);
                return isDeleted > 0;
            }
        }
    }
}