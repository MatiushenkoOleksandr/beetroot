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
    public class ReservationRepository : IRepository<Guid, ReservationEntity>
    {
        private readonly ServiseDbContext _context;
        public ReservationRepository(ServiseDbContext context)
        {

            _context = context;
        }

        public async Task Add(ReservationEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<ReservationEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var reservation = _context.Reservations.FirstOrDefault(a => a.Id == id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

        }

        public async Task<ReservationEntity> Get(Guid key)
        {
            var reservationFromDatabase = await _context.Reservations.FirstAsync(a => a.Id == key);
            return reservationFromDatabase;
        }

        public async Task<IEnumerable<ReservationEntity>> GetAll()
        {
            return await _context.Reservations.Include(a=>a.Car).ThenInclude(b=>b.Owner).ToListAsync();
        }

        public Task<IEnumerable<ReservationEntity>> GetRange(IEnumerable<Guid> keys)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ReservationEntity entity)
        {
            var reservationEntity = _context.Reservations.FirstOrDefault(a => a.Id == entity.Id);
            if (reservationEntity == null)
            {
                return;
            }
            reservationEntity.Price = entity.Price;
            reservationEntity.Status = entity.Status;
            reservationEntity.Hour = entity.Hour;
            reservationEntity.Date = entity.Date;
            reservationEntity.PaymentStatus = entity.PaymentStatus;
            reservationEntity.Car = entity.Car;
            reservationEntity.PrepaidAmount = entity.PrepaidAmount;
            _context.Reservations.Update(reservationEntity);
            await _context.SaveChangesAsync();
        }
    }
}
