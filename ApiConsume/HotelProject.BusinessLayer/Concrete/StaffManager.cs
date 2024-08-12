using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class StaffManager : IStaffService
{
    private readonly IStaffDal _StaffDal;

    public StaffManager(IStaffDal StaffDal)
    {
        _StaffDal = StaffDal;
    }

    public List<ResultLast4StaffDto> GetLast4Staff()
    {
        return _StaffDal.GetLast4Staff();
    }

    public void TDelete(Staff t)
    {
        _StaffDal.Delete(t);
    }

    public Staff TGetByID(int id)
    {
        return _StaffDal.GetByID(id);
    }

    public List<Staff> TGetList()
    {
        return _StaffDal.GetList();
    }

    public void TInsert(Staff t)
    {
        _StaffDal.Insert(t);
    }

    public void TUpdate(Staff t)
    {
        _StaffDal.Update(t);
    }
}
