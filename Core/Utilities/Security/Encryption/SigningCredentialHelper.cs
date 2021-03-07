using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securiyKey)
        {
            return new SigningCredentials(securiyKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}