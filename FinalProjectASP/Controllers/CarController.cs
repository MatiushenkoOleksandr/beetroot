using AutoMapper;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Service.Logic;
using Servis.Repository.Entities;

namespace FinalProjectASP.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly CarService _carService;
        private readonly IMapper _mapper;

        public CarController(ILogger<CarController> logger, CarService carService, IMapper mapper)
        {
            _logger = logger;
            _carService = carService;
            _mapper = mapper;
        }

        
        [HttpGet(Name = "GetAllCars")]
        public async Task<IEnumerable<CarModel>> Get()
        {
            var model = _mapper.Map<List<CarModel>>(await _carService.GetCars());
            return model;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateCar(CarModel model)
        {
            var carEntity = _mapper.Map<CarEntity>(model);
            await _carService.CreateCar(carEntity);
        }
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        [HttpDelete]
        public async Task DeleteCar(Guid id)
        {
            await _carService.DeleteCar(id);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task UpdateCar(CarModel model)
        {
            var carEntity = _mapper.Map<CarEntity>(model);
            await _carService.UpdateCar(carEntity);

        }
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<CarModel>GetCarById(Guid id)
        {
            var a = await _carService.GetCarById(id);
            var mappedToModel = _mapper.Map<CarModel>(a);
            return mappedToModel;
        }
    }

}   