using SportAPI.Mail.Interfaces;
using SportAPI.Mail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Mail
{
  public class FluentMail
  {
    private readonly Email _item;

    public FluentMail()
    {
      _item = new Email();
    }

    public FluentMail From(string displayName, string email)
    {
      _item.DisplayFrom = displayName;
      _item.From = email;
      return this;
    }

    public FluentMail To(params string[] emails)
    {
      _item.To = emails;
      return this;
    }

    public FluentMail To(List<string> emails)
    {
      _item.To = emails.ToArray();
      return this;
    }

    public FluentMail CC(params string[] emails)
    {
      _item.CC = emails;
      return this;
    }

    public FluentMail CC(List<string> emails)
    {
      _item.CC = emails.ToArray();
      return this;
    }

    public FluentMail BCC(params string[] emails)
    {
      _item.BCC = emails;
      return this;
    }

    public FluentMail BCC(List<string> emails)
    {
      _item.BCC = emails.ToArray();
      return this;
    }

    public FluentMail Subject(string subject)
    {
      _item.Subject = subject;
      return this;
    }

    public FluentMail Body(string body)
    {
      _item.Body = body;
      return this;
    }

    public Task<bool> SendAsync(IMailService mailService)
    {
      return mailService.SendAsync(_item);
    }
  }
}