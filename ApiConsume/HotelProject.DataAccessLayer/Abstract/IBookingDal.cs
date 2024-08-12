using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract;

public interface IBookingDal : IGenericDal<Booking>
{
    void BookingStatusChangeApproved(BookingDto bookingDto);
    void BookingStatusChangeApproved2(int id);
    int GetBookingCount();
    List<BookingDto> Last6Bookings();
    void BookingStatusChangeApproved3(int id);
    void BookingStatusChangeCancel(int id);
    void BookingStatusChangeWait(int id);
}
