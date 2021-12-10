using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using SportAPI.ActiveDirectory.Interfaces;

namespace SportAPI.ActiveDirectory.Services
{
  public class ActiveDirectoryService : IActiveDirectoryService
  {
    private readonly IConfiguration _configuration;

    public ActiveDirectoryService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string GetUserEmail(string userId)
    {
      using var connection = CreateConnection();
      var queue = connection.Search("OU=Users,OU=Ziemięcin,OU=Ziemięcin,DC=ad,DC=Ziemięcin,DC=com", LdapConnection.ScopeSub, $"(userId={userId})", null, false);
      string email = null;
      if(queue.HasMore())
      {
        try
        {
          var entry = queue.Next();
          if(entry.GetAttributeSet().ContainsKey("mail"))
          {
            email = entry.GetAttribute("mail").StringValue;
          }
        }
        catch(LdapException ex)
        {
          //TODO
        }
      }
      connection.Disconnect();
      return email;
    }

    private LdapConnection CreateConnection()
    {
      var section = _configuration.GetSection("ActiveDirectory");
      var connection = new LdapConnection { SecureSocketLayer = false };
      connection.Connect(section["Domain"], int.Parse(section["Port"]));
      connection.Bind(section["Username"], section["Password"]);
      return connection;
    }
  }
}
