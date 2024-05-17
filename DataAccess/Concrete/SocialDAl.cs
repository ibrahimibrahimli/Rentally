using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class SocialDal : BaseRepository<Social, ApplicationDbContext>, ISocialDal
    {
        ApplicationDbContext context = new();
        public List<Social> GetSocialWithTeamBoardId()
        {
            var data = context.Socials
                .Where(x => x.Deleted == 0)
                .Include(x => x.TeamBoard)
                .ToList();
            return data;
        }
    }

}
