using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class FavouriteItem : BaseEntity
    {
        public int CarId { get; set; }
        public int FavouriteId { get; set; }
        public string Name { get; set; }
        public virtual Favourite Favourite { get; set; }
        public virtual Car Car { get; set; }
    }
}
