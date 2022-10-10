using LoanApplicationWCFService.DataContext;
using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;

namespace LoanApplicationWCFService.WCFServices.BankDetailsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankDetailsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BankDetailsService.svc or BankDetailsService.svc.cs at the Solution Explorer and start debugging.
    public class BankDetailsService : IBankDetailsService
    {
        BankDetailsDataContext bc = new BankDetailsDataContext();
        public void AddBankDetails(BankDetailsModel bankDetails)
        {
            bc.InsertBankDetails(bankDetails);
        }

        public void DeleteBankDetails(Guid id)
        {
            bc.DeleteBankDetails(id);
        }

        public List<BankDetailsModel> GetAllBankDetails()
        {
            return bc.GetAllBankDetailss();
        }

        public BankDetailsModel GetBankDetailsById(Guid Id)
        {
            return bc.GetBankDetailsById(Id);
        }

        public void UpdateBankDetails(BankDetailsModel bankDetails, Guid id)
        {
            bc.UpdateBankDetailsUsingId(bankDetails, id);
        }
    }
}
