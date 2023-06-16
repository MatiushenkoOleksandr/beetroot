using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Service.Repo;
using Service.Repository.Abstracts;
using Servis.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class CarRepository : IRepository<Guid, CarEntity>
    {
        private readonly ServiseDbContext _context;
        public CarRepository(ServiseDbContext context)
        {
            _context = context;
        }
        public async Task Add(CarEntity entity)
        {
            _context.Cars.Add(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<CarEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var carEntity = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (carEntity != null)
            {
                _context.Cars.Remove(carEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async  Task<CarEntity> Get(Guid key)
        {
            var carFromDatabase = await _context.Cars.FirstAsync(a => a.Id == key);
            return carFromDatabase;
        }

        public async Task<IEnumerable<CarEntity>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public Task<IEnumerable<CarEntity>> GetRange(IEnumerable<Guid> keys)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CarEntity entity)
        {
            var carEntity = _context.Cars.FirstOrDefault(a=> a.Id == entity.Id);
            if (carEntity == null)
            {
                return;
            }
            carEntity.Vin = entity.Vin;
            carEntity.Brand = entity.Brand;
            carEntity.Model = entity.Model;
            carEntity.FuelType = entity.FuelType;
            carEntity.Milage = entity.Milage;
            carEntity.Year = entity.Year;
            _context.Update(carEntity);
            await _context.SaveChangesAsync();
        }
    }
}
