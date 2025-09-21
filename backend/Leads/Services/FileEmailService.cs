using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LeadsAPI.Services
{
    public class FileEmailService : IEmailService
    {
        private readonly string _path;

        public FileEmailService(IConfiguration config)
        {
            _path = config.GetValue<string>("Email:FilePath") ?? "emails.txt";
        }

        public Task SendAsync(string to, string subject, string body)
        {
            var line = $"{DateTime.UtcNow:o} | To:{to} | Subject:{subject} | Body:{body}{Environment.NewLine}";
            File.AppendAllText(_path, line);
            return Task.CompletedTask;
        }
    }
}