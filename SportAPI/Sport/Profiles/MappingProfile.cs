using AutoMapper;
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
      CreateMap<SportClub, SportClubDto>();

      CreateMap<SportClub, SportClubDto>();

      CreateMap<Match, MatchDto>();
      CreateMap<Player, PlayerDto>();
      CreateMap<Training, TrainingDto>();
        
      CreateMap<Coach, CoachDto>();

      CreateMap<User, UserDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.Role.RoleName));

      CreateMap<Role, RoleDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.RoleName));

      CreateMap<Address, AddressDto>();

      CreateMap<League, LeagueDto>();
      CreateMap<Course, CourseDto>();

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
      CreateMap<CreateCourseDto, Course>();
      CreateMap<CreateSportClubDto, SportClub>()
        .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
      
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
