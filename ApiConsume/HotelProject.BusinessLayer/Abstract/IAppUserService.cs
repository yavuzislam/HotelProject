using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IAppUserService : IGenericService<AppUser>
{
    List<AppUser> TGetAppUsers();
    List<AppUser> TGetAppUsersWithLocation();
    int TGetAppUserCount();
}
