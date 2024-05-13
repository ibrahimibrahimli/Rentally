using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompletedOrders { get; set; }
        public int Customers { get; set; }
        public int Cars { get; set; }
    }

}
