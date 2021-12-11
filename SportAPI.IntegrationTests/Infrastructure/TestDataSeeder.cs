using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.Infrastructure
{
  public class TestDataSeeder
  {
    private readonly SportDbContext _context;

    public TestDataSeeder(SportDbContext context)
    {
      _context = context;
    }

    private void SeedSportClub(SportDbContext context)
    {
      var sportClub = new SportClub()
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
              BetterFoot = BetterFoot.RIGHT,
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
              BetterFoot = BetterFoot.RIGHT,
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
              BetterFoot = BetterFoot.LEFT,
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
              BetterFoot = BetterFoot.RIGHT,
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
              BetterFoot = BetterFoot.LEFT,
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
              BetterFoot = BetterFoot.LEFT,
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
              BetterFoot = BetterFoot.RIGHT,
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
              BetterFoot = BetterFoot.RIGHT,
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
              BetterFoot = BetterFoot.RIGHT,
              Nationality = "Portugalia",
              Position = "Pomocnik",
              Pesel = "87061049034",
              EmailAddress = "pedro.tiba@wp.pl",
              PhoneNumber = "+48 707 400 481",
            },
          }
      };
    }

    public async Task SeedDb()
    {
      _context.Database.EnsureDeleted();
      _context.Database.EnsureCreated();

      await _context.SaveChangesAsync();
      SeedSportClub(_context);
    }
  }
}
