﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetById(int id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetByBrandId(int id);
        List<Car> GetByColorId(int id);
        List<CarDetailDto> GetCarDetails();
    }
}
