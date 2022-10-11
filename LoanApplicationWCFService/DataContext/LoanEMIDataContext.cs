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
    public class LoanEMIDataContext
    {
        SqlConnection con = null;
        public LoanEMIDataContext()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new SqlConnection(connStr);
            con.Open();
        }
        public void InsertLoanEMI(LoanEMIModel loanEMI)
        {
            var id = Guid.NewGuid();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spInsertLoanEMI";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter EMIId = new SqlParameter("@EMIId", id.ToString());
            cmd.Parameters.Add(EMIId);
            SqlParameter LoanId = new SqlParameter("@LoanId", loanEMI.LoanId);
            cmd.Parameters.Add(LoanId);
            SqlParameter EMIAmout = new SqlParameter("@EMIAmount", loanEMI.EMIAmout);
            cmd.Parameters.Add(EMIAmout);
            SqlParameter EMIPaymentDate = new SqlParameter("@EMIPaymentDate", loanEMI.EMIPaymentDate);
            cmd.Parameters.Add(EMIPaymentDate);
            SqlParameter EMINo = new SqlParameter("@EMINo", loanEMI.EMINo);
            cmd.Parameters.Add(EMINo);
            cmd.ExecuteNonQuery();
        }


        public void UpdateLoanEMIUsingId(LoanEMIModel loanEMI, Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spUpdateLoanEMIModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@LoanId", Id.ToString());
            cmd.Parameters.Add(id);
            SqlParameter LoanId = new SqlParameter("@LoanId", loanEMI.LoanId);
            cmd.Parameters.Add(LoanId);
            SqlParameter EMIAmout = new SqlParameter("@EMIAmout", loanEMI.EMIAmout);
            cmd.Parameters.Add(EMIAmout);
            SqlParameter EMIPaymentDate = new SqlParameter("@EMIPaymentDate", loanEMI.EMIPaymentDate);
            cmd.Parameters.Add(EMIPaymentDate);
            SqlParameter EMINo = new SqlParameter("@EMINo", loanEMI.EMINo);
            cmd.Parameters.Add(EMINo);
            cmd.ExecuteNonQuery();
        }

        public void DeleteLoanEMI(Guid Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spDeleteLoanEMIModel";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@LoanId", Id);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
        }

        public LoanEMIModel GetLoanEMIById(Guid Id)
        {
            var loanEMIsList = GetAllLoanEMIs();
            var requestedloanEMI = loanEMIsList.FirstOrDefault(x => x.EMIId == Id);
            return requestedloanEMI;
        }

        public List<LoanEMIModel> GetAllLoanEMIs()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spGetAllLoanEMIList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("LoanEMITable");
            da.Fill(dt);
            List<LoanEMIModel> loanEMIList = new List<LoanEMIModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoanEMIModel loanEMI = new LoanEMIModel();
                loanEMI.EMIId = new Guid(dt.Rows[i]["EMIId"].ToString());
                loanEMI.LoanId = new Guid(dt.Rows[i]["LoanId"].ToString());
                loanEMI.EMIAmout = Convert.ToDecimal(dt.Rows[i]["EMIAmount"].ToString());
                loanEMI.EMIPaymentDate = dt.Rows[i]["EMIPaymentDate"].ToString();
                loanEMI.EMINo = Convert.ToInt32(dt.Rows[i]["EMINo"].ToString());
                loanEMIList.Add(loanEMI);
            }
            return loanEMIList;
        }
    }
}