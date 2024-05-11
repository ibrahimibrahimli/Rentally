using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //-----------------------------------
    public class Social : BaseEntity
    {
        public int TeamBoardId { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
        public virtual TeamBoard TeamBoard { get; set; }
    }

}
