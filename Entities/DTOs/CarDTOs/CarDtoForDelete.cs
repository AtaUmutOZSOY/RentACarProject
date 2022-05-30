using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CarDTOs
{
    public class CarDtoForDelete:IDto
    {
        public int CarId { get; set; }
    }
}
