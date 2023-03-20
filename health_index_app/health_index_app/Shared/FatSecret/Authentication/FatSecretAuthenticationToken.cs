using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatSecretAPICall.ResponseObjects;

namespace FatSecretAPICall.Authentication
{
    public class FatSecretAuthenticationToken
    {
        private DateTime _expiration;
        public string AccessToken { get; set; } = string.Empty;
        public bool IsExpired => DateTime.Now >= _expiration;

        public FatSecretAuthenticationToken() {
            _expiration = DateTime.MinValue;
        }

        public void SetToken(FatSecretTokenResponse FatSecretTokenResponse)
        {
            AccessToken = FatSecretTokenResponse.Access_Token;
            _expiration = DateTime.UtcNow.AddSeconds(FatSecretTokenResponse.Expires_In);
        }

    }
}
