using SportAPI.Sport.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class PlayerDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public BetterFoot BetterFoot { get; set; }
    public string Position { get; set; }
    public int SportClubId { get; set; }
    public virtual SportClubDto SportClub { get; set; }
  }
}
