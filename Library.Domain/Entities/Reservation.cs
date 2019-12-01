using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Book> Books { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ReservedTo { get; set; }

    }
}
