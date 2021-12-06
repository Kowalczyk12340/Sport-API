using System;

namespace SportAPI.Sport.Models
{
  public class AuthTokenConfiguration : DomainEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}
