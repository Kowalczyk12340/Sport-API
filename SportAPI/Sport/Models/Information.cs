﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Information : DomainEntity
  {
    public int InformationId { get; set; }
    public int CustomerId { get; set; }
    public string InformationStatusId { get; set; }
    public string Info { get; set; }
    public int Title { get; set; }
    public string DateOfInfo { get; set; }
    public string Description { get; set; }
  }
}
