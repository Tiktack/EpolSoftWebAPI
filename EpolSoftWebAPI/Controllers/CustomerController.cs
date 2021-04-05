using System.Threading.Tasks;
using AutoMapper;
using EpolSoft.BusinessLayer.Entities;
using EpolSoft.BusinessLayer.Services;
using EpolSoft.BusinessLayer.Services.Interfaces;
using EpolSoft.WebAPI.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace EpolSoft.WebAPI.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("api/Customer/CreateCustomer")]
        public async Task<CustomerResponse> CreateCustomer([FromBody] CreateCustomer request)
        {
            var result = await _customerService.Add(_mapper.Map<Customer>(request));

            return _mapper.Map<CustomerResponse>(result);
        }

        [HttpPost("api/Customer/UpdateCustomer")]
        public async Task<CustomerResponse> UpdateCustomer([FromBody] UpdateCustomer request)
        {
            var result = await _customerService.UpdateOptional(_mapper.Map<Customer>(request));

            return _mapper.Map<CustomerResponse>(result);
        }
    }
}
