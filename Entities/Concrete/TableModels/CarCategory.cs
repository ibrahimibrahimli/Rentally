using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class CarCategory : BaseEntity
    {
        public string Title { get; set; }
        public string IconName { get; set; }
        public List<Car> Cars { get; set; }
    }

}
