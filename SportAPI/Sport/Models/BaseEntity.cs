using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public abstract class BaseEntity : DomainEntity
  {
    public long Id { get; set; }
  }
}
