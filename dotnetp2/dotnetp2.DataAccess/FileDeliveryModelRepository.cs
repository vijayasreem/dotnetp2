using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2
{
    public class FileDeliveryModelRepository : IFileDeliveryModelRepository
    {
        private readonly string connectionString;

        public FileDeliveryModelRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<FileDeliveryModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM FileDeliveryModel", connection))
                {
                    List<FileDeliveryModel> fileDeliveryModels = new List<FileDeliveryModel>();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            FileDeliveryModel fileDeliveryModel = new FileDeliveryModel
                            {
                                Id = (int)reader["Id"],
                                DeliveryMethod = (string)reader["DeliveryMethod"],
                                AttachmentFormat = (string)reader["AttachmentFormat"],
                                FTPUrl = (string)reader["FTPUrl"],
                                FTPPassword = (string)reader["FTPPassword"],
                                FTPFilePath = (string)reader["FTPFilePath"],
                                SharepointUrl = (string)reader["SharepointUrl"],
                                SharepointDocumentLibrary = (string)reader["SharepointDocumentLibrary"],
                                DeliverySchedule = (string)reader["DeliverySchedule"],
                                SpecificDay = (string)reader["SpecificDay"],
                                TimeOfDay = (string)reader["TimeOfDay"],
                                SuccessNotificationEmails = (string)reader["SuccessNotificationEmails"],
                                SuccessNotificationSubject = (string)reader["SuccessNotificationSubject"],
                                SuccessNotificationBody = (string)reader["SuccessNotificationBody"]
                            };

                            fileDeliveryModels.Add(fileDeliveryModel);
                        }
                    }

                    return fileDeliveryModels;
                }
            }
        }

        public async Task<FileDeliveryModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM FileDeliveryModel WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            FileDeliveryModel fileDeliveryModel = new FileDeliveryModel
                            {
                                Id = (int)reader["Id"],
                                DeliveryMethod = (string)reader["DeliveryMethod"],
                                AttachmentFormat = (string)reader["AttachmentFormat"],
                                FTPUrl = (string)reader["FTPUrl"],
                                FTPPassword = (string)reader["FTPPassword"],
                                FTPFilePath = (string)reader["FTPFilePath"],
                                SharepointUrl = (string)reader["SharepointUrl"],
                                SharepointDocumentLibrary = (string)reader["SharepointDocumentLibrary"],
                                DeliverySchedule = (string)reader["DeliverySchedule"],
                                SpecificDay = (string)reader["SpecificDay"],
                                TimeOfDay = (string)reader["TimeOfDay"],
                                SuccessNotificationEmails = (string)reader["SuccessNotificationEmails"],
                                SuccessNotificationSubject = (string)reader["SuccessNotificationSubject"],
                                SuccessNotificationBody = (string)reader["SuccessNotificationBody"]
                            };

                            return fileDeliveryModel;
                        }
                    }
                }
            }

            return null;
        }

        public async Task<int> AddAsync(FileDeliveryModel fileDeliveryModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO FileDeliveryModel (DeliveryMethod, AttachmentFormat, FTPUrl, FTPPassword, FTPFilePath, SharepointUrl, 
                                                      SharepointDocumentLibrary, DeliverySchedule, SpecificDay, TimeOfDay, SuccessNotificationEmails,
                                                      SuccessNotificationSubject, SuccessNotificationBody)
                      VALUES (@DeliveryMethod, @AttachmentFormat, @FTPUrl, @FTPPassword, @FTPFilePath, @SharepointUrl, @SharepointDocumentLibrary,
                              @DeliverySchedule, @SpecificDay, @TimeOfDay, @SuccessNotificationEmails, @SuccessNotificationSubject, 
                              @SuccessNotificationBody);
                      SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@DeliveryMethod", fileDeliveryModel.DeliveryMethod);
                    command.Parameters.AddWithValue("@AttachmentFormat", fileDeliveryModel.AttachmentFormat);
                    command.Parameters.AddWithValue("@FTPUrl", fileDeliveryModel.FTPUrl);
                    command.Parameters.AddWithValue("@FTPPassword", fileDeliveryModel.FTPPassword);
                    command.Parameters.AddWithValue("@FTPFilePath", fileDeliveryModel.FTPFilePath);
                    command.Parameters.AddWithValue("@SharepointUrl", fileDeliveryModel.SharepointUrl);
                    command.Parameters.AddWithValue("@SharepointDocumentLibrary", fileDeliveryModel.SharepointDocumentLibrary);
                    command.Parameters.AddWithValue("@DeliverySchedule", fileDeliveryModel.DeliverySchedule);
                    command.Parameters.AddWithValue("@SpecificDay", fileDeliveryModel.SpecificDay);
                    command.Parameters.AddWithValue("@TimeOfDay", fileDeliveryModel.TimeOfDay);
                    command.Parameters.AddWithValue("@SuccessNotificationEmails", fileDeliveryModel.SuccessNotificationEmails);
                    command.Parameters.AddWithValue("@SuccessNotificationSubject", fileDeliveryModel.SuccessNotificationSubject);
                    command.Parameters.AddWithValue("@SuccessNotificationBody", fileDeliveryModel.SuccessNotificationBody);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> UpdateAsync(FileDeliveryModel fileDeliveryModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(
                    @"UPDATE FileDeliveryModel SET DeliveryMethod = @DeliveryMethod, AttachmentFormat = @AttachmentFormat,
                                                   FTPUrl = @FTPUrl, FTPPassword = @FTPPassword, FTPFilePath = @FTPFilePath,
                                                   SharepointUrl = @SharepointUrl, SharepointDocumentLibrary = @SharepointDocumentLibrary,
                                                   DeliverySchedule = @DeliverySchedule, SpecificDay = @SpecificDay,
                                                   TimeOfDay = @TimeOfDay, SuccessNotificationEmails = @SuccessNotificationEmails,
                                                   SuccessNotificationSubject = @SuccessNotificationSubject,
                                                   SuccessNotificationBody = @SuccessNotificationBody
                      WHERE Id = @Id;", connection))
                {
                    command.Parameters.AddWithValue("@DeliveryMethod", fileDeliveryModel.DeliveryMethod);
                    command.Parameters.AddWithValue("@AttachmentFormat", fileDeliveryModel.AttachmentFormat);
                    command.Parameters.AddWithValue("@FTPUrl", fileDeliveryModel.FTPUrl);
                    command.Parameters.AddWithValue("@FTPPassword", fileDeliveryModel.FTPPassword);
                    command.Parameters.AddWithValue("@FTPFilePath", fileDeliveryModel.FTPFilePath);
                    command.Parameters.AddWithValue("@SharepointUrl", fileDeliveryModel.SharepointUrl);
                    command.Parameters.AddWithValue("@SharepointDocumentLibrary", fileDeliveryModel.SharepointDocumentLibrary);
                    command.Parameters.AddWithValue("@DeliverySchedule", fileDeliveryModel.DeliverySchedule);
                    command.Parameters.AddWithValue("@SpecificDay", fileDeliveryModel.SpecificDay);
                    command.Parameters.AddWithValue("@TimeOfDay", fileDeliveryModel.TimeOfDay);
                    command.Parameters.AddWithValue("@SuccessNotificationEmails", fileDeliveryModel.SuccessNotificationEmails);
                    command.Parameters.AddWithValue("@SuccessNotificationSubject", fileDeliveryModel.SuccessNotificationSubject);
                    command.Parameters.AddWithValue("@SuccessNotificationBody", fileDeliveryModel.SuccessNotificationBody);
                    command.Parameters.AddWithValue("@Id", fileDeliveryModel.Id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM FileDeliveryModel WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
    }
}