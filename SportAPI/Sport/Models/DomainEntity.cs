using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAPI.Sport.Models
{
  public abstract class DomainEntity
  {
    [NotMapped]
    private readonly List<INotification> _events = new List<INotification>();

    [NotMapped]
    public IEnumerable<INotification> Events => _events.AsReadOnly();

    public void AddEvent(INotification @event)
    {
      _events.Add(@event);
    }

    public void ClearEvents()
    {
      _events.Clear();
    }
  }
}
