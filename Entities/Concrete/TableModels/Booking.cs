﻿using Core.Entities.Abstract;
using Entities.Concrete.TableModels.Membership;

namespace Entities.Concrete.TableModels
{
    public class Booking : BaseEntity
    {
        public int UserId { get; set; }
        public int CarID { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string? Message { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public byte Status { get; set; } //  0-Scheduled, 1-Completed, 2-Cancelled
        public virtual Car Car { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

}
