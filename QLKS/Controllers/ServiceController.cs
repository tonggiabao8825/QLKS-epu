using System;
using System.Collections.Generic;
using QLKS.Models;
using QLKS.DAL;

namespace QLKS.Controllers
{
    public class ServiceController
    {
        private ServiceDAL serviceDAL;

        public ServiceController()
        {
            serviceDAL = new ServiceDAL();
        }

        public List<Service> GetAllServices()
        {
            return serviceDAL.GetAll();
        }

        public Service GetServiceById(int id)
        {
            return serviceDAL.GetById(id);
        }

        public bool AddService(Service service)
        {
            if (string.IsNullOrEmpty(service.ServiceName))
            {
                throw new Exception("Tên dịch vụ không được để trống");
            }

            service.CreatedDate = DateTime.Now;
            return serviceDAL.Insert(service);
        }

        public bool UpdateService(Service service)
        {
            service.UpdatedDate = DateTime.Now;
            return serviceDAL.Update(service);
        }

        public bool DeleteService(int id)
        {
            return serviceDAL.Delete(id);
        }

        public List<Service> GetServicesByCategory(string category)
        {
            return serviceDAL.GetByCategory(category);
        }
    }
}
