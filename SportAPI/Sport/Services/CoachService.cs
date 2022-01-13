using AutoMapper;
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
    public class CoachService : ICoachService
    {
        private readonly SportDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CoachService> _logger;

        public CoachService(SportDbContext dbContext, IMapper mapper, ILogger<CoachService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public string SaveToCsv(IEnumerable<CoachDto> components)
        {
            var headers = "Id;Name;Surname;Pesel;PhoneNumber;EmailAddress;Cash;SportClubId";

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

        public async Task<long> Create(CreateCoachDto dto)
        {
            _logger.LogInformation("Create new coach");
            var coach = _mapper.Map<Coach>(dto);
            await _dbContext.Coaches.AddAsync(coach);
            await _dbContext.SaveChangesAsync();
            return coach.Id;
        }

        public async Task Delete(long id)
        {
            _logger.LogWarning($"Coach with id: {id} DELETE action invoked");
            var coach = await _dbContext
              .Coaches
              .FirstOrDefaultAsync(x => x.Id == id);

            if (coach is null)
            {
                throw new NotFoundException("Coach not found");
            }

            _dbContext.Coaches.Remove(coach);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CoachDto>> GetAll()
        {
            _logger.LogInformation("Display all the available coaches int this database");
            var coaches = await _dbContext
              .Coaches
              .ToListAsync();

            var coachDtos = _mapper.Map<List<CoachDto>>(coaches);

            return coachDtos;
        }

        public async Task<CoachDto> GetById(long id)
        {
            _logger.LogInformation("Display the information about coach by Id");
            var coach = await _dbContext
              .Coaches
              .FirstOrDefaultAsync(x => x.Id == id);

            if (coach is null)
            {
                throw new NotFoundException("Coach not found");
            }

            var result = _mapper.Map<CoachDto>(coach);
            return result;
        }

        public async Task Update(long id, UpdateCoachDto dto)
        {
            _logger.LogInformation("Update the information about coach by Id");

            var coach = await _dbContext
              .Coaches
              .FirstOrDefaultAsync(x => x.Id == id);

            if (coach is null)
            {
                throw new NotFoundException("Coach not found");
            }

            coach.Name = dto.Name;
            coach.Surname = dto.Surname;
            coach.Pesel = dto.Pesel;
            coach.PhoneNumber = dto.PhoneNumber;
            coach.EmailAddress = dto.EmailAddress;
            coach.Cash = dto.Cash;
            await _dbContext.SaveChangesAsync();
        }
    }
}
