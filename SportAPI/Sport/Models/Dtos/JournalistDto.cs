﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class JournalistDto
  {
    public int JournalistId { get; set; }
    public int DepartmentId { get; set; }
    public int Name { get; set; }
    public int Surname { get; set; }
    public int Position { get; set; }
    public bool IsDriver { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Seniority { get; set; }
    public string Interestings { get; set; }
  }
}