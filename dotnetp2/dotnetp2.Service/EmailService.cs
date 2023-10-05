}
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}

public class EmailService : IEmailService
{
    private string _smtpServer;
    private string _smtpUsername;
    private string _smtpPassword;
    private string _scheduleTime;

    public EmailService(string smtpServer, string smtpUsername, string smtpPassword, string scheduleTime)
    {
        _smtpServer = smtpServer;
        _smtpUsername = smtpUsername;
        _smtpPassword = smtpPassword;
        _scheduleTime = scheduleTime;
    }
    
    public async Task<bool> SendSmtpEmailAsync(string from, string to, string subject, string body, string attachmentPath)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.Attachments.Add(new Attachment(attachmentPath));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(_smtpServer);
            smtp.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> SendFileToFTPAsync(string sourceFilePath, string destinationFilePath)
    {
        try
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destinationFilePath);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FileStream sourceStream = File.OpenRead(sourceFilePath))
            {
                byte[] buffer = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(buffer, 0, buffer.Length);
                sourceStream.Close();

                Stream requestStream = await request.GetRequestStreamAsync();
                await requestStream.WriteAsync(buffer, 0, buffer.Length);
                requestStream.Close();
            }

            FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync();
            response.Close();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> SendFileToSharepointAsync(string sourceFilePath, string destinationFilePath)
    {
        try
        {
            // TODO: Implement
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> ProcessRequestsAsync()
    {
        try
        {
            // Get the schedule times from the database
            List<string> scheduleTimes = await GetScheduleTimesAsync();

            // Get the requests from the database
            List<Request> requests = await GetRequestsAsync();

            // Process each request based on the schedule time
            foreach (Request request in requests)
            {
                if (scheduleTimes.Contains(request.ScheduleTime))
                {
                    if (request.DestinationType == "smtp")
                    {
                        await SendSmtpEmailAsync(request.From, request.To, request.Subject, request.Body, request.AttachmentPath);
                    }
                    else if (request.DestinationType == "ftp")
                    {
                        await SendFileToFTPAsync(request.AttachmentPath, request.DestinationPath);
                    }
                    else if (request.DestinationType == "sharepoint")
                    {
                        await SendFileToSharepointAsync(request.AttachmentPath, request.DestinationPath);
                    }
                }
            }

