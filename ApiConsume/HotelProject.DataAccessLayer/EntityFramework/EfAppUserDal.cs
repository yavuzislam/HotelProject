using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
{
    private readonly UserManager<AppUser> _userManager;
    public EfAppUserDal(Context context, UserManager<AppUser> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public int GetAppUserCount()
    {
        return _userManager.Users.Count();
    }

    public List<AppUser> GetAppUsers()
    {
        return _userManager.Users.ToList();
    }

    public List<AppUser> GetAppUsersWithLocation()
    {
        return _userManager.Users.Include(x => x.WorkLocation).ToList();
    }
}
