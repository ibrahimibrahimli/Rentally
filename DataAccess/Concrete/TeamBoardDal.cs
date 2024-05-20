using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TeamBoardDal : BaseRepository<TeamBoard, ApplicationDbContext>, ITeamBoardDal
    {
        ApplicationDbContext _context = new();
        

        public List<TeamBoardDto> GetTeamBoardWithPosition()
        {

            var result = from teamBoard in _context.TeamBoards
                         where teamBoard.Deleted == 0
                         join position in _context.Positions on teamBoard.PositionId equals position.Id
                         where position.Deleted == 0
                         select new TeamBoardDto
                         {
                             Id = teamBoard.Id,
                             PinterestUrl = teamBoard.PinterestUrl,
                             FacebookUrl = teamBoard.FacebookUrl,
                             TwitterUrl = teamBoard.TwitterUrl,
                             LinkedinUrl = teamBoard.LinkedinUrl,
                             Name = teamBoard.Name,
                             Surname = teamBoard.Surname,
                             ImageUrl = teamBoard.ImageUrl,
                             PositionName = position.Name,
                         };

            return result.ToList();
        }
    }

}
