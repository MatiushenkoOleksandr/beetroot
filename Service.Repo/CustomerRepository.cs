using Microsoft.EntityFrameworkCore;
using Service.Repo;
using Service.Repository.Abstracts;
using Service.Repository.Entities;
using Servis.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class CustomerRepository : IRepository<Guid, CustomerEntity>
    {
        private readonly ServiseDbContext _context;
        public CustomerRepository(ServiseDbContext context)
        {

            _context = context;
        }
        public async Task Add(CustomerEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<CustomerEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(a => a.Id == id);
             _context.Customers.Remove(customer);
           await _context.SaveChangesAsync() ;

        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await _context.Customers.Include(a => a.Cars).ToListAsync();

        }
        public Task Update(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<CustomerEntity> IRepository<Guid, CustomerEntity>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
