using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.RentalDTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public string BrandName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

    }
}
