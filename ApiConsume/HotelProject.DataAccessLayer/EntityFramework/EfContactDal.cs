using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfContactDal : GenericRepository<Contact>, IContactDal
{
    public EfContactDal(Context context) : base(context)
    {
    }

    public Contact GetContactByCategory(int id)
    {
       var context = new Context();
        return context.Contacts.Include(x=>x.MessageCategory).FirstOrDefault(x => x.ContactID == id);
    }

    public int GetContactCount()
    {
        var context = new Context();
        return context.Contacts.Count();
    }
}
