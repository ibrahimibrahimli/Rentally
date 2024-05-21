using Core.Entities.Abstract;

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
        public virtual User User { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
