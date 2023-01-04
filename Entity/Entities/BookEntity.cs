using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPage { get; set; }
        public int Status { get; set; }

       // public DateTime CreatedAt { get; set; }

    }
}
