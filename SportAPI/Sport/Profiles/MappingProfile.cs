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
      CreateMap<SportClub, SportClubDto>()
      .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
      .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
      .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
      .ForMember(m => m.FirstName, c => c.MapFrom(s => s.User.FirstName))
      .ForMember(m => m.LastName, c => c.MapFrom(s => s.User.LastName))
      .ForMember(m => m.Login, c => c.MapFrom(s => s.User.Login))
      .ForMember(m => m.Password, c => c.MapFrom(s => s.User.Password));

      CreateMap<Match, MatchDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName));
      CreateMap<Player, PlayerDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName));
      CreateMap<Training, TrainingDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName));
      CreateMap<Coach, CoachDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName));

      CreateMap<User, UserDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName))
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.Role.RoleName));

      CreateMap<Role, RoleDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.RoleName));

      CreateMap<Address,AddressDto>()
        .ForMember(m => m.SportClubName, c => c.MapFrom(s => s.SportClub.SportClubName));

      CreateMap<CreateSportClubDto, SportClub>()
          .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }))
          .ForMember(r => r.User, c => c.MapFrom(dto => new User() { FirstName = dto.FirstName, LastName = dto.LastName, Login = dto.Login, Password = dto.Password }));

      CreateMap<CreateAddressDto, Address>();
      CreateMap<CreateUserDto, User>();
      CreateMap<CreateRoleDto, Role>();
      CreateMap<CreateTrainingDto, Training>();
      CreateMap<CreatePlayerDto, Player>();
      CreateMap<CreateMatchDto, Match>();
      CreateMap<CreateCoachDto, Coach>();

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
