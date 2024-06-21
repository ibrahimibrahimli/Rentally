using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Entities.Concrete.TableModels.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Favourite : BaseEntity
    {
        public Favourite()
        {
            FavouriteItems = new HashSet<FavouriteItem>();
        }
        public int UserId { get; set; }
        public int FavouriteItemsId { get; set; }
        public ICollection<FavouriteItem> FavouriteItems { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
