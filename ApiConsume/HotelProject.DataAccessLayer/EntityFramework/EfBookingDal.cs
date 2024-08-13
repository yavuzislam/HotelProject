using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework;

public class EfBookingDal : GenericRepository<Booking>, IBookingDal
{
    public EfBookingDal(Context context) : base(context)
    {
    }

    public void BookingStatusChangeApproved(BookingDto bookingDto)
    {
        var context = new Context();
        var values = context.Bookings.Where(x => x.BookingID == bookingDto.BookingID).FirstOrDefault();
        values.Status = "Onaylandı";
        context.SaveChanges();
    }

    public void BookingStatusChangeApproved2(int id)
    {
        var context = new Context();
        var values = context.Bookings.Find(id);
        values.Status = "Onaylandı";
        context.SaveChanges();
    }

    public void BookingStatusChangeApproved3(int id)
    {
        var context = new Context();
        var values = context.Bookings.Find(id);
        values.Status = "Onaylandı";
        context.SaveChanges();
    }

    public void BookingStatusChangeCancel(int id)
    {
        var context = new Context();
        var values = context.Bookings.Find(id);
        values.Status = "İptal Edildi";
        context.SaveChanges();
    }

    public void BookingStatusChangeWait(int id)
    {
        var context = new Context();
        var values = context.Bookings.Find(id);
        values.Status = "Müşteri Aranacak";
        context.SaveChanges();
    }

    public int GetBookingCount()
    {
        var context = new Context();
        return context.Bookings.Count();
    }

    public List<BookingDto> Last6Bookings()
    {
        var context = new Context();
        var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
        return values.Select(x => new BookingDto
        {
            BookingID = x.BookingID,
            Name = x.Name,
            Mail = x.Mail,
            Checkin = x.Checkin,
            CheckOut = x.CheckOut,
            AdultCount = x.AdultCount,
            ChildCount = x.ChildCount,
            RoomCount = x.RoomCount,
            SpecialRequest = x.SpecialRequest,
            Status = x.Status,
        }).ToList();
    }
}