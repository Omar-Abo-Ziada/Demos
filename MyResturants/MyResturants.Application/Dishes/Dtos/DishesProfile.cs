using AutoMapper;
using MyResturants.Application.Dishes.Commands.CreateDish;
using MyResturants.Domain.Entities;

namespace MyResturants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<CreateDishCommand, Dish>();

        CreateMap<Dish, DishDto>()
            .ForMember(dest => dest.KiloCalories, opt => opt.MapFrom(src => src.KiloCalories != null ? src.KiloCalories : 0));
    }
}