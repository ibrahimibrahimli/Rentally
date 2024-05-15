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
    public class QAManager : IQAService
    {
        QADal qaDal = new();
        public IResult Add(QA entity)
        {
            qaDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(QA entity)
        {
            entity.UpdatedDate = DateTime.Now;
            qaDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            qaDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<QA>> GetAll()
        {
            return new SuccessDataResult<List<QA>>(qaDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<QA> GetById(int id)
        {
            return new SuccessDataResult<QA>(qaDal.GetById(id));
        }
    }
}
