using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfStaffDal : GenericRepository<Staff>, IStaffDal
{
    public EfStaffDal(Context context) : base(context)
    {
    }

    public List<ResultLast4StaffDto> GetLast4Staff()
    {
        var context = new Context();
        var values = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).Select(x => new ResultLast4StaffDto
        {
            StaffID = x.StaffID,
            Name = x.Name,
            Title = x.Title,
            SocialMedia1 = x.SocialMedia1,
            SocialMedia2 = x.SocialMedia2,
            SocialMedia3 = x.SocialMedia3
        }).ToList();
        return values;
    }

    public int GetStaffCount()
    {
        var context = new Context();
        return context.Staffs.Count();
    }
}