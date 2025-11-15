using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLKS.Models;

namespace QLKS.DAL
{
    public class ServiceDAL
    {
        public List<Service> GetAll()
        {
            List<Service> services = new List<Service>();
            string query = "SELECT * FROM Services";
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                services.Add(MapDataRowToService(row));
            }
            return services;
        }

        public Service GetById(int id)
        {
            string query = "SELECT * FROM Services WHERE ServiceId = @ServiceId";
            SqlParameter[] parameters = { new SqlParameter("@ServiceId", id) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapDataRowToService(dataTable.Rows[0]);
            }
            return null;
        }

        public bool Insert(Service service)
        {
            string query = @"INSERT INTO Services (ServiceName, Description, Price, Category, 
                            IsAvailable, CreatedDate) 
                            VALUES (@ServiceName, @Description, @Price, @Category, 
                            @IsAvailable, @CreatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@ServiceName", service.ServiceName),
                new SqlParameter("@Description", service.Description ?? (object)DBNull.Value),
                new SqlParameter("@Price", service.Price),
                new SqlParameter("@Category", service.Category),
                new SqlParameter("@IsAvailable", service.IsAvailable),
                new SqlParameter("@CreatedDate", service.CreatedDate)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(Service service)
        {
            string query = @"UPDATE Services SET ServiceName = @ServiceName, Description = @Description, 
                            Price = @Price, Category = @Category, IsAvailable = @IsAvailable, 
                            UpdatedDate = @UpdatedDate WHERE ServiceId = @ServiceId";

            SqlParameter[] parameters = {
                new SqlParameter("@ServiceId", service.ServiceId),
                new SqlParameter("@ServiceName", service.ServiceName),
                new SqlParameter("@Description", service.Description ?? (object)DBNull.Value),
                new SqlParameter("@Price", service.Price),
                new SqlParameter("@Category", service.Category),
                new SqlParameter("@IsAvailable", service.IsAvailable),
                new SqlParameter("@UpdatedDate", service.UpdatedDate ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Services WHERE ServiceId = @ServiceId";
            SqlParameter[] parameters = { new SqlParameter("@ServiceId", id) };
            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Service> GetByCategory(string category)
        {
            List<Service> services = new List<Service>();
            string query = "SELECT * FROM Services WHERE Category = @Category";
            SqlParameter[] parameters = { new SqlParameter("@Category", category) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                services.Add(MapDataRowToService(row));
            }
            return services;
        }

        private Service MapDataRowToService(DataRow row)
        {
            return new Service
            {
                ServiceId = Convert.ToInt32(row["ServiceId"]),
                ServiceName = row["ServiceName"].ToString(),
                Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : null,
                Price = Convert.ToDecimal(row["Price"]),
                Category = row["Category"].ToString(),
                IsAvailable = Convert.ToBoolean(row["IsAvailable"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                UpdatedDate = row["UpdatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedDate"]) : null
            };
        }
    }
}
