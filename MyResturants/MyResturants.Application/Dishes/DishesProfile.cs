using AutoMapper;
using MyResturants.Domain.Entities;

namespace MyResturants.Application.Dishes;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>()
            .ForMember(dest => dest.KiloCalories, opt => opt.MapFrom(src => src.KiloCalories != null ? src.KiloCalories : 0));
    }
}
