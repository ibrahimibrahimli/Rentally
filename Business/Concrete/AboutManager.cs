using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        AboutDal aboutDal = new();
        public IResult Add(About entity)
        {
            aboutDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(aboutDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(aboutDal.GetById(id));
        }

        public IResult Update(About entity)
        {
            entity.UpdatedDate = DateTime.Now;
            aboutDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
