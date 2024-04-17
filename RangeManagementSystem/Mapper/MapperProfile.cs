using AutoMapper;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Weapon, WeaponViewModel>();
        }
    }
}
