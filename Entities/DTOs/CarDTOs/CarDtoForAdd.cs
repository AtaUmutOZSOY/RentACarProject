using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CarDTOs
{
    public class CarDtoForAdd:IDto
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public int MyProperty { get; set; }
    }
}
