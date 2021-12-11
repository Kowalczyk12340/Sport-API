using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.Infrastructure
{
  public static class HttpRequestExtensions
  {
    public static HttpRequestMessage WithAuthHeader(this HttpRequestMessage message, User user)
    {
      var headerValues = new List<string>();
      headerValues.Add($"{user.Login} {CreateMd5Hash(user.Id, user.LastName)}");
      message.Headers.Add("DBHash", headerValues);

      return message;
    }

    private static string CreateMd5Hash(long id, string lastName)
    {
      var userIdsAndLastNameBytes = Encoding.UTF8.GetBytes($"{id}{lastName}");
      using var provider = System.Security.Cryptography.MD5.Create();
      var builder = new StringBuilder();

      provider.ComputeHash(userIdsAndLastNameBytes).ToList().ForEach(result =>
      {
        builder.Append(result.ToString("x2").ToLower());
      });

      return builder.ToString();
    }
  }
}
