using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract;

public interface IStaffDal : IGenericDal<Staff>
{
    List<ResultLast4StaffDto> GetLast4Staff();
    int GetStaffCount();
}
