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
        private readonly ITeamBoardDal _teamBoardDal;

        public TeamBoardManager(ITeamBoardDal teamBoardDal)
        {
            _teamBoardDal = teamBoardDal;
        }
        public IResult Add(TeamBoardCreateDto dto)
        {
            var model = TeamBoardCreateDto.ToTeamboard(dto);
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

        public IResult Update(TeamBoardUpdateDto dto)
        {
            var model = TeamBoardUpdateDto.ToTeamboard(dto);
            model.UpdatedDate = DateTime.Now;
            _teamBoardDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
