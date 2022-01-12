using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Exceptions;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
    public class SportClubService : ISportClubService
    {
        private readonly SportDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SportClubService> _logger;
        //private readonly IAuthorizationService _authorizationService;

        public SportClubService(SportDbContext dbContext, IMapper mapper, ILogger<SportClubService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Create(CreateSportClubDto dto)
        {
            _logger.LogInformation("Creating a new sport club in this database");
            var sportClub = _mapper.Map<SportClub>(dto);
            await _dbContext.Clubs.AddAsync(sportClub);
            await _dbContext.SaveChangesAsync();
            return sportClub.Id;
        }

        public string SaveToCsv(IEnumerable<SportClubDto> components)
        {
            var headers = "Id;SportClubName;Description;Category;HasOwnStadium;Category;Address.City;Address.Street;Address.PostalCode;User.FirstName;User.LastName;Trainings.Count;Coaches.Count;Players.Count;Coaches.Count";

            var csv = new StringBuilder(headers);

            csv.Append(Environment.NewLine);

            foreach (var component in components)
            {
                csv.Append(component.GetExportObject());
                csv.Append(Environment.NewLine);
            }
            csv.Append($"Count: {components.Count()}");
            csv.Append(Environment.NewLine);

            return csv.ToString();
        }

        public async Task Delete(long id)
        {
            _logger.LogWarning($"Sport Club with id: {id} DELETE action invoked");

            var sportClub = await _dbContext
              .Clubs
              .FirstOrDefaultAsync(x => x.Id == id);

            if (sportClub is null)
            {
                throw new NotFoundException("Sport Club not found");
            }
            _dbContext.Clubs.Remove(sportClub);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SportClubDto>> GetAll()
        {
            _logger.LogInformation("Getting All the Sport Clubs available in this database");
            var sportClubs = await _dbContext
              .Clubs
              .Include(x => x.Address)
              .Include(x => x.User)
              .Include(x => x.Matches)
              .Include(x => x.Coaches)
              .Include(x => x.Players)
              .Include(x => x.Trainings)
              .ToListAsync();

            var sportClubDtos = _mapper.Map<List<SportClubDto>>(sportClubs);
            return sportClubDtos;
        }

        public async Task<SportClubDto> GetById(long id)
        {
            _logger.LogInformation($"Getting the sport club by {id}");
            var sportClub = await _dbContext
              .Clubs
              .Include(x => x.Address)
              .Include(x => x.User)
              .Include(x => x.Matches)
              .Include(x => x.Coaches)
              .Include(x => x.Players)
              .Include(x => x.Trainings)
              .FirstOrDefaultAsync(x => x.Id == id);

            if (sportClub is null)
            {
                throw new NotFoundException("Sport Club Not Found");
            }

            var result = _mapper.Map<SportClubDto>(sportClub);
            return result;

        }

        public async Task Update(long id, UpdateSportClubDto dto)
        {
            _logger.LogInformation($"Updating the Sport Club by {id}");
            var sportClub = await _dbContext
              .Clubs
              .FirstOrDefaultAsync(x => x.Id == id);

            if (sportClub is null)
            {
                throw new NotFoundException("Sport Club not found");
            }

            sportClub.SportClubName = dto.SportClubName;
            sportClub.Description = dto.Description;
            sportClub.HasOwnStadium = dto.HasOwnStadium;
            sportClub.Category = dto.Category;
            sportClub.ContactEmail = dto.ContactEmail;
            sportClub.ContactNumber = dto.ContactNumber;
        }
    }
}