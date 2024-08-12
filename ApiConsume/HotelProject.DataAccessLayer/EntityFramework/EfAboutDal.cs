using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfAboutDal : GenericRepository<About>, IAboutDal
{
    public EfAboutDal(Context context) : base(context)
    {
    }

    public About GetLastAbout()
    {
        var context = new Context();
        return context.Abouts.OrderByDescending(x => x.AboutID).FirstOrDefault();
    }
}
