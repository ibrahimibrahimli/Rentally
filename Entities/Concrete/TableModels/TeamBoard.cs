using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //---------------------
    public class TeamBoard : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
    }

}
