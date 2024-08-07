using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _AboutDal;

    public AboutManager(IAboutDal AboutDal)
    {
        _AboutDal = AboutDal;
    }

    public void TDelete(About t)
    {
        _AboutDal.Delete(t);
    }

    public About TGetByID(int id)
    {
        return _AboutDal.GetByID(id);
    }

    public List<About> TGetList()
    {
        return _AboutDal.GetList();
    }

    public void TInsert(About t)
    {
        _AboutDal.Insert(t);
    }

    public void TUpdate(About t)
    {
        _AboutDal.Update(t);
    }
}
