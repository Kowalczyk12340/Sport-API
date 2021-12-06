using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class CategorySportsman : DomainEntity
  {
    public int CategorySportsmanId { get; set; }
    public string CategorySportsmanName { get; set; }  
  }
}
