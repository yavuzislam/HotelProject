﻿using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IBookingService : IGenericService<Booking>
{
    void TBookingStatusChangeApproved(BookingDto bookingDto);
    void TBookingStatusChangeApproved2(int id);
    int TGetBookingCount();
    List<BookingDto> TLast6Bookings();
    void TBookingStatusChangeApproved3(int id);
    void TBookingStatusChangeCancel(int id);
    void TBookingStatusChangeWait(int id);
}
