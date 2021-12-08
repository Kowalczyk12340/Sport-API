﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class MatchDto
  {
    public long Id { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public bool InHouse { get; set; }
    public DateTime DateOfMatch { get; set; }
    public string SportClubName { get; set; }
  }
}