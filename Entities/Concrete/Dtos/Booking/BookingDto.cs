﻿using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarID { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public byte Status { get; set; } //  0-Scheduled, 1-Completed, 2-Cancelled
        public string CarBrand { get; set; }
        public string UserName { get; set; }
    }
}