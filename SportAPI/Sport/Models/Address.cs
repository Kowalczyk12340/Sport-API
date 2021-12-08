using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Address : DomainEntity
  {
    public long Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public virtual SportClub SportClub { get; set; }
  }
}
