using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;

    public AppUserManager(IAppUserDal appUserDal)
    {
        _appUserDal = appUserDal;
    }

    public List<AppUser> TGetAppUsers()
    {
        return _appUserDal.GetAppUsers();
    }

    public void TDelete(AppUser t)
    {
        _appUserDal.Delete(t);
    }

    public AppUser TGetByID(int id)
    {
        return _appUserDal.GetByID(id);
    }

    public List<AppUser> TGetList()
    {
        return _appUserDal.GetList();
    }

    public void TInsert(AppUser t)
    {
        _appUserDal.Insert(t);
    }

    public void TUpdate(AppUser t)
    {
        _appUserDal.Update(t);
    }

    public List<AppUser> TGetAppUsersWithLocation()
    {
        return _appUserDal.GetAppUsersWithLocation();
    }

    public int TGetAppUserCount()
    {
        return _appUserDal.GetAppUserCount();
    }
}
