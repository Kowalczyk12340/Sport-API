using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.ActiveDirectory.Interfaces
{
  public interface IActiveDirectoryService
  {
    string GetUserEmail(string userId);
  }
}
