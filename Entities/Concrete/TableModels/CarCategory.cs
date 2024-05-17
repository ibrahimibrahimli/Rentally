using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class CarCategory : BaseEntity
    {
        public CarCategory()
        {
            Cars = new HashSet<Car>();
        }
        public string Title { get; set; }
        public string IconName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
