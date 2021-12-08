using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Customer : DomainEntity
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string NumberHouse { get; set; }
    public string Post { get; set; }
    public string PostalCode { get; set; }
    public string Interestings { get; set; }
    public bool IsActive { get; set; }
  }
}
