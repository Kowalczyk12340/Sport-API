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
    public class AddressService : IAddressService
    {
        private readonly SportDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;

        public AddressService(SportDbContext dbContext, IMapper mapper, ILogger<AddressService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<long> Create(CreateAddressDto dto)
        {
            _logger.LogInformation("Create a new address");
            var address = _mapper.Map<Address>(dto);
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address.Id;
        }

        public async Task Delete(long id)
        {
            _logger.LogWarning($"It will be deleted address with id: {id}");

            var address = await _dbContext
              .Addresses
              .FirstOrDefaultAsync(x => x.Id == id);

            if (address is null)
            {
                throw new NotFoundException("Address not found");
            }

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            _logger.LogInformation("Display all the addresses");
            var addresses = await _dbContext
              .Addresses
              .ToListAsync();

            var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
            return addressDtos;
        }

        public async Task<AddressDto> GetById(long id)
        {
            _logger.LogInformation($"Display address with {id}");
            var address = await _dbContext
              .Addresses
              .FirstOrDefaultAsync(x => x.Id == id);

            if (address is null)
            {
                throw new NotFoundException("Address not found");
            }

            var result = _mapper.Map<AddressDto>(address);
            return result;
        }

        public string SaveToCsv(IEnumerable<AddressDto> components)
        {
            var headers = "Id;City;Street;PostalCode";

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

        public async Task Update(long id, UpdateAddressDto dto)
        {
            _logger.LogInformation($"Edit address with {id}");
            var address = await _dbContext
              .Addresses
              .FirstOrDefaultAsync(x => x.Id == id);

            if (address is null)
            {
                throw new NotFoundException("Address not found");
            }

            address.City = dto.City;
            address.PostalCode = dto.PostalCode;
            address.Street = dto.Street;
            await _dbContext.SaveChangesAsync();
        }
    }
}