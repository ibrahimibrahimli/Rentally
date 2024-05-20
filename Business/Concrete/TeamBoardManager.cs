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
    public class TeamBoardManager : ITeamBoardService
    {
        TeamBoardDal teamBoardDal = new();
        public IResult Add(TeamBoardCreateDto dto)
        {
            var model = TeamBoardCreateDto.ToTeamboard(dto);
            teamBoardDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            teamBoardDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<TeamBoard>> GetAll()
        {
            return new SuccessDataResult<List<TeamBoard>>(teamBoardDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<TeamBoard> GetById(int id)
        {
            return new SuccessDataResult<TeamBoard>(teamBoardDal.GetById(id));
        }

        public IDataResult<List<TeamBoardDto>> GetTeamBoardWithPosition()
        {
            return new SuccessDataResult<List<TeamBoardDto>>(teamBoardDal.GetTeamBoardWithPosition());
        }

        public IResult Update(TeamBoardUpdateDto dto)
        {
            var model = TeamBoardUpdateDto.ToTeamboard(dto);
            model.UpdatedDate = DateTime.Now;
            teamBoardDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
