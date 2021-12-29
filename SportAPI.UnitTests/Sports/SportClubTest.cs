using MediatR;
using Moq;
using NUnit.Framework;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportAPI.UnitTests.Sports
{
  public class SportClubTest
  {
    private SqlServerDatabase _database;
    private SportDbContext _sportDbContext;

    [SetUp]
    public void SetUp()
    {
      var mediator = new Mock<IMediator>();
      _database = new SqlServerDatabase();
      _sportDbContext = new SportDbContext(_database.ContextOptions, mediator.Object);
    }

    [TearDown]
    public void TearDown()
    {
      _database.Dispose();
    }

    [Test]
    public void ShouldDisplaySuitableValueForChosenNameAndSurname()
    {
      //Arrange
      StringBuilder stringBuilder = new StringBuilder();
      var name = _sportDbContext.Users.FirstOrDefault(x => x.FirstName.Equals("Marcin"));
      var lastName = _sportDbContext.Users.FirstOrDefault(x => x.LastName.Equals("Kowalczyk"));
      //Act 
      stringBuilder.Append(name.Nationality).Append(" ").Append(lastName.Login);
      var result = stringBuilder.ToString();
      //Assert
      Assert.AreEqual("Polska marcinkowalczyk24.7@gmail.com", result);
    }

    [TestCase(1,10)]
    public void ShouldDisplaySuitableDataForClub(long id, long idPlayer)
    {
      //Arrange
      StringBuilder stringBuilder = new StringBuilder();
      var categoryOfClub = _sportDbContext.Clubs.FirstOrDefault(x => x.Id == id).Category;
      var playerWithChosenPositionAndNationality = _sportDbContext.Clubs.FirstOrDefault(x => x.Id == id).ContactEmail;
      //Act 
      stringBuilder.Append(categoryOfClub).Append(" ").Append(playerWithChosenPositionAndNationality);
      var result = stringBuilder.ToString();
      //Assert
      Assert.AreEqual("Klub Piłki Nożnej kkslechpoznan@kolejorz.com", result);
    }

    [TestCase("User")]
    public async Task ShouldSaveRoleCorrectly(string roleName)
    {
      //Arrange
      var mediator = new Mock<IMediator>();
      var context = new SportDbContext(_database.ContextOptions, mediator.Object);

      //Act
      Role role = new Role { RoleName = roleName };
      await context.Roles.AddAsync(role);
      await context.SaveChangesAsync();

      //Assert
      Assert.That(context.Roles.ToList().Count > 0);
      Assert.That(context.Roles.ToList().First().RoleName == roleName);
    }

    [Test]
    public async Task ShouldSaveLeagueCorrectly()
    {
      //Arrange
      var mediator = new Mock<IMediator>();
      var context = new SportDbContext(_database.ContextOptions, mediator.Object);

      var league = new League()
      {
        SportClubs = context.Clubs.ToList(),
        Name = "Liga Polska - Ekstraklasa",
        CountForChampionsLeague = 1,
        CountForEuropeLeague = 2,
        CountForDownLeague = 3,
        CountForConferenceLeague = 3,
        Nationality = "Polska",
        IsHigh = true,
      };
      //Act
      await context.Leagues.AddAsync(league);
      await context.SaveChangesAsync();
      //Assert
      Assert.That(context.Leagues.ToList().Count > 0);
      Assert.That(context.Leagues.Find(1L).Nationality.Equals("Polska"));
    }


    [TestCase(10040L)]
    public async Task ShouldDisplaySuitableClubInLeague(long id)
    {
      //Arrange
      var mediator = new Mock<IMediator>();
      var context = new SportDbContext(_database.ContextOptions, mediator.Object);

      //Act
      League league = new League
      {
        Name = "Italian Serie A",
        CountForChampionsLeague = 4,
        CountForEuropeLeague = 4,
        CountForConferenceLeague = 3,
        CountForDownLeague = 4,
        SportClubs = new List<SportClub>()
          {
            new SportClub()
            {
              Address = new Address()
              {
                City = "Roma",
                PostalCode = "31-011",
                Street = "Frnacesco Totti Street 45"
              },
              User = new User()
              {
                FirstName = "Francesco",
                LastName = "Totti",
                Nationality = "Italy",
                IsActive = true,
                Login = "francesco.totti@wp.pl",
                Password = "Marcingrafik1#",
                DateOfBirth = DateTime.ParseExact("1972-07-14 12:11", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Role = new Role() { RoleName = "Admin" }
              },
              Category = "Klub Piłki Nożnej",
              ContactEmail = "asroma.roma@roma.com",
              ContactNumber = "+41 56 45 34 452",
              Description = "Klub Piłkarski założony przez włoskich młynarzy w roku 1902, w celu popularyzacji nowego sportu, jakim jest piłka nożna wtedy, na całym świecie",
              HasOwnStadium = true,
              SportClubName = "AS Roma",
              Coaches = new List<Coach>()
              {
                new Coach()
                {
                  Name = "Jose",
                  Surname = "Mourinho",
                  Cash = "320 000 PLN",
                  EmailAddress = "jose.mourinho@wp.pl",
                  Pesel = "61010990923",
                  PhoneNumber = "+41 764 342 110",
                  SportClubId = 10040L
                }
              },
              Trainings = new List<Training>()
              {
                new Training()
                {
                  Name = "Trening Rozruchowy",
                  Description = "Ćwiczenia ogólnorozjowe, rozciąganie mięsni i tkanek miękkich",
                  TimeOfTraining = DateTime.ParseExact("2022-01-02 11:23", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                  SportClubId = 4
                }
              },
              Matches = new List<Sport.Models.Match>()
              {
                new Sport.Models.Match()
                {
                  DateOfMatch = DateTime.ParseExact("2022-01-04 20:45", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                  InHouse = true,
                  TeamOne = "AS Roma",
                  TeamTwo = "Lazio Rzym",
                  SportClubId = 10040L
                }
              },
              Players = new List<Player>()
              {
                new Player()
                {
                  Name = "Niccolo",
                  Surname = "Zaniolo",
                  BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
                  EmailAddress = "niccolo.zaniolo@roma.com",
                  Nationality = "Włochy",
                  Pesel = "01220582935",
                  PhoneNumber = "+41 900 321 768",
                  Position = "Napastnik",
                  SportClubId = 10040L
                }
              }
            }
          },
        IsHigh = true,
        Nationality = "Włochy"
      };
      await context.Leagues.AddAsync(league);
      await context.SaveChangesAsync();

      //Assert
      Assert.That(context.Leagues.ToList().Count > 0);
      Assert.That(context.Leagues.ToList().FirstOrDefault(x => x.Id == id).Nationality.Equals("Włochy"));
    }
  }
}
