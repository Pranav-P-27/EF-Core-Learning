using ProductShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Domain.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public DateTime EstablishedYead { get; set; }
    }
}
