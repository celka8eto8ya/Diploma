using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface ICustomer
    {
        IEnumerable<CustomerDTO> GetList();
        void Create(FullCustomerDTO fullCustomerDTO);
        void Delete(int id);
        void Update(CustomerDTO customerDTO);
        CustomerDTO GetById(int id);
        bool IsUniqueCustomer(CustomerDTO customerDTO);
        bool IsUniqueFullCustomer(FullCustomerDTO fullCustomerDTO);
        
    }
}
