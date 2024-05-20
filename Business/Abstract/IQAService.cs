using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQAService
    {
        IResult Add(QuestionAnswerCreateDto dto);
        IResult Update(QuestionAnswerUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<QA>> GetAll();
        IDataResult<QA> GetById(int id);
    }
}
