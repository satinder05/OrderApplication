using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Order.Queries
{
    public class OrderDetailVM : IMapFrom<CustomerOrder>
    {
        public long OrderId { get; set; }

        public short Status { get; set; }
        public long CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerOrder, OrderDetailVM>()
                .ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.OrderItems, opt => opt.MapFrom(s => s.OrderItems));
        }
    }
}
