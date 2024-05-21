using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class QAManager : IQAService
    {
        private readonly IQADal _qADal;
        private readonly IValidator<QA> _validator;
        public QAManager(IQADal qADal, IValidator<QA> validator)
        {
            _qADal = qADal;
            _validator = validator;
        }
        public IResult Add(QuestionAnswerCreateDto dto)
        {
            var model = QuestionAnswerCreateDto.ToQuestionAnswer(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _qADal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(QuestionAnswerUpdateDto dto)
        {
            var model = QuestionAnswerUpdateDto.ToQuestionAnswer(dto);
            model.UpdatedDate = DateTime.Now;
            _qADal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _qADal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<QA>> GetAll()
        {
            return new SuccessDataResult<List<QA>>(_qADal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<QA> GetById(int id)
        {
            return new SuccessDataResult<QA>(_qADal.GetById(id));
        }
    }
}
