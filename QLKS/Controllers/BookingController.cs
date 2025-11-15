using System;
using System.Collections.Generic;
using QLKS.Models;
using QLKS.DAL;

namespace QLKS.Controllers
{
    public class BookingController
    {
        private BookingDAL bookingDAL;
        private RoomDAL roomDAL;

        public BookingController()
        {
            bookingDAL = new BookingDAL();
            roomDAL = new RoomDAL();
        }

        public List<Booking> GetAllBookings()
        {
            return bookingDAL.GetAll();
        }

        public Booking GetBookingById(int id)
        {
            return bookingDAL.GetById(id);
        }

        public bool CreateBooking(Booking booking)
        {
            // Validate dữ liệu
            if (booking.CheckInDate >= booking.CheckOutDate)
            {
                throw new Exception("Ngày nhận phòng phải trước ngày trả phòng");
            }

            // Kiểm tra phòng có sẵn không
            Room room = roomDAL.GetById(booking.RoomId);
            if (room == null)
            {
                throw new Exception("Phòng không tồn tại");
            }

            if (room.Status != "Available")
            {
                throw new Exception("Phòng hiện không khả dụng");
            }

            // Tính tổng tiền
            int numberOfDays = (booking.CheckOutDate - booking.CheckInDate).Days;
            booking.TotalAmount = room.PricePerNight * numberOfDays;
            booking.CreatedDate = DateTime.Now;
            booking.Status = "Confirmed";

            return bookingDAL.Insert(booking);
        }

        public bool UpdateBooking(Booking booking)
        {
            booking.UpdatedDate = DateTime.Now;
            return bookingDAL.Update(booking);
        }

        public bool CancelBooking(int id)
        {
            Booking booking = bookingDAL.GetById(id);
            if (booking == null)
            {
                throw new Exception("Đặt phòng không tồn tại");
            }

            booking.Status = "Cancelled";
            booking.UpdatedDate = DateTime.Now;
            return bookingDAL.Update(booking);
        }

        public bool CheckIn(int bookingId)
        {
            Booking booking = bookingDAL.GetById(bookingId);
            if (booking == null)
            {
                throw new Exception("Đặt phòng không tồn tại");
            }

            booking.ActualCheckInDate = DateTime.Now;
            booking.Status = "CheckedIn";
            booking.UpdatedDate = DateTime.Now;

            // Cập nhật trạng thái phòng
            Room room = roomDAL.GetById(booking.RoomId);
            room.Status = "Occupied";
            roomDAL.Update(room);

            return bookingDAL.Update(booking);
        }

        public bool CheckOut(int bookingId)
        {
            Booking booking = bookingDAL.GetById(bookingId);
            if (booking == null)
            {
                throw new Exception("Đặt phòng không tồn tại");
            }

            booking.ActualCheckOutDate = DateTime.Now;
            booking.Status = "CheckedOut";
            booking.UpdatedDate = DateTime.Now;

            // Cập nhật trạng thái phòng
            Room room = roomDAL.GetById(booking.RoomId);
            room.Status = "Available";
            roomDAL.Update(room);

            return bookingDAL.Update(booking);
        }

        public List<Booking> GetBookingsByCustomer(int customerId)
        {
            return bookingDAL.GetByCustomerId(customerId);
        }

        public List<Booking> GetBookingsByStatus(string status)
        {
            return bookingDAL.GetByStatus(status);
        }
    }
}
