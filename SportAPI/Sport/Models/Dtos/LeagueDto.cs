using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class LeagueDto : IMapFrom<League>
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public bool? IsHigh { get; set; }
    public int CountForChampionsLeague { get; set; }
    public int CountForEuropeLeague { get; set; }
    public int CountForConferenceLeague { get; set; }
    public int CountForDownLeague { get; set; }
    public List<SportClubDto> SportClubs { get; set; }

    public string GetExportObject()
    {
      return $"{Id};{Name};{Nationality};{IsHigh};{CountForChampionsLeague};{CountForEuropeLeague};{CountForConferenceLeague};{CountForDownLeague};{SportClubs.Count};";
    }
  }
}
