﻿using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderService
    {
        IResult Add(Slider entity);
        IResult Update(Slider entity);
        IResult Delete(int id);
        IDataResult<List<Slider>> GetAll();
        IDataResult<Slider> GetById(int id);
    }
}