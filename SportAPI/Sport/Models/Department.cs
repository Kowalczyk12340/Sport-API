using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Department : DomainEntity
  {
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public long ParentId { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public long? GroupId { get; set; }
    public virtual Journalist Journalist { get; set; }
    public virtual User User { get; set; }
  }
}
