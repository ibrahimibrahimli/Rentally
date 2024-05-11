using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class New : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }

}
