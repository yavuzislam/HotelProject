using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class SubscribeManager : ISubscribeService
{
    private readonly ISubscribeDal _SubscribeDal;

    public SubscribeManager(ISubscribeDal SubscribeDal)
    {
        _SubscribeDal = SubscribeDal;
    }

    public void TDelete(Subscribe t)
    {
        _SubscribeDal.Delete(t);
    }

    public Subscribe TGetByID(int id)
    {
        return _SubscribeDal.GetByID(id);
    }

    public List<Subscribe> TGetList()
    {
        return _SubscribeDal.GetList();
    }

    public void TInsert(Subscribe t)
    {
        _SubscribeDal.Insert(t);
    }

    public void TUpdate(Subscribe t)
    {
        _SubscribeDal.Update(t);
    }
}
