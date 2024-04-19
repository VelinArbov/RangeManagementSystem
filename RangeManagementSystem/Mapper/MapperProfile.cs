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
            CreateMap<Weapon, WeaponEditViewModel>().ReverseMap();
            CreateMap<WeaponCreateViewModel, Weapon>();
            CreateMap<Ammunition, AmmunitionViewModel>();
            CreateMap<ShootingEvent, ShootingEventViewModel>()
                .ForMember(x => x.OrganizerName, y =>
                y.MapFrom(s => s.ApplicationUser.UserName))
                 .ForMember(x => x.StartDate, y =>
                y.MapFrom(s => s.StartTime))
                  .ForMember(x => x.EndDate, y =>
                y.MapFrom(s => s.EndTime));

            CreateMap<Reservation, ReservationDataViewModel>()
                .ForMember(x => x.WeaponType, y =>
                y.MapFrom(s => s.Weapon.Type))
                 .ForMember(x => x.AmmoType, y =>
                y.MapFrom(s => s.Ammunition.Type))
                 .ForMember(x => x.WeaponCaliber, y =>
                y.MapFrom(s => s.Weapon.Caliber))
                 .ForMember(x => x.AmmoCaliber, y =>
                y.MapFrom(s => s.Ammunition.Caliber));
        }
    }
}
