using AutoMapper;

namespace AntiDotNET.Application.Profiles;

public interface IMappable
{
    void MapTo<TDestination>(Profile profile)
    {
        profile.CreateMap(GetType(), typeof(TDestination));
    }

    void MapFrom<TSource>(Profile profile)
    {
        profile.CreateMap(typeof(TSource), GetType());
    }
}