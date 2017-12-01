using AutoMapper;

namespace LerningSystem.Common.Mapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
