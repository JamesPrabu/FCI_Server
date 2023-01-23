using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Supplier
    {
        [Key]
        public long supplierId { get; set; }    
        public string supplierName { get; set;}
    }
}
