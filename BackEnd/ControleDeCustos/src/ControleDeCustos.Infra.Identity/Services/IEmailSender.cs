using System.Threading.Tasks;

namespace ControleDeCustos.Infra.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
