using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.DTO.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public DateTime EstablishedYead { get; set; }
    }
}
