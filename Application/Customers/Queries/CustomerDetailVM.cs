using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Customers.Queries
{
    public class CustomerDetailVm : IMapFrom<Customer>
    {
        public long CustomerId { get; set; }
        public short Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailVm>()
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
