using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class DepartmentDto
  {
    public string DepartmentName { get; set; }
    public long ParentId { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public long? GroupId { get; set; }
    public virtual JournalistDto Journalist { get; set; }
    public virtual UserDto User { get; set; }
  }
}
