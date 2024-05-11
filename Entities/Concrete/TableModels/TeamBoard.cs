using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class TeamBoard : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }

}
