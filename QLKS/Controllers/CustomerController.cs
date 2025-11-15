using System;
using System.Collections.Generic;
using QLKS.Models;
using QLKS.DAL;

namespace QLKS.Controllers
{
    public class CustomerController
    {
        private CustomerDAL customerDAL;

        public CustomerController()
        {
            customerDAL = new CustomerDAL();
        }

        public List<Customer> GetAllCustomers()
        {
            return customerDAL.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return customerDAL.GetById(id);
        }

        public bool AddCustomer(Customer customer)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(customer.FullName))
            {
                throw new Exception("Tên khách hàng không được để trống");
            }

            if (string.IsNullOrEmpty(customer.IdentityCard))
            {
                throw new Exception("CMND/CCCD không được để trống");
            }

            customer.CreatedDate = DateTime.Now;
            return customerDAL.Insert(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            customer.UpdatedDate = DateTime.Now;
            return customerDAL.Update(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return customerDAL.Delete(id);
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            return customerDAL.Search(keyword);
        }

        public Customer GetCustomerByIdentityCard(string identityCard)
        {
            return customerDAL.GetByIdentityCard(identityCard);
        }
    }
}
