using System.Threading.Tasks;

namespace NetCoreVue.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
