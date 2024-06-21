using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class FavouriteDal : BaseRepository<Favourite, ApplicationDbContext>, IFavouriteDal
    {
        private readonly ApplicationDbContext _context;

        public FavouriteDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Favourite> GetFavouritesWithUserIdAndCarID()
        {
            throw new NotImplementedException();
        }
        //public List<Favourite> GetFavouritesWithUserIdAndCarID()
        //{
        //    var result = from favourite in _context.Favorites
        //                 where favourite.Deleted == 0
        //                 join car in _context.Cars on favourite.CarId equals car.Id
        //                 where car.Deleted == 0
        //                 join user in _context.Users on favourite.UserId equals user.Id
        //                 where user.Deleted == 0
        //                 select new FavouriteDto
        //                 {
        //                     UserId = user.Id,
        //                     Cars =
        //                 };


        //    return result.ToList();
        //}
    }

}
