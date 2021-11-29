using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.ViewModel.Models
{
    public class BookViewModel
    {
        [Required]
        [JsonPropertyName("book_id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author_id")]
        public int AuthorId { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
