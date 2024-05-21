using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
namespace Business.Concrete
{
    public class NewManager : INewService
    {
        private readonly INewDal _newDal;

        public NewManager(INewDal newDal)
        {
            _newDal = newDal;
        }
        public IResult Add(NewCreateDto dto)
        {
            var model  = NewCreateDto.ToNew(dto);

            _newDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _newDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<New>> GetAll()
        {
            return new SuccessDataResult<List<New>>(_newDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<New> GetById(int id)
        {
            return new SuccessDataResult<New>(_newDal.GetById(id)); 
        }

        public IResult Update(NewUpdateDto dto)
        {
            var model = NewUpdateDto.ToNew( dto);
            model.UpdatedDate = DateTime.Now;
            _newDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
