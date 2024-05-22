using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TeamBoardManager : ITeamBoardService
    {
        private readonly ITeamBoardDal _teamBoardDal;
        private readonly IValidator<TeamBoard> _validator;

        public TeamBoardManager(ITeamBoardDal teamBoardDal, IValidator<TeamBoard> validator)
        {
            _teamBoardDal = teamBoardDal;
            _validator = validator;
        }
        public IResult Add(TeamBoardCreateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = TeamBoardCreateDto.ToTeamboard(dto);
            var validator = _validator.Validate(model);
            model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _teamBoardDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _teamBoardDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<TeamBoard>> GetAll()
        {
            return new SuccessDataResult<List<TeamBoard>>(_teamBoardDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<TeamBoard> GetById(int id)
        {
            return new SuccessDataResult<TeamBoard>(_teamBoardDal.GetById(id));
        }

        public IDataResult<List<TeamBoardDto>> GetTeamBoardWithPosition()
        {
            return new SuccessDataResult<List<TeamBoardDto>>(_teamBoardDal.GetTeamBoardWithPosition());
        }

        public IResult Update(TeamBoardUpdateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = TeamBoardUpdateDto.ToTeamboard(dto);

            var existData = GetById(dto.Id).Data;
            if (imageUrl == null)
            {
                model.ImageUrl = existData.ImageUrl;
            }
            else
            {
                model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

            model.UpdatedDate = DateTime.Now;
            _teamBoardDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
