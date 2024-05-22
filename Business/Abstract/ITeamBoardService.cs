using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamBoardService
    {
        IResult Add(TeamBoardCreateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Update(TeamBoardUpdateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<TeamBoardDto>> GetTeamBoardWithPosition();
        IDataResult<TeamBoard> GetById(int id);
    }
}
