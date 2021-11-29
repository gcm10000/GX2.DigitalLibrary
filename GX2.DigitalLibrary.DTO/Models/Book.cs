using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GX2.DigitalLibrary.DTO.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("AuthorFK")]
        public Author Author { get; set; }
        public int AuthorFK { get; set; }

        public ICollection<BookUser> BookUsers { get; set; }

    }
}