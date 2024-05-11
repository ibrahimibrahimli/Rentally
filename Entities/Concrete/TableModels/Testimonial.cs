using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //-------------
    public class Testimonial : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ImageUrl { get; set; }
    }

}
