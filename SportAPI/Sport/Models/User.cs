﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class User : BaseEntity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CardId { get; set; }
    public bool IsActive { get; set; }
    public string Login { get; set; }
    public int Password { get; set; }
  }
}