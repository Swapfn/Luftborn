using AutoMapper;
using Models.Models;

namespace Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDTO>().ReverseMap();
            CreateMap<StoreItem, StoreItemDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDTO>().ReverseMap();
        }
    }
}
