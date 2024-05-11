using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //------------------
    public class Feature : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

}
