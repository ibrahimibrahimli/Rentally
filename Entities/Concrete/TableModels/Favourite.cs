using Core.Entities.Abstract;
using Entities.Concrete.TableModels.Membership;

namespace Entities.Concrete.TableModels
{
    public class Favourite : BaseEntity
    {
        public Favourite()
        {
            Cars = new HashSet<Car>();
        }
        //-------------------------
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
