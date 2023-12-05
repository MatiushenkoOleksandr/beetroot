using AutoMapper;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Logic;
using Service.Repository.Entities;
using Servis.Repository.Entities;
using System.Data;
using System.Formats.Asn1;

namespace FinalProjectASP.Controllers

{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly CarService _carService;

        public CustomerController(CustomerService customerService, IMapper mapper, CarService carService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet(Name = "GetAllCustomer")]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            var customers = await _customerService.GetCustomers();
            var customersModels = _mapper.Map<IEnumerable<CustomerModel>>(customers);
            return customersModels;
        }

        [HttpPost]
        public async Task CreateCustomer(CustomerWriteModel model)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(model);
            await _customerService.CreateCustomer(customerEntity);
        }

        [HttpGet]
        [Route("{id}/cars")]
        public async Task<IEnumerable<CarModel>> GetCustomersCars(Guid id)
        {
            var cars = await _carService.GetCarsByCustomerId(id);
            var customerCars = _mapper.Map<IEnumerable<CarModel>>(cars);
            return customerCars;
                
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustome(id);
        }

    }
}
