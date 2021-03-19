using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerExample_4.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int pageCount { get; set; }
        public int AlbumId { get; set; }
    }
}
