using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
{
    public EfSubscribeDal(Context context) : base(context)
    {
    }

    public int GetSubscribeCount()
    {
        var context = new Context();
        return context.Subscribes.Count();
    }
}