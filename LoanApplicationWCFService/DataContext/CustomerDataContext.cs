using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LoanApplicationWCFService.DataContext
{
    public class CustomerDataContext
    {
        SqlConnection con = null;
        public CustomerDataContext()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new SqlConnection(connStr);
            con.Open();
        }
        public void InsertCustomer(CustomerModel customer)
        {
            var id = Guid.NewGuid();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spInsertCustomerModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Id = new SqlParameter("@Id", id.ToString());
            cmd.Parameters.Add(Id);
            SqlParameter FirstName = new SqlParameter("@FirstName", customer.FirstName);
            cmd.Parameters.Add(FirstName);
            SqlParameter LastName = new SqlParameter("@LastName", customer.LastName);
            cmd.Parameters.Add(LastName);
            SqlParameter EmailAddress = new SqlParameter("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.Add(EmailAddress);
            SqlParameter Password = new SqlParameter("@Password", customer.Password);
            cmd.Parameters.Add(Password);
            SqlParameter EmploymentType = new SqlParameter("@EmploymentType", customer.EmploymentType);
            cmd.Parameters.Add(EmploymentType);
            SqlParameter MaritialStatus = new SqlParameter("@MaritialStatus", customer.MaritialStatus);
            cmd.Parameters.Add(MaritialStatus);
            SqlParameter Income = new SqlParameter("@Income", customer.Income);
            cmd.Parameters.Add(Income);
            SqlParameter DateOfBirth = new SqlParameter("@DateOfBirth", customer.DateOfBirth);
            cmd.Parameters.Add(DateOfBirth);
            SqlParameter AddressProof = new SqlParameter("@AddressProof", customer.AddressProof);
            cmd.Parameters.Add(AddressProof);
            SqlParameter AddressProofNumber = new SqlParameter("@AddressProofNumber", customer.AddressProofNumber);
            cmd.Parameters.Add(AddressProofNumber);
            SqlParameter PanCardNumber = new SqlParameter("@PanCardNumber", customer.PanCardNumber);
            cmd.Parameters.Add(PanCardNumber);
            SqlParameter PhoneNumber = new SqlParameter("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.Add(PhoneNumber);
            cmd.ExecuteNonQuery();
        }


        public void UpdateCustomerUsingId(CustomerModel customer, Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spUpdateCustomersModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@Id", Id.ToString());
            cmd.Parameters.Add(id);
            SqlParameter FirstName = new SqlParameter("@FirstName", customer.FirstName);
            cmd.Parameters.Add(FirstName);
            SqlParameter LastName = new SqlParameter("@LastName", customer.LastName);
            cmd.Parameters.Add(LastName);
            SqlParameter EmailAddress = new SqlParameter("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.Add(EmailAddress);
            SqlParameter Password = new SqlParameter("@Password", customer.Password);
            cmd.Parameters.Add(Password);
            SqlParameter EmploymentType = new SqlParameter("@EmploymentType", customer.EmploymentType);
            cmd.Parameters.Add(EmploymentType);
            SqlParameter MaritialStatus = new SqlParameter("@MaritialStatus", customer.MaritialStatus);
            cmd.Parameters.Add(MaritialStatus);
            SqlParameter Income = new SqlParameter("@Income", customer.Income);
            cmd.Parameters.Add(Income);
            SqlParameter DateOfBirth = new SqlParameter("@DateOfBirth", customer.DateOfBirth);
            cmd.Parameters.Add(DateOfBirth);
            SqlParameter AddressProof = new SqlParameter("@AddressProof", customer.AddressProof);
            cmd.Parameters.Add(AddressProof);
            SqlParameter AddressProofNumber = new SqlParameter("@AddressProofNumber", customer.AddressProofNumber);
            cmd.Parameters.Add(AddressProofNumber);
            SqlParameter PanCardNumber = new SqlParameter("@PanCardNumber", customer.PanCardNumber);
            cmd.Parameters.Add(PanCardNumber);
            SqlParameter PhoneNumber = new SqlParameter("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.Add(PhoneNumber);
            cmd.ExecuteNonQuery();
        }

        public void DeleteCustomer(Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spDeleteCustomerModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@Id", Id);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
        }

        public CustomerModel GetCustomerById(Guid Id)
        {
            var customersList = GetAllCustomers();
            var requestedCustomer = customersList.FirstOrDefault(x => x.Id == Id);
            return requestedCustomer;
        }

        public List<CustomerModel> GetAllCustomers()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spGetAllCustomerList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("CustomerTable");
            da.Fill(dt);
            List<CustomerModel> customerList = new List<CustomerModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerModel customer = new CustomerModel();
                customer.Id = new Guid(dt.Rows[i]["Id"].ToString());
                customer.FirstName = dt.Rows[i]["FirstName"].ToString();
                customer.LastName = dt.Rows[i]["LastName"].ToString();
                customer.EmailAddress = dt.Rows[i]["EmailAddress"].ToString();
                customer.Password = dt.Rows[i]["Password"].ToString();
                customer.EmploymentType = dt.Rows[i]["EmploymentType"].ToString();
                customer.MaritialStatus = dt.Rows[i]["MaritialStatus"].ToString();
                customer.Income = Convert.ToDecimal(dt.Rows[i]["Income"].ToString());
                customer.DateOfBirth = dt.Rows[i]["DateOfBirth"].ToString();
                customer.AddressProof = dt.Rows[i]["AddressProof"].ToString();
                customer.AddressProofNumber = dt.Rows[i]["AddressProofNumber"].ToString();
                customer.PanCardNumber = dt.Rows[i]["PanCardNumber"].ToString();
                customer.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                customerList.Add(customer);
            }
            return customerList;
        }
    }
}