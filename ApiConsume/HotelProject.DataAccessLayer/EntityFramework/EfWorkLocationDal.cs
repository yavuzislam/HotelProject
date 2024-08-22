using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfWorkLocationDal : GenericRepository<WorkLocation>, IWorkLocationDal
{
    public EfWorkLocationDal(Context context) : base(context)
    {
    }

    //public List<WorkLocation> GetWorkLocationsWithAppUsers()
    //{
    //    var context = new Context();
    //    return context.WorkLocations.Include(x => x.AppUsers).ToList();
    //}
}
