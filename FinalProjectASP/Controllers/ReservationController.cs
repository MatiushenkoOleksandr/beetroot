using AutoMapper;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Logic;
using Service.Logic.Dto;
using Service.Repository.Entities;
using Servis.Repository.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Net;

namespace FinalProjectASP.Controllers

{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ReservationService _reservationService;

        public ReservationController(IMapper mapper, ReservationService reservationService)
        {
            _mapper = mapper;
            _reservationService = reservationService;
        }

        //[SwaggerOperation("GetReservations")]
        //[SwaggerResponse((int)HttpStatusCode.OK)]
        //[HttpGet(Name = "GetAllReservation")]
        //public async Task<IEnumerable<ReservationListModel>> Get()
        //{
        //    var reservations = await _reservationService.GetReservations();
        //    var reservationModels = _mapper.Map<IEnumerable<ReservationListModel>>(reservations);
        //    return reservationModels;
        //}
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateReservation(ReservationModel model)
        {
            var reservationEntity = _mapper.Map<ReservationEntity>(model);
            await _reservationService.CreateReservation(reservationEntity);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteReservation(Guid id)
        {
            await _reservationService.DeleteReservation(id);
        }


        [HttpGet(Name = "GetFilteredReservations")]
        [SwaggerOperation("GetFilteredReservations")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ReservationListModel>> GetFilteredReservations([FromQuery]ReservationFilterInputModel filter)
        {
           var dto = _mapper.Map<ReservationFilterInputDto>(filter);
           var reservationEntity = await _reservationService.GetFilteredReservations(dto);
            return _mapper.Map<IEnumerable<ReservationListModel>>(reservationEntity);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ReservationModel> GetReservation(Guid id)
        {   
            var reservation = await _reservationService.GetReservationById(id);
            var mapedReservation = _mapper.Map<ReservationModel>(reservation);
            return mapedReservation;

        }
        [Authorize(Roles = "Admin")]
        [HttpPut] 
        public async Task UpdateReservation(ReservationModel model)
        {
            var reservationEntity = _mapper.Map<ReservationEntity>(model);
            await _reservationService.UpdateReservation(reservationEntity);
        }

    }
}
