using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author : Person
    {
        public List<Book> Books { get; set; }
    }
}
