using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //-----------------------


    public class WeExperience : BaseEntity
    {
        public WeExperience()
        {
            Cars = new HashSet<Car>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompletedOrders { get; set; }
        public int Customers { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
