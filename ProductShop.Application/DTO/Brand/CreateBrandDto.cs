using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.DTO.Brand
{
    public class CreateBrandDto
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public DateTime EstablishedYead { get; set; }
    }
}
