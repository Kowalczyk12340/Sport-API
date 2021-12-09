using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Create
{
  public class CreateAddressDto : IMapFrom<Address>
  {
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
  }
}
