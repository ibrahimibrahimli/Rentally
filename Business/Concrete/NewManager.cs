using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
namespace Business.Concrete
{
    public class NewManager : INewService
    {
        NewDal newDal = new();
        public IResult Add(New entity)
        {
            newDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            newDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<New>> GetAll()
        {
            return new SuccessDataResult<List<New>>(newDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<New> GetById(int id)
        {
            return new SuccessDataResult<New>(newDal.GetById(id)); 
        }

        public IResult Update(New entity)
        {
            entity.UpdatedDate = DateTime.Now;
            newDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
