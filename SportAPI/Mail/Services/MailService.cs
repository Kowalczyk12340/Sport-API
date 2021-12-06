using SportAPI.Mail.Interfaces;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SportAPI.Mail.Models;

namespace SportAPI.Mail.Services
{
  public class MailService : IMailService
  {
    private readonly IConfiguration _configuration;
    private readonly ILogger<MailService> _logger;

    public MailService(IConfiguration configuration, ILogger<MailService> logger)
    {
      _configuration = configuration;
      _logger = logger;
    }

    public async Task<bool> SendAsync(Email mail)
    {
      try
      {
        using(var smtp = new SmtpClient() { Timeout = 20000 })
        {
          await smtp.ConnectAsync(_configuration.GetSection("Mail")["SMTP"], 25, false);
          smtp.AuthenticationMechanisms.Remove("XOAUTH2");

          if(Environment.GetEnvironmentVariable("aspnetcore_environment") != "PRODUCTION")
          {
            mail.Body += "<br><br><h4 style=\"color: #731768;\">Ten email został wysłany przez developera testującego tę funkcjonalność" +
              " i powinien zostać zignorowany. Przepraszamy za zakłopotanie spowodowane tą wiadomością.</h4>";
            mail.Subject = "[System Testowy - IGNORUJ] " + mail.Subject;
          }
          await smtp.SendAsync(mail.ToMimeMessage());
          await smtp.DisconnectAsync(true);

          _logger.LogInformation("Email sent: {Email}", mail.Body);
          return true;
        }
      }
      catch (Exception exception)
      {
        _logger.LogError(exception, "Exception while sending email");
        return false;
      }
    }
  }
}