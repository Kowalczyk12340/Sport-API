using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class League
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public bool? IsHigh { get; set; }
    public int CountForChampionsLeague { get; set; }
    public int CountForEuropeLeague { get; set; }
    public int CountForConferenceLeague { get; set; }
    public int CountForDownLeague { get; set; }
    public virtual List<SportClub> SportClubs { get; set; }
  }
}
