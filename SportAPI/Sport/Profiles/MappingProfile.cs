﻿using AutoMapper;
using System;
using System.Reflection;
using System.Linq;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System.Collections.Generic;

namespace SportAPI.Sport.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<SportClub, SportClubDto>()
      .ForMember(m => m.AddressId, c => c.MapFrom(s => s.Address.Id))
      .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
      .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
      .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
      .ForMember(m => m.UserId, c => c.MapFrom(s => s.User.Id))
      .ForMember(m => m.FirstName, c => c.MapFrom(s => s.User.FirstName))
      .ForMember(m => m.LastName, c => c.MapFrom(s => s.User.LastName))
      .ForMember(m => m.Nationality, c => c.MapFrom(s => s.User.Nationality))
      .ForMember(m => m.Login, c => c.MapFrom(s => s.User.Login))
      .ForMember(m => m.Password, c => c.MapFrom(s => s.User.Password));

      CreateMap<Match, MatchDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id));
      CreateMap<Player, PlayerDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id));
      CreateMap<Training, TrainingDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id));
      CreateMap<Coach, CoachDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id));

      CreateMap<User, UserDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id))
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.Role.RoleName));

      CreateMap<Role, RoleDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.RoleName));

      CreateMap<Address,AddressDto>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClub.Id));

      CreateMap<League, LeagueDto>();

      CreateMap<CreateSportClubDto, SportClub>()
          .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }))
          .ForMember(r => r.User, c => c.MapFrom(dto => new User() { FirstName = dto.FirstName, LastName = dto.LastName, Login = dto.Login, Password = dto.Password, RoleId = dto.RoleId }));

      CreateMap<RegisterUserDto, User>();
      CreateMap<LoginDto, User>()
        .ForMember(m => m.Login, c => c.MapFrom(s => s.Login))
        .ForMember(m => m.Password, c => c.MapFrom(s => s.Password));
      CreateMap<CreateRoleDto, Role>();
      CreateMap<CreateAddressDto, Address>();
      CreateMap<CreateTrainingDto, Training>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClubId));
      CreateMap<CreatePlayerDto, Player>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClubId));
      CreateMap<CreateMatchDto, Match>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClubId));
      CreateMap<CreateCoachDto, Coach>()
        .ForMember(m => m.SportClubId, c => c.MapFrom(s => s.SportClubId));
      CreateMap<CreateLeagueDto, League>();

      ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public MappingProfile(Assembly assembly)
    {
      ApplyMappingsFromAssembly(assembly);
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
      var types = assembly.GetExportedTypes()
        .Where(t => t.GetInterfaces().Any(i => 
        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
        .ToList();

      foreach (var type in types)
      {
        var instance = Activator.CreateInstance(type);

        var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

        methodInfo?.Invoke(instance, new object[] { this });
      }
    }
  }
}
