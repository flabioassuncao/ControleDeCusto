using System.Threading.Tasks;

namespace ControleDeCustos.Infra.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
