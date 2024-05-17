using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TeamBoardDal : BaseRepository<TeamBoard, ApplicationDbContext>, ITeamBoardDal
    {
        ApplicationDbContext context = new();
        public List<TeamBoard> GetTeamBoardWithPosition()
        {
            var data = context.TeamBoards
                .Where(x => x.Deleted == 0)
                .Include(x => x.Position).ToList();
            return data;
        }
    }

}
