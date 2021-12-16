using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SportAPI.Sport.Seeders
{
  public class SportClubSeeder
  {
    private readonly SportDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public SportClubSeeder(SportDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
      _dbContext = dbContext;
      _passwordHasher = passwordHasher;
    }

    public void Seed()
    {
      if(_dbContext.Database.CanConnect())
      {
        if(!_dbContext.Roles.Any())
        {
          var roles = GetRoles();
          _dbContext.Roles.AddRange(roles);
          _dbContext.SaveChanges();
        }

        if(!_dbContext.Clubs.Any())
        {
          var clubs = GetClubs();
          _dbContext.Clubs.AddRange(clubs);
          _dbContext.SaveChanges();
        }
      }
    }

    private IEnumerable<Role> GetRoles()
    {
      var roles = new List<Role>()
      {
        new Role()
        {
          RoleName = "User"
        },
        new Role()
        {
          RoleName = "Admin"
        },
        new Role()
        {
          RoleName = "Manager"
        }
      };

      return roles;
    }

    private IEnumerable<SportClub> GetClubs()
    {
      var clubs = new List<SportClub>()
      {
        new SportClub()
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
            Role = _dbContext.Roles.FirstOrDefault(x => x.RoleName == "Admin"),
            IsActive = true,
            Login = "marcinkowalczyk24.7",
            Password = BCrypt.Net.BCrypt.HashPassword("Marcingrafik1#"),
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
            },
            new Coach()
            {
              Name = "Dariusz",
              Surname = "Dudka",
              Pesel = "78010841029",
              Cash = "23 000 PLN",
              PhoneNumber = "+48 500 278 999",
              EmailAddress = "dariusz.dudka@interia.pl",
            },
            new Coach()
            {
              Name = "Piotr",
              Surname = "Reiss",
              Pesel = "72052309173",
              Cash = "20 000 PLN",
              PhoneNumber = "+48 782 233 980",
              EmailAddress = "maciej.skorża@wp.pl",
            },
          },
          Matches = new List<Match>
          {
            new Match()
            {
              TeamOne = "Lech Poznań",
              TeamTwo = "Legia Warszawa",
              InHouse = true,
              DateOfMatch = DateTime.UtcNow
            },
            new Match()
            {
              TeamOne = "Wisła Kraków",
              TeamTwo = "Lech Poznań",
              InHouse = false,
              DateOfMatch = new DateTime(2021,11,30,20,45,0),
            },
            new Match()
            {
              TeamOne = "Lech Poznań",
              TeamTwo = "Śląsk Wrocław",
              InHouse = true,
              DateOfMatch = new DateTime(2021,11,21,18,45,0),
            },
          },
          Trainings = new List<Training>()
          {
            new Training()
            {
              Name = "Trening Siłowy",
              Description = "Trening, który odbywa się na hali sportowej, w którym zawodnicy wykonują ćwiczenia siłowe",
              TimeOfTraining = new DateTime(2021,11,24,8,45,0),
            },
            new Training()
            {
              Name = "Trening Biegowy",
              Description = "Trening, który odbywa się w terenie, lub na bieżni, w którym zawodnicy wykonują biegi na różnych dystansach",
              TimeOfTraining = new DateTime(2021,11,25,9,20,0),
            },
            new Training()
            {
              Name = "Trening Strzelecki",
              Description = "Trening, który odbywa się na boisku treningowym, w którym zawodnicy grający w polu strzelają bramkarzom z różnych pozycji na boisku",
              TimeOfTraining = new DateTime(2021,11,24,8,45,0),
            },
          },
          Players = new List<Player>()
          {
            new Player()
            {
              Name = "Jakub",
              Surname = "Kamiński",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Pomocnik",
              Pesel = "03121298467",
              EmailAddress = "jakub.kaminski@wp.pl",
              PhoneNumber = "+48 506 666 712",
            },
            new Player()
            {
              Name = "Michał",
              Surname = "Skóraś",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Pomocnik",
              Pesel = "00019283701",
              EmailAddress = "michal.skoras@gmail.com",
              PhoneNumber = "+48 790 981 003",
            },
            new Player()
            {
              Name = "Adrien",
              Surname = "Ba Loua",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Wybrzeże Kości Słoniowej",
              Position = "Pomocnik",
              Pesel = "95111198478",
              EmailAddress = "adrien.baloua@gmail.com",
              PhoneNumber = "+48 606 183 301",
            },
            new Player()
            {
              Name = "Filip",
              Surname = "Bednarek",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Bramkarz",
              Pesel = "91081992834",
              EmailAddress = "filip.bednarek@onet.pl",
              PhoneNumber = "+48 609 777 432",
            },
            new Player()
            {
              Name = "Antonio",
              Surname = "Milić",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Serbia",
              Position = "Obrońca",
              Pesel = "92020285734",
              EmailAddress = "antonio.milic@gmail.com",
              PhoneNumber = "+48 504 657 435",
            },
            new Player()
            {
              Name = "Barry",
              Surname = "Douglas",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Szkocja",
              Position = "Obrońca",
              Pesel = "89060783746",
              EmailAddress = "barry.douglas@onet.pl",
              PhoneNumber = "+48 771 321 222",
            },
            new Player()
            {
              Name = "Mikael",
              Surname = "Ishak",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Szwecja",
              Position = "Napastnik",
              Pesel = "90040590839",
              EmailAddress = "mikael.ishak@gmail.com",
              PhoneNumber = "+48 783 321 666",
            },
            new Player()
            {
              Name = "Alan",
              Surname = "Czerwiński",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Obrońca",
              Pesel = "93111209483",
              EmailAddress = "alan.czerwinski@wp.pl",
              PhoneNumber = "+48 903 432 810",
            },
            new Player()
            {
              Name = "Pedro",
              Surname = "Tiba",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Portugalia",
              Position = "Pomocnik",
              Pesel = "87061049034",
              EmailAddress = "pedro.tiba@wp.pl",
              PhoneNumber = "+48 707 400 481",
            },
          }
        },
        new SportClub()
        {
          SportClubName = "WKS Legia Warszawa",
          Description = "Warszawski klub założony w 1916 roku na warszawskim zebraniu żołnierzy warszawskich legionów na ulicy Łazienkowskiej, gdzie dzisiaj znajduje się stadion",
          Category = "Klub Piłki Nożnej",
          HasOwnStadium = true,
          ContactEmail = "wkslegiawarszawa@wojskowi.com",
          ContactNumber = "+48 21 56 32 111",
          Address = new Address()
          {
            City = "Warszawa",
            PostalCode = "11-321",
            Street = "Łazienkowska 3"
          },
          User = new User()
          {
            FirstName = "Karol",
            LastName = "Strasburger",
            IsActive = true,
            DateOfBirth = DateTime.ParseExact("1991-11-12 08:23", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            Role = _dbContext.Roles.FirstOrDefault(x => x.RoleName == "Admin"),
            Login = "karol.strasburger12",
            Password = BCrypt.Net.BCrypt.HashPassword("Marcingrafik1#"),
          },
          Coaches = new List<Coach>()
          {
            new Coach()
            {
              Name = "Czesław",
              Surname = "Michniewicz",
              Pesel = "63090934590",
              Cash = "60 000 PLN",
              PhoneNumber = "+48 511 902 439",
              EmailAddress = "czeslaw.michniewicz@wp.pl",
            },
            new Coach()
            {
              Name = "Wojciech",
              Surname = "Łazarek",
              Pesel = "51010541029",
              Cash = "43 000 PLN",
              PhoneNumber = "+48 500 278 999",
              EmailAddress = "dariusz.dudka@interia.pl",
            },
          },
          Matches = new List<Match>
          {
            new Match()
            {
              TeamOne = "Zawisza Bydgoszcz",
              TeamTwo = "Legia Warszawa",
              InHouse = false,
              DateOfMatch = DateTime.UtcNow
            },
            new Match()
            {
              TeamOne = "Legia Warszawa",
              TeamTwo = "Lech Poznań",
              InHouse = true,
              DateOfMatch = new DateTime(2021,10,23,20,45,0),
            },
            new Match()
            {
              TeamOne = "Legia Warszawa",
              TeamTwo = "Jagiellonia Białystok",
              InHouse = true,
              DateOfMatch = new DateTime(2021,12,14,17,50,0),
            },
          },
          Trainings = new List<Training>()
          {
            new Training()
            {
              Name = "Trening Techniczny",
              Description = "Trening, który odbywa się na hali sportowej, w którym zawodnicy wykonują ćwiczenia szkolące technikę użytkową",
              TimeOfTraining = new DateTime(2021,11,28,10,45,0),
            },
            new Training()
            {
              Name = "Trening Taktyczny",
              Description = "Trening, który odbywa się na boisku treningowym, w którym zawodnicy wykonują treningi taktyczne zgodne z ich pozycją na boisku",
              TimeOfTraining = new DateTime(2021,11,30,10,35,0),
            },
            new Training()
            {
              Name = "Trening Meczowy",
              Description = "Trening, który odbywa się na boisku treningowym, w którym zawodnicy podzieleni na dwie grupy grają mecz 11x11",
              TimeOfTraining = new DateTime(2021,12,4,13,0,0),
            },
          },
          Players = new List<Player>()
          {
            new Player()
            {
              Name = "Artur",
              Surname = "Jędrzejczyk",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Obrońca",
              Pesel = "86011298467",
              EmailAddress = "artur.jedrzejczyk@wp.pl",
              PhoneNumber = "+48 806 111 231",
            },
            new Player()
            {
              Name = "Artur",
              Surname = "Boruc",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Polska",
              Position = "Bramkarz",
              Pesel = "80044982703",
              EmailAddress = "artur.boruc@gmail.com",
              PhoneNumber = "+48 501 407 623",
            },
            new Player()
            {
              Name = "Filip",
              Surname = "Mladenović",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Serbia",
              Position = "Obrońca",
              Pesel = "94072992508",
              EmailAddress = "filip.mladenovic@onet.pl",
              PhoneNumber = "+48 765 452 555",
            },
            new Player()
            {
              Name = "Josue",
              Surname = "Vide",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Portugalia",
              Position = "Pomocnik",
              Pesel = "95029085590",
              EmailAddress = "josue.vide@gmail.com",
              PhoneNumber = "+48 780 790 541",
            },
            new Player()
            {
              Name = "Bartosz",
              Surname = "Kapustka",
              BetterFoot = Models.Enums.BetterFoot.RIGHT,
              Nationality = "Polska",
              Position = "Obrońca",
              Pesel = "96062283005",
              EmailAddress = "bartosz.kapustka@onet.pl",
              PhoneNumber = "+48 555 324 501",
            },
            new Player()
            {
              Name = "Thomas",
              Surname = "Pekhart",
              BetterFoot = Models.Enums.BetterFoot.LEFT,
              Nationality = "Czechy",
              Position = "Napastnik",
              Pesel = "92032445324",
              EmailAddress = "thomas.pekhart@gmail.com",
              PhoneNumber = "+48 567 050 546",
            },
          }
        }
      };
      return clubs;
    }
  }
}
