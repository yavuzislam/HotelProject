using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<CreateRoomDto, Room>().ReverseMap();
    }
}
