using Microsoft.EntityFrameworkCore;
using Service.Repo;
using Service.Repository.Abstracts;
using Servis.Repository.Entities;

namespace Service.Logic
{
    public class CarService
    {
        private readonly IRepository<Guid, CarEntity> _repository;
        public CarService(IRepository<Guid, CarEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<CarEntity>> GetCars()
        {
            return (await _repository.GetAll()).ToList();
        }

        public async Task CreateCar(CarEntity entity)
        {
            await _repository.Add(entity);
        }
        public async Task<List<CarEntity>> GetCarsByCustomerId(Guid id)
        {
            return(await _repository.GetAll()).Where(a=>a.ClientId==id).ToList();
        }
        public async Task DeleteCar(Guid id)
        {
            await _repository.Delete(id);
        }
        public async Task UpdateCar(CarEntity entity)
        {
            await _repository.Update(entity);
        }
        public async Task<CarEntity> GetCarById(Guid id)
        {
            var carFromRepository = await _repository.Get(id);
            return carFromRepository;
        }
    }
}