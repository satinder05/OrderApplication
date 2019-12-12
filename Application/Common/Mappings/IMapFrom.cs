using AutoMapper;

namespace Application.Common.Mappings
{
    interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
