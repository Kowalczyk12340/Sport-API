using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class AddressDto : IMapFrom<Address>
  {
    public long Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }

    public string GetExportObject()
    {
      return $"{Id};{City};{Street};{PostalCode}";
    }
  }
}
