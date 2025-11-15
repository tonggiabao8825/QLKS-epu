using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLKS.Models;

namespace QLKS.DAL
{
    public class CustomerDAL
    {
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customers";
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapDataRowToCustomer(row));
            }
            return customers;
        }

        public Customer GetById(int id)
        {
            string query = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
            SqlParameter[] parameters = { new SqlParameter("@CustomerId", id) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapDataRowToCustomer(dataTable.Rows[0]);
            }
            return null;
        }

        public bool Insert(Customer customer)
        {
            string query = @"INSERT INTO Customers (FullName, IdentityCard, PhoneNumber, Email, 
                            Address, DateOfBirth, Gender, Nationality, CreatedDate) 
                            VALUES (@FullName, @IdentityCard, @PhoneNumber, @Email, 
                            @Address, @DateOfBirth, @Gender, @Nationality, @CreatedDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@FullName", customer.FullName),
                new SqlParameter("@IdentityCard", customer.IdentityCard),
                new SqlParameter("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@Email", customer.Email ?? (object)DBNull.Value),
                new SqlParameter("@Address", customer.Address ?? (object)DBNull.Value),
                new SqlParameter("@DateOfBirth", customer.DateOfBirth ?? (object)DBNull.Value),
                new SqlParameter("@Gender", customer.Gender ?? (object)DBNull.Value),
                new SqlParameter("@Nationality", customer.Nationality ?? (object)DBNull.Value),
                new SqlParameter("@CreatedDate", customer.CreatedDate)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(Customer customer)
        {
            string query = @"UPDATE Customers SET FullName = @FullName, IdentityCard = @IdentityCard, 
                            PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address, 
                            DateOfBirth = @DateOfBirth, Gender = @Gender, Nationality = @Nationality, 
                            UpdatedDate = @UpdatedDate WHERE CustomerId = @CustomerId";

            SqlParameter[] parameters = {
                new SqlParameter("@CustomerId", customer.CustomerId),
                new SqlParameter("@FullName", customer.FullName),
                new SqlParameter("@IdentityCard", customer.IdentityCard),
                new SqlParameter("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@Email", customer.Email ?? (object)DBNull.Value),
                new SqlParameter("@Address", customer.Address ?? (object)DBNull.Value),
                new SqlParameter("@DateOfBirth", customer.DateOfBirth ?? (object)DBNull.Value),
                new SqlParameter("@Gender", customer.Gender ?? (object)DBNull.Value),
                new SqlParameter("@Nationality", customer.Nationality ?? (object)DBNull.Value),
                new SqlParameter("@UpdatedDate", customer.UpdatedDate ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
            SqlParameter[] parameters = { new SqlParameter("@CustomerId", id) };
            return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Customer> Search(string keyword)
        {
            List<Customer> customers = new List<Customer>();
            string query = @"SELECT * FROM Customers WHERE FullName LIKE @Keyword 
                            OR IdentityCard LIKE @Keyword OR PhoneNumber LIKE @Keyword";
            SqlParameter[] parameters = { 
                new SqlParameter("@Keyword", "%" + keyword + "%") 
            };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(MapDataRowToCustomer(row));
            }
            return customers;
        }

        public Customer GetByIdentityCard(string identityCard)
        {
            string query = "SELECT * FROM Customers WHERE IdentityCard = @IdentityCard";
            SqlParameter[] parameters = { new SqlParameter("@IdentityCard", identityCard) };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return MapDataRowToCustomer(dataTable.Rows[0]);
            }
            return null;
        }

        private Customer MapDataRowToCustomer(DataRow row)
        {
            return new Customer
            {
                CustomerId = Convert.ToInt32(row["CustomerId"]),
                FullName = row["FullName"].ToString(),
                IdentityCard = row["IdentityCard"].ToString(),
                PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : null,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,
                Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : null,
                DateOfBirth = row["DateOfBirth"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["DateOfBirth"]) : null,
                Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : null,
                Nationality = row["Nationality"] != DBNull.Value ? row["Nationality"].ToString() : null,
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                UpdatedDate = row["UpdatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedDate"]) : null
            };
        }
    }
}
