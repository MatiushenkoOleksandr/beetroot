using Service.Logic.Dto;
using Service.Repository.Abstracts;
using Service.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Logic
{

    public class ReservationService
    {
        private readonly IRepository<Guid, ReservationEntity> _repository;

        public ReservationService(IRepository<Guid, ReservationEntity> repository)
        {
            _repository = repository;
        }


        public async Task<List<ReservationEntity>> GetReservations()
        {
            return (await _repository.GetAll()).ToList();
        }

        public async Task CreateReservation(ReservationEntity entity)
        {
            await _repository.Add(entity);
        }
        public async Task DeleteReservation(Guid id)
        {
            await _repository.Delete(id);
        }
        public async Task<List<ReservationEntity>> GetFilteredReservations(ReservationFilterInputDto input)
        {
            var list = await _repository.GetAll();
            if (input.Status != null)
            {
                list = list.Where(listItem => listItem.Status == input.Status).ToList();
            }
            
            list = list.Where(listItem => input.Date == null || listItem.Date.Date == input.Date.Value.Date).ToList();
            list = list.Where(listItem => input.PaymentStatus == null || listItem.PaymentStatus == input.PaymentStatus).ToList();
            list = list.Where(listItem => input.HourFrom == null || listItem.Hour >= input.HourFrom).ToList();
            list = list.Where(listItem => input.HourTo == null || listItem.Hour <= input.HourTo).ToList();
            list = list.Where(listItem => input.CarId == null || listItem.CarId == input.CarId).ToList();

            return list.ToList();
        }
        public async Task<ReservationEntity> GetReservationById(Guid id)
        {
          var reservation = await _repository.Get(id);
            return reservation;
        }
        public async Task UpdateReservation(ReservationEntity entity)
        {
            await _repository.Update(entity);
        }


    }
}
