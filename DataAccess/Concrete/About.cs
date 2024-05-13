using Core.DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class About : BaseRepository<Entities.Concrete.TableModels.About, ApplicationDbContext> { }
}
