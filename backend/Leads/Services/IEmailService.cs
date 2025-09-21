using System.Threading.Tasks;

namespace LeadsAPI.Services
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}