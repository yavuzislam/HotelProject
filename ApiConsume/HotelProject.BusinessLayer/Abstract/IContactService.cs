using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IContactService : IGenericService<Contact>
{
    public int TGetContactCount();
    public Contact TGetContactByCategory(int id);
}
