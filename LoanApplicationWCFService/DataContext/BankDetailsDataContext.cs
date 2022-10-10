using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LoanApplicationWCFService.DataContext
{
    public class BankDetailsDataContext
    {
        SqlConnection con = null;
        public BankDetailsDataContext()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new SqlConnection(connStr);
            con.Open();
        }
        public void InsertBankDetails(BankDetailsModel BankDetails)
        {
            var id = Guid.NewGuid();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spInsertBankDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter BankId = new SqlParameter("@BankId", id.ToString());
            cmd.Parameters.Add(BankId);
            SqlParameter CustomerId = new SqlParameter("@CustomerId", BankDetails.CustomerId );
            cmd.Parameters.Add(CustomerId);
            SqlParameter BankAccountNumber = new SqlParameter("@BankAccountNumber", BankDetails.BankAccountNumber);
            cmd.Parameters.Add(BankAccountNumber);
            SqlParameter BankName = new SqlParameter("@BankName", BankDetails.BankName);
            cmd.Parameters.Add(BankName);
            SqlParameter IFSCCode = new SqlParameter("@IFSCCode", BankDetails.IFSCCode);
            cmd.Parameters.Add(IFSCCode);
            cmd.ExecuteNonQuery();
        }


        public void UpdateBankDetailsUsingId(BankDetailsModel BankDetails, Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spUpdateBankDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter CustomerId = new SqlParameter("@CustomerId", BankDetails.CustomerId);
            cmd.Parameters.Add(CustomerId);
            SqlParameter BankAccountNumber = new SqlParameter("@BankAccountNumber", BankDetails.BankAccountNumber);
            cmd.Parameters.Add(BankAccountNumber);
            SqlParameter BankName = new SqlParameter("@BankName", BankDetails.BankName);
            cmd.Parameters.Add(BankName);
            SqlParameter IFSCCode = new SqlParameter("@IFSCCode", BankDetails.IFSCCode);
            cmd.Parameters.Add(IFSCCode);
            cmd.ExecuteNonQuery();
        }

        public void DeleteBankDetails(Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spDeleteLoanBankDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@BankId", Id);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
        }

        public BankDetailsModel GetBankDetailsById(Guid Id)
        {
            var BankDetailssList = GetAllBankDetailss();
            var requestedBankDetails = BankDetailssList.FirstOrDefault(x => x.BankId == Id);
            return requestedBankDetails;
        }

        public List<BankDetailsModel> GetAllBankDetailss()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spGetAllBankDetailsList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("BankDetailsTable");
            da.Fill(dt);
            List<BankDetailsModel> BankDetailsList = new List<BankDetailsModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BankDetailsModel BankDetails = new BankDetailsModel();
                BankDetails.BankId = new Guid(dt.Rows[i]["BankId"].ToString());
                BankDetails.CustomerId = new Guid(dt.Rows[i]["CustomerId"].ToString());
                BankDetails.BankAccountNumber = dt.Rows[i]["BankAccountNumber"].ToString();
                BankDetails.BankName = dt.Rows[i]["BankName"].ToString();
                BankDetails.IFSCCode = dt.Rows[i]["IFSCCode"].ToString();
                BankDetailsList.Add(BankDetails);
            }
            return BankDetailsList;
        }
    }
}