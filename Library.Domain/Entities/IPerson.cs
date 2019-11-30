using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Entities
{
    public interface IPerson
    {
        [Key]
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
