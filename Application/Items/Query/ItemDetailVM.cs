using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Items.Query
{
    public class ItemDetailVM : IMapFrom<Item>
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDetailVM>()
                .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
