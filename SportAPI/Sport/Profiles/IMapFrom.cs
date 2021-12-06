using AutoMapper;

namespace SportAPI.Sport.Profiles
{
  public interface IMapFrom<T>
  {
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
  }
}
