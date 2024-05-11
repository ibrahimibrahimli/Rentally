﻿using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //------------------------
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public virtual User User { get; set; }
    }



}
