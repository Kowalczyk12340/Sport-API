using AutoMapper;
using System;
using System.Reflection;
using System.Linq;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;

namespace SportAPI.Sport.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

      CreateMap<SportClub, SportClubDto>()
      .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
      .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
      .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
      .ForMember(m => m.Login, c => c.MapFrom(s => s.User.Login));

        CreateMap<Match, MatchDto>();
        CreateMap<Player, PlayerDto>();
        CreateMap<Training, TrainingDto>();
        CreateMap<Coach, CoachDto>();

        CreateMap<CreateAddressDto, Address>()
          .ForMember(r => r.SportClub, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
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
