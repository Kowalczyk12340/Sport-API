using Microsoft.AspNetCore.Identity;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.UnitTests.Common
{
  public class DbHelper
  {
    public static void SeedDb(SportDbContext context)
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var league = SetupLeague();
      context.Leagues.Add(league);

      var club = SetupClub();
      context.Clubs.Add(club);

      context.SaveChanges();
    }

    private static League SetupLeague()
    {
      return new League()
        {
          Name = "Barclays Premier League",
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
                City = "Manchester",
                PostalCode = "70-999",
                Street = "Wolf Street Centre 563"
              },
              User = new User()
              {
                FirstName = "Alex",
                LastName = "Fergusson",
                Nationality = "Scotland",
                IsActive = true,
                Login = "alex.fergusson@wp.pl",
                Password = "Marcingrafik1#",
                DateOfBirth = DateTime.ParseExact("1951-02-23 11:23", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Role = new Role { RoleName = "ADMIN" }
              },
              Category = "Klub Piłki Nożnej",
              ContactEmail = "manchester.united@manu.com",
              ContactNumber = "+42 94 98 98 123",
              Description = "Klub Piłkarski założony przez brytyjskich żeglarzy w roku 1888, w celu popularyzacji nowego sportu, jakim jest piłka nożna wtedy, na całym świecie",
              HasOwnStadium = true,
              SportClubName = "Manchester United",
              Coaches = new List<Coach>()
              {
                new Coach()
                {
                  Name = "Ralf",
                  Surname = "Rangnick",
                  Cash = "300 000 PLN",
                  EmailAddress = "ralf.rangnick@wp.pl",
                  Pesel = "66092192837",
                  PhoneNumber = "+42 506 903 990",
                  SportClubId = 3
                }
              },
              Trainings = new List<Training>()
              {
                new Training()
                {
                  Name = "Trening Sprawnościowy",
                  Description = "Ćwiczenia ogólnorozjowe, rozciąganie mięsni i tkanek miękkich",
                  TimeOfTraining = DateTime.ParseExact("2021-12-29 11:23", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                  SportClubId = 1
                }
              },
              Matches = new List<Match>()
              {
                new Match()
                {
                  DateOfMatch = DateTime.ParseExact("2022-01-04 20:45", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                  InHouse = true,
                  TeamOne = "Manchester United",
                  TeamTwo = "Manchester City",
                  SportClubId = 1
                }
              },
              Players = new List<Player>()
              {
                new Player()
                {
                  Name = "Cristiano",
                  Surname = "Ronaldo",
                  BetterFoot = Sport.Models.Enums.BetterFoot.RIGHT,
                  EmailAddress = "cristiano.ronaldo@ronaldo.com",
                  Nationality = "Portugalia",
                  Pesel = "85020582935",
                  PhoneNumber = "+42 560 283 912",
                  Position = "Napastnik",
                  SportClubId = 1
                }
              }
            }
          },
          IsHigh = true,
          Nationality = "Anglia"
        };
    }
    private static SportClub SetupClub()
    {
      return new SportClub
      {
        SportClubName = "KKS Lech Poznań",
        Description = "Polski klub założony w 1922 roku na poznańskim zebraniu kolejarzy na ulicy Bułgarskiej, gdzie dzisiaj znajduje się stadion",
        Category = "Klub Piłki Nożnej",
        HasOwnStadium = true,
        ContactEmail = "kkslechpoznan@kolejorz.com",
        ContactNumber = "+48 61 98 34 091",
        Address = new Address()
        {
          City = "Poznań",
          PostalCode = "60-200",
          Street = "Bułgarska 13"
        },
        User = new User()
        {
          FirstName = "Marcin",
          LastName = "Kowalczyk",
          DateOfBirth = DateTime.ParseExact("1999-06-10 16:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
          Role = new Role { RoleName = "Admin"},
          IsActive = true,
          Nationality = "Polska",
          Login = "marcinkowalczyk24.7@gmail.com",
          Password = "Marcingrafik1#",
        },
        Coaches = new List<Coach>()
          {
            new Coach()
            {
              Name = "Maciej",
              Surname = "Skorża",
              Pesel = "67081234590",
              Cash = "50 000 PLN",
              PhoneNumber = "+48 607 801 212",
              EmailAddress = "maciej.skorża@wp.pl",
              SportClubId = 1
            },
            new Coach()
            {
              Name = "Dariusz",
              Surname = "Dudka",
              Pesel = "78010841029",
              Cash = "23 000 PLN",
              PhoneNumber = "+48 500 278 999",
              EmailAddress = "dariusz.dudka@interia.pl",
              SportClubId = 1
            },
            new Coach()
            {
              Name = "Piotr",
              Surname = "Reiss",
              Pesel = "72052309173",
              Cash = "20 000 PLN",
              PhoneNumber = "+48 782 233 980",
              EmailAddress = "maciej.skorża@wp.pl",
              SportClubId = 1
            },
          },
        Matches = new List<Match>
          {
            new Match()
            {
              TeamOne = "Lech Poznań",
              TeamTwo = "Legia Warszawa",
              InHouse = true,
              DateOfMatch = DateTime.UtcNow,
              SportClubId = 1
            },
            new Match()
            {
              TeamOne = "Wisła Kraków",
              TeamTwo = "Lech Poznań",
              InHouse = false,
              DateOfMatch = new DateTime(2021,11,30,20,45,0),
              SportClubId = 1
            },
            new Match()
            {
              TeamOne = "Lech Poznań",
              TeamTwo = "Śląsk Wrocław",
              InHouse = true,
              DateOfMatch = new DateTime(2021,11,21,18,45,0),
              SportClubId = 1
            },
          },
        Trainings = new List<Training>()
          {
            new Training()
            {
              Name = "Trening Siłowy",
              Description = "Trening, który odbywa się na hali sportowej, w którym zawodnicy wykonują ćwiczenia siłowe",
              TimeOfTraining = new DateTime(2021,11,24,8,45,0),
              SportClubId = 1
            },
            new Training()
            {
              Name = "Trening Biegowy",
              Description = "Trening, który odbywa się w terenie, lub na bieżni, w którym zawodnicy wykonują biegi na różnych dystansach",
              TimeOfTraining = new DateTime(2021,11,25,9,20,0),
              SportClubId = 1
            },
            new Training()
            {
              Name = "Trening Strzelecki",
              Description = "Trening, który odbywa się na boisku treningowym, w którym zawodnicy grający w polu strzelają bramkarzom z różnych pozycji na boisku",
              TimeOfTraining = new DateTime(2021,11,24,8,45,0),
              SportClubId = 1
            },
          },
        Players = new List<Player>()
          {
            new Player()
            {
              Name = "Jakub",
              Surname = "Kamiński",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Pomocnik",
              Pesel = "03121298467",
              EmailAddress = "jakub.kaminski@wp.pl",
              PhoneNumber = "+48 506 666 712",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Michał",
              Surname = "Skóraś",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Pomocnik",
              Pesel = "00019283701",
              EmailAddress = "michal.skoras@gmail.com",
              PhoneNumber = "+48 790 981 003",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Adrien",
              Surname = "Ba Loua",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.LEFT,
              Nationality = "Wybrzeże Kości Słoniowej",
              Position = "Pomocnik",
              Pesel = "95111198478",
              EmailAddress = "adrien.baloua@gmail.com",
              PhoneNumber = "+48 606 183 301",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Filip",
              Surname = "Bednarek",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Bramkarz",
              Pesel = "91081992834",
              EmailAddress = "filip.bednarek@onet.pl",
              PhoneNumber = "+48 609 777 432",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Antonio",
              Surname = "Milić",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.LEFT,
              Nationality = "Serbia",
              Position = "Obrońca",
              Pesel = "92020285734",
              EmailAddress = "antonio.milic@gmail.com",
              PhoneNumber = "+48 504 657 435",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Barry",
              Surname = "Douglas",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.LEFT,
              Nationality = "Szkocja",
              Position = "Obrońca",
              Pesel = "89060783746",
              EmailAddress = "barry.douglas@onet.pl",
              PhoneNumber = "+48 771 321 222",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Mikael",
              Surname = "Ishak",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Szwecja",
              Position = "Napastnik",
              Pesel = "90040590839",
              EmailAddress = "mikael.ishak@gmail.com",
              PhoneNumber = "+48 783 321 666",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Alan",
              Surname = "Czerwiński",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Obrońca",
              Pesel = "93111209483",
              EmailAddress = "alan.czerwinski@wp.pl",
              PhoneNumber = "+48 903 432 810",
              SportClubId = 1
            },
            new Player()
            {
              Name = "Pedro",
              Surname = "Tiba",
              BetterFoot = SportAPI.Sport.Models.Enums.BetterFoot.RIGHT,
              Nationality = "Portugalia",
              Position = "Pomocnik",
              Pesel = "87061049034",
              EmailAddress = "pedro.tiba@wp.pl",
              PhoneNumber = "+48 707 400 481",
              SportClubId = 1
            },
          }
      };
    }
  }
}
