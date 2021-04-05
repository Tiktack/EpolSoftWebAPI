using AutoMapper;
using EpolSoft.BusinessLayer.Entities;
using EpolSoft.WebAPI.DTOs.Customer;

namespace EpolSoft.WebAPI.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CreateCustomer, Customer>();
            CreateMap<UpdateCustomer, Customer>()
                .ForMember(x => x.Id, dest => dest.MapFrom(y => y.CustomerNumber));

            CreateMap<Customer, CustomerResponse>()
                .ForMember(x => x.CustomerNumber, dest => dest.MapFrom(y => y.Id))
                .ForMember(x => x.Success, dest => dest.MapFrom(y => true));

        }
    }
}
