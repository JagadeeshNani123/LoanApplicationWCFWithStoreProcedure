using LoanApplicationWCFService.DataContext;
using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanApplicationWCFService.WCFServices.CustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        CustomerDataContext dc = new CustomerDataContext();
        public void AddCustomer(CustomerModel customer)
        {
            dc.InsertCustomer(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            dc.DeleteCustomer(id);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return dc.GetAllCustomers();
        }

        public CustomerModel GetCustomerById(Guid Id)
        {
            return dc.GetCustomerById(Id);
        }

        public void UpdateCustomer(CustomerModel customer, Guid id)
        {
            dc.UpdateCustomerUsingId(customer, id);
        }
    }
}
