using LoanApplicationWCFService.DataContext;
using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanApplicationWCFService.WCFServices.LoanService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoanService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoanService.svc or LoanService.svc.cs at the Solution Explorer and start debugging.
    public class LoanService : ILoanService
    {
        LoanDataContext lc = new LoanDataContext();
        public void AddLoan(LoanModel loan)
        {
            lc.InsertLoan(loan);
        }

        public void DeleteLoan(Guid id)
        {
            lc.DeleteLoan(id);
        }

        public List<LoanModel> GetAllLoans()
        {
            return lc.GetAllLoans();
        }

        public LoanModel GetLoanById(Guid Id)
        {
            return lc.GetLoanById(Id);
        }

        public void UpdateLoan(LoanModel loan, Guid id)
        {
            lc.UpdateLoanUsingId(loan, id);
        }
    }
}
