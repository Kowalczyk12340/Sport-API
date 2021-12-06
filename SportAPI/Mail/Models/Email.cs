using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Mail.Models
{
  public class Email
  {
    #region Properties
    internal string From { get; set; }
    internal string DisplayFrom { get; set; }
    internal string[] To { get; set; }
    internal string[] CC { get; set; }
    internal string[] BCC { get; set; }
    internal string Subject { get; set; }
    internal string Body { get; set; }

    #endregion

    public Email()
    {
      To = new string[0];
      CC = new string[0];
      BCC = new string[0];
    }

    public MimeMessage ToMimeMessage()
    {
      var message = new MimeMessage();
      message.From.Add(new MailboxAddress(DisplayFrom, From));

      foreach (var recipient in To)
        message.To.Add(new MailboxAddress(recipient));
      foreach (var recipient in CC)
        message.Cc.Add(new MailboxAddress(recipient));
      foreach (var recipient in BCC)
        message.Bcc.Add(new MailboxAddress(recipient));

      message.Subject = Subject;

      var builder = new BodyBuilder { HtmlBody = Body };
      message.Body = builder.ToMessageBody();

      return message;
    }
  }
}
