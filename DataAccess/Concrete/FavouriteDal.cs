﻿using Core.DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class FavouriteDal : BaseRepository<Favourite, ApplicationDbContext> { }

}
