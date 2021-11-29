using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.ViewModel.Models
{
    public class AuthorViewModel
    {
        [JsonPropertyName("author_id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
