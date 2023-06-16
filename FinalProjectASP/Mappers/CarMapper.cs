using AutoMapper;
using FinalProjectASP.Models;
using Service.Logic.Dto;
using Service.Repository.Entities;
using Servis.Repository.Entities;

namespace FinalProjectASP.Mappers
{
    public class CarMapperProfile : Profile
    {
        public CarMapperProfile()
        {
            CreateMap<CarModel, CarEntity>();
            CreateMap<CarEntity, CarModel>();
            CreateMap<CustomerModel, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerWriteModel, CustomerEntity>();
            CreateMap<ReservationFilterInputModel, ReservationFilterInputDto>().ReverseMap();
            CreateMap<ReservationEntity, ReservationModel>().ReverseMap();
            CreateMap<ReservationEntity, ReservationListModel>()
                .ForMember(a=> a.CustomerName, options => options.MapFrom(b=> b.Car.Owner.Name + b.Car.Owner.Surname))
                .ForMember(a=> a.Car, options => options.MapFrom(b=> b.Car.Brand + b.Car.Model))
                .ForMember(a=> a.CustomerPhone, options => options.MapFrom(b=> b.Car.Owner.PhoneNumber))
                ;
        }
    }
}
