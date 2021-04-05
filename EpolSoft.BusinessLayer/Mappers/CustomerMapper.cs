using AutoMapper;
using EpolSoft.BusinessLayer.Entities;

namespace EpolSoft.BusinessLayer.Mappers
{
    internal class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, DataAccessLayer.Model.Customer>();
            CreateMap<DataAccessLayer.Model.Customer, Customer>();
        }
    }
}
