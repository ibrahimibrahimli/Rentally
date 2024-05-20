using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ITeamBoardDal: IBaseRepository<TeamBoard> 
    {
        List<TeamBoardDto> GetTeamBoardWithPosition();
    }
}
