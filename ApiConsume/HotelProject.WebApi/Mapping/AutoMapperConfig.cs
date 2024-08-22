using AutoMapper;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.DtoLayer.Dtos.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<CreateRoomDto, Room>().ReverseMap();

        CreateMap<Guest, GuestDto>().ReverseMap();
        CreateMap<CreateGuestDto, Guest>().ReverseMap();

        CreateMap<SendMessage, SendMessageDto>().ReverseMap();
        CreateMap<CreateSendMessageDto, SendMessage>().ReverseMap();

        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<CreateContactDto, Contact>().ReverseMap();

        CreateMap<WorkLocation, WorkLocationDto>().ReverseMap();
        CreateMap<CreateWorkLocationDto, WorkLocation>().ReverseMap();
    }
}
