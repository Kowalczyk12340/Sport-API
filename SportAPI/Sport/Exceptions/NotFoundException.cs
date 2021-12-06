using System;

namespace SportAPI.Sport.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string message) : base(message)
    {

    }
  }
}
