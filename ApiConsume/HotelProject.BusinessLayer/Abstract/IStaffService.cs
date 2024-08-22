using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IStaffService : IGenericService<Staff>
{
    List<ResultLast4StaffDto> TGetLast4Staff();
    int TGetStaffCount();
}
