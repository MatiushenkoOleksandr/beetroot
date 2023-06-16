using Service.Repository.Abstracts;
using Service.Repository.Entities;
using Servis.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Logic
{
    public class CustomerService
    {

        private readonly IRepository<Guid, CustomerEntity> _repository;
        public CustomerService(IRepository<Guid, CustomerEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerEntity>> GetCustomers()
        {
            return (await _repository.GetAll()).ToList();
        }

        public async Task CreateCustomer(CustomerEntity entity)
        {
            await _repository.Add(entity);
        }
        public async Task DeleteCustome(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}
