﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.DTO.Models
{
    public class BookUser
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
