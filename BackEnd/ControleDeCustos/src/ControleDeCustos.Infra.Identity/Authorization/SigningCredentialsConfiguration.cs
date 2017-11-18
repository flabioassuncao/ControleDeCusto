using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ControleDeCustos.Infra.Identity.Authorization
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "cdc@meuambienteToken";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
