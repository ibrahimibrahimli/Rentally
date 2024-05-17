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
    public class SocialManager : ISocialService
    {
        SocialDal socialDal = new();
        public IResult Add(Social entity)
        {
            socialDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            socialDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<Social> GetById(int id)
        {
            return new SuccessDataResult<Social>(socialDal.GetById(id));
        }

        public IDataResult<List<Social>> GetSocialWithTeamBoardId()
        {
            return new SuccessDataResult<List<Social>>(socialDal.GetSocialWithTeamBoardId());
        }

        public IResult Update(Social entity)
        {
            entity.UpdatedDate = DateTime.Now;
            socialDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
