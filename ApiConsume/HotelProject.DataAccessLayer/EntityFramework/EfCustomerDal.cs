using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
{
    public EfCustomerDal(Context context) : base(context)
    {
    }
}
