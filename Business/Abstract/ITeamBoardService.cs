using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamBoardService
    {
        IResult Add(TeamBoard entity);
        IResult Update(TeamBoard entity);
        IResult Delete(int id);
        IDataResult<List<TeamBoard>> GetAll();
        IDataResult<TeamBoard> GetById(int id);
    }
}
