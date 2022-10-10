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
    public class LoanDataContext
    {
        SqlConnection con = null;
        public LoanDataContext()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new SqlConnection(connStr);
            con.Open();
        }
        public void InsertLoan(LoanModel loan)
        {
            var id = Guid.NewGuid();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spInsertLoanModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter LoanId = new SqlParameter("@LoanId", id.ToString());
            cmd.Parameters.Add(LoanId);
            SqlParameter CustomerId = new SqlParameter("@CustomerId", loan.CustomerId);
            cmd.Parameters.Add(CustomerId);
            SqlParameter LoanType = new SqlParameter("@LoanType", loan.LoanType);
            cmd.Parameters.Add(LoanType);
            SqlParameter LoanAmount = new SqlParameter("@LoanAmount", loan.LoanAmount);
            cmd.Parameters.Add(LoanAmount);
            SqlParameter LoanApprovedDate = new SqlParameter("@LoanApprovedDate", loan.LoanApprovedDate);
            cmd.Parameters.Add(LoanApprovedDate);
            SqlParameter LoanTenure = new SqlParameter("@LoanTenure", loan.LoanTenure);
            cmd.Parameters.Add(LoanTenure);
            SqlParameter IsActive = new SqlParameter("@IsActive", loan.IsActive);
            cmd.Parameters.Add(IsActive);
            cmd.ExecuteNonQuery();
        }


        public void UpdateLoanUsingId(LoanModel loan, Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spUpdateLoanModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@LoanId", Id.ToString());
            cmd.Parameters.Add(id);
            SqlParameter CustomerId = new SqlParameter("@CustomerId", loan.CustomerId);
            cmd.Parameters.Add(CustomerId);
            SqlParameter LoanType = new SqlParameter("@LoanType", loan.LoanType);
            cmd.Parameters.Add(LoanType);
            SqlParameter LoanAmount = new SqlParameter("@LoanAmount", loan.LoanAmount);
            cmd.Parameters.Add(LoanAmount);
            SqlParameter LoanApprovedDate = new SqlParameter("@LoanApprovedDate", loan.LoanApprovedDate);
            cmd.Parameters.Add(LoanApprovedDate);
            SqlParameter LoanTenure = new SqlParameter("@LoanTenure", loan.LoanTenure);
            cmd.Parameters.Add(LoanTenure);
            SqlParameter IsActive = new SqlParameter("@IsActive", loan.IsActive);
            cmd.Parameters.Add(IsActive);
            cmd.ExecuteNonQuery();
        }

        public void DeleteLoan(Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spDeleteLoan";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@LoanId", Id);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
        }

        public LoanModel GetLoanById(Guid Id)
        {
            var loansList = GetAllLoans();
            var requestedloan = loansList.FirstOrDefault(x => x.LoanId == Id);
            return requestedloan;
        }

        public List<LoanModel> GetAllLoans()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spGetAllLoanList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("loanTable");
            da.Fill(dt);
            List<LoanModel> loanList = new List<LoanModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoanModel loan = new LoanModel();
                loan.LoanId = new Guid(dt.Rows[i]["LoanId"].ToString());
                loan.CustomerId = new Guid(dt.Rows[i]["CustomerId"].ToString());
                loan.LoanType = dt.Rows[i]["LoanType"].ToString();
                loan.LoanAmount = Convert.ToDecimal(dt.Rows[i]["LoanAmount"].ToString());
                loan.LoanApprovedDate = dt.Rows[i]["LoanApprovedDate"].ToString();
                loan.LoanTenure = Convert.ToInt32(dt.Rows[i]["LoanTenure"].ToString());
                loan.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                loanList.Add(loan);
            }
            return loanList;
        }
    }
}