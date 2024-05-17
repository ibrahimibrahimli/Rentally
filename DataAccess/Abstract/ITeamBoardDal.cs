using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ITeamBoardDal: IBaseRepository<TeamBoard> 
    {
        List<TeamBoard> GetTeamBoardWithPosition();
    }
}
