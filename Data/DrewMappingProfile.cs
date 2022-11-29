using AutoMapper;
using GameDrewTotal.Data.Entities;
using GameDrewTotal.ViewModels;

namespace GameDrewTotal.Data
{
    public class DrewMappingProfile : Profile
    {
        public DrewMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
              .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
              .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
              .ReverseMap()
              .ForMember(m => m.Product, opt => opt.Ignore());
        }
    }
}
