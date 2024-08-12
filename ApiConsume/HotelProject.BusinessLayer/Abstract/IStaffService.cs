using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IStaffService : IGenericService<Staff>
{
    List<ResultLast4StaffDto> GetLast4Staff();
}
