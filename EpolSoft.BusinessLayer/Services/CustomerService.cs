using System;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EpolSoft.BusinessLayer.Entities;
using EpolSoft.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace EpolSoft.BusinessLayer.Services
{
    /// <inheritdoc/>
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IImmutableList<Customer> GetAll() => _unitOfWork.CustomerRepository.Get().ProjectTo<Customer>(_mapper.ConfigurationProvider).ToImmutableList();

        /// <inheritdoc/>
        public async Task<Customer> Add(Customer customer)
        {
            var mappedCustomer = _mapper.Map<DataAccessLayer.Model.Customer>(customer);

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: mappedCustomer.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            mappedCustomer.Password = hash;
            mappedCustomer.Salt = Convert.ToBase64String(salt);

            var entity = _unitOfWork.CustomerRepository.Add(mappedCustomer);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<Customer>(entity);
        }

        /// <inheritdoc/>
        public async Task<Customer> Update(Customer customer)
        {
            var mappedCustomer = _mapper.Map<DataAccessLayer.Model.Customer>(customer);

            var entity = _unitOfWork.CustomerRepository.Update(mappedCustomer);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<Customer>(entity);
        }

        /// <inheritdoc/>
        public async Task<Customer> UpdateOptional(Customer customer)
        {
            var dbUser = await _unitOfWork.CustomerRepository.Get().AsNoTracking().FirstOrDefaultAsync(x => x.Id == customer.Id);

            dbUser.Address1 = customer.Address1 ?? dbUser.Address1;
            dbUser.EmailAddress = customer.EmailAddress ?? dbUser.EmailAddress;
            dbUser.FirstNames = customer.FirstNames ?? dbUser.FirstNames;
            dbUser.PhoneNumber1 = customer.PhoneNumber1 ?? dbUser.PhoneNumber1;
            dbUser.Town = customer.Town ?? dbUser.Town;
            dbUser.Postcode = customer.Postcode ?? dbUser.Postcode;

            var entity = _unitOfWork.CustomerRepository.Update(dbUser);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<Customer>(entity);
        }
    }
}
