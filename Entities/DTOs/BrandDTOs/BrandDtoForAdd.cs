using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.BrandDTOs
{
    public class BrandDtoForAdd:IDto
    {
        public string BrandName { get; set; }
    }
}
