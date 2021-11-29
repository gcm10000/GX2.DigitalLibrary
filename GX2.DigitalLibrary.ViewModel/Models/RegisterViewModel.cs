using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.ViewModel.Models
{
    public class RegisterViewModel : CredentialViewModel
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
