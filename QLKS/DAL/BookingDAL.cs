using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLKS.Models;

namespace QLKS.DAL
{
    public class BookingDAL
    {
        public List<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings";
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                bookings.Add(MapDataRowToBooking(row));
            }
            return bookings;
        }

        public Booking GetById(int id)
        {
            string query = "SELECT * FROM Bookings WHERE BookingId = @BookingId";
            SqlParameter[] parameters = { new SqlParameter("@BookingId", id) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapDataRowToBooking(dataTable.Rows[0]);
            }
            return null;
        }

        public bool Insert(Booking booking)
        {
            string query = @"INSERT INTO Bookings (CustomerId, RoomId, CheckInDate, CheckOutDate, 
                            NumberOfGuests, TotalAmount, Deposit, Status, SpecialRequests, CreatedDate) 
                            VALUES (@CustomerId, @RoomId, @CheckInDate, @CheckOutDate, 
                            @NumberOfGuests, @TotalAmount, @Deposit, @Status, @SpecialRequests, @CreatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@CustomerId", booking.CustomerId),
                new SqlParameter("@RoomId", booking.RoomId),
                new SqlParameter("@CheckInDate", booking.CheckInDate),
                new SqlParameter("@CheckOutDate", booking.CheckOutDate),
                new SqlParameter("@NumberOfGuests", booking.NumberOfGuests),
                new SqlParameter("@TotalAmount", booking.TotalAmount),
                new SqlParameter("@Deposit", booking.Deposit),
                new SqlParameter("@Status", booking.Status),
                new SqlParameter("@SpecialRequests", booking.SpecialRequests ?? (object)DBNull.Value),
                new SqlParameter("@CreatedDate", booking.CreatedDate)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(Booking booking)
        {
            string query = @"UPDATE Bookings SET CustomerId = @CustomerId, RoomId = @RoomId, 
                            CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, 
                            ActualCheckInDate = @ActualCheckInDate, ActualCheckOutDate = @ActualCheckOutDate,
                            NumberOfGuests = @NumberOfGuests, TotalAmount = @TotalAmount, Deposit = @Deposit, 
                            Status = @Status, SpecialRequests = @SpecialRequests, UpdatedDate = @UpdatedDate 
                            WHERE BookingId = @BookingId";

            SqlParameter[] parameters = {
                new SqlParameter("@BookingId", booking.BookingId),
                new SqlParameter("@CustomerId", booking.CustomerId),
                new SqlParameter("@RoomId", booking.RoomId),
                new SqlParameter("@CheckInDate", booking.CheckInDate),
                new SqlParameter("@CheckOutDate", booking.CheckOutDate),
                new SqlParameter("@ActualCheckInDate", booking.ActualCheckInDate ?? (object)DBNull.Value),
                new SqlParameter("@ActualCheckOutDate", booking.ActualCheckOutDate ?? (object)DBNull.Value),
                new SqlParameter("@NumberOfGuests", booking.NumberOfGuests),
                new SqlParameter("@TotalAmount", booking.TotalAmount),
                new SqlParameter("@Deposit", booking.Deposit),
                new SqlParameter("@Status", booking.Status),
                new SqlParameter("@SpecialRequests", booking.SpecialRequests ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", booking.UpdatedDate ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Bookings WHERE BookingId = @BookingId";
            SqlParameter[] parameters = { new SqlParameter("@BookingId", id) };
            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Booking> GetByCustomerId(int customerId)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings WHERE CustomerId = @CustomerId";
            SqlParameter[] parameters = { new SqlParameter("@CustomerId", customerId) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                bookings.Add(MapDataRowToBooking(row));
            }
            return bookings;
        }

        public List<Booking> GetByStatus(string status)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                bookings.Add(MapDataRowToBooking(row));
            }
            return bookings;
        }

        private Booking MapDataRowToBooking(DataRow row)
        {
            return new Booking
            {
                BookingId = Convert.ToInt32(row["BookingId"]),
                CustomerId = Convert.ToInt32(row["CustomerId"]),
                RoomId = Convert.ToInt32(row["RoomId"]),
                CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                ActualCheckInDate = row["ActualCheckInDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ActualCheckInDate"]) : null,
                ActualCheckOutDate = row["ActualCheckOutDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ActualCheckOutDate"]) : null,
                NumberOfGuests = Convert.ToInt32(row["NumberOfGuests"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                Deposit = Convert.ToDecimal(row["Deposit"]),
                Status = row["Status"].ToString(),
                SpecialRequests = row["SpecialRequests"] != DBNull.Value ? row["SpecialRequests"].ToString() : null,
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                UpdatedDate = row["UpdatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedDate"]) : null
            };
        }
    }
}
