﻿using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CarCategoryId { get; set; }
        public int DoorCount { get; set; }
        public int Count { get; set; }
        public int PassengerCount { get; set; }
        public DateTime Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; }
        public string CarCategoryName { get; set; }
        public bool IsHomePage { get; set; }
        public static Car ToCar(CarUpdateDto dto)
        {
            Car car = new Car()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                CarCategoryId = dto.CarCategoryId,
                DoorCount = dto.DoorCount,
                Count = dto.Count,
                PassengerCount = dto.PassengerCount,
                Year = dto.Year,
                PricePerDay = dto.PricePerDay,
                ImageUrl = dto.ImageUrl,
                IsHomePage = dto.IsHomePage,
            };

            return car;
        }
    }
}
