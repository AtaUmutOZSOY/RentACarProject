﻿using Core.Entity.DTOs;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entity.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);

    }
}
