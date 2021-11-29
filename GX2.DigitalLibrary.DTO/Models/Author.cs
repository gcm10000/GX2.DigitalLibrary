using System.Collections.Generic;

namespace GX2.DigitalLibrary.DTO.Models
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
