using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.ViewModel.Models
{
    //Maiores informações: https://www.oauth.com/oauth2-servers/access-tokens/access-token-response/
    public class AccessTokenResponseViewModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
