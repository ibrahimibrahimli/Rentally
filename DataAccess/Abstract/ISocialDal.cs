using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ISocialDal : IBaseRepository<Social> 
    {
        List<Social> GetSocialWithTeamBoardId();
    }
}
