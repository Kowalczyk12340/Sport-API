﻿using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class SportSportsmanService : ISportSportsmanService
  {
    public Task<int> Create(SportSportsmanDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<SportSportsmanDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<SportSportsmanDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, SportSportsmanDto dto)
    {
      throw new NotImplementedException();
    }
  }
}