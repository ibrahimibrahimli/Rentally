using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class TeamBoardManager : ITeamBoardService
    {
        TeamBoardDal teamBoardDal = new();
        public IResult Add(TeamBoard entity)
        {
            teamBoardDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            teamBoardDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<TeamBoard> GetById(int id)
        {
            return new SuccessDataResult<TeamBoard>(teamBoardDal.GetById(id));
        }

        public IDataResult<List<TeamBoard>> GetTeamBoardWithPosition()
        {
            return new SuccessDataResult<List<TeamBoard>>(teamBoardDal.GetTeamBoardWithPosition());
        }

        public IResult Update(TeamBoard entity)
        {
            entity.UpdatedDate = DateTime.Now;
            teamBoardDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
