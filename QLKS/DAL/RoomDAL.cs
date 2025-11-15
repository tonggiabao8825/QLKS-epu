using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLKS.Models;

namespace QLKS.DAL
{
    public class RoomDAL
    {
        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM Rooms";
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                rooms.Add(MapDataRowToRoom(row));
            }
            return rooms;
        }

        public Room GetById(int id)
        {
            string query = "SELECT * FROM Rooms WHERE RoomId = @RoomId";
            SqlParameter[] parameters = { new SqlParameter("@RoomId", id) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapDataRowToRoom(dataTable.Rows[0]);
            }
            return null;
        }

        public bool Insert(Room room)
        {
            string query = @"INSERT INTO Rooms (RoomNumber, RoomTypeId, Floor, PricePerNight, 
                            Status, Description, MaxOccupancy, CreatedDate) 
                            VALUES (@RoomNumber, @RoomTypeId, @Floor, @PricePerNight, 
                            @Status, @Description, @MaxOccupancy, @CreatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@RoomNumber", room.RoomNumber),
                new SqlParameter("@RoomTypeId", room.RoomTypeId),
                new SqlParameter("@Floor", room.Floor),
                new SqlParameter("@PricePerNight", room.PricePerNight),
                new SqlParameter("@Status", room.Status),
                new SqlParameter("@Description", room.Description ?? (object)DBNull.Value),
                new SqlParameter("@MaxOccupancy", room.MaxOccupancy),
                new SqlParameter("@CreatedDate", room.CreatedDate)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(Room room)
        {
            string query = @"UPDATE Rooms SET RoomNumber = @RoomNumber, RoomTypeId = @RoomTypeId, 
                            Floor = @Floor, PricePerNight = @PricePerNight, Status = @Status, 
                            Description = @Description, MaxOccupancy = @MaxOccupancy, 
                            UpdatedDate = @UpdatedDate WHERE RoomId = @RoomId";

            SqlParameter[] parameters = {
                new SqlParameter("@RoomId", room.RoomId),
                new SqlParameter("@RoomNumber", room.RoomNumber),
                new SqlParameter("@RoomTypeId", room.RoomTypeId),
                new SqlParameter("@Floor", room.Floor),
                new SqlParameter("@PricePerNight", room.PricePerNight),
                new SqlParameter("@Status", room.Status),
                new SqlParameter("@Description", room.Description ?? (object)DBNull.Value),
                new SqlParameter("@MaxOccupancy", room.MaxOccupancy),
                new SqlParameter("@UpdatedDate", room.UpdatedDate ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Rooms WHERE RoomId = @RoomId";
            SqlParameter[] parameters = { new SqlParameter("@RoomId", id) };
            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Room> Search(string keyword)
        {
            List<Room> rooms = new List<Room>();
            string query = @"SELECT * FROM Rooms WHERE RoomNumber LIKE @Keyword 
                            OR Description LIKE @Keyword";
            SqlParameter[] parameters = { 
                new SqlParameter("@Keyword", "%" + keyword + "%") 
            };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                rooms.Add(MapDataRowToRoom(row));
            }
            return rooms;
        }

        public List<Room> GetByStatus(string status)
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM Rooms WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                rooms.Add(MapDataRowToRoom(row));
            }
            return rooms;
        }

        private Room MapDataRowToRoom(DataRow row)
        {
            return new Room
            {
                RoomId = Convert.ToInt32(row["RoomId"]),
                RoomNumber = row["RoomNumber"].ToString(),
                RoomTypeId = Convert.ToInt32(row["RoomTypeId"]),
                Floor = Convert.ToInt32(row["Floor"]),
                PricePerNight = Convert.ToDecimal(row["PricePerNight"]),
                Status = row["Status"].ToString(),
                Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : null,
                MaxOccupancy = Convert.ToInt32(row["MaxOccupancy"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                UpdatedDate = row["UpdatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedDate"]) : null
            };
        }
    }
}
