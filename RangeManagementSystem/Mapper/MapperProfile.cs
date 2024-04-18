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
            CreateMap<ShootingEvent, ShootingEventViewModel>()
                .ForMember(x => x.OrganizerName, y =>
                y.MapFrom(s => s.ApplicationUser.UserName))
                 .ForMember(x => x.StartDate, y =>
                y.MapFrom(s => s.StartTime))
                  .ForMember(x => x.EndDate, y =>
                y.MapFrom(s => s.EndTime));
        }
    }
}
