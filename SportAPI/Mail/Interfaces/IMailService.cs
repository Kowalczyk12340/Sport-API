using SportAPI.Mail.Models;
using System.Threading.Tasks;

namespace SportAPI.Mail.Interfaces
{
  public interface IMailService
  {
    Task<bool> SendAsync(Email mail);
  }
}
