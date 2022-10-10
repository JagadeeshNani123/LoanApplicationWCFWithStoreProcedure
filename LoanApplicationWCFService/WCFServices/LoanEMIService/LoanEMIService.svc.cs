using LoanApplicationWCFService.DataContext;
using LoanApplicationWCFService.Models;
using LoanEMIApplicationWCFService.WCFServices.LoanEMIEMIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanApplicationWCFService.WCFServices.LoanEMIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoanEMIService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoanEMIService.svc or LoanEMIService.svc.cs at the Solution Explorer and start debugging.
    public class LoanEMIService : ILoanEMIService
    {
        LoanEMIDataContext lc = new LoanEMIDataContext();
        public void AddLoanEMI(LoanEMIModel loanEMI)
        {
            lc.InsertLoanEMI(loanEMI);
        }

        public void DeleteLoanEMI(Guid id)
        {
            lc.DeleteLoanEMI(id);
        }

        public List<LoanEMIModel> GetAllLoanEMIs()
        {
            return lc.GetAllLoanEMIs();
        }

        public LoanEMIModel GetLoanEMIById(Guid Id)
        {
            return lc.GetLoanEMIById(Id);
        }

        public void UpdateLoanEMI(LoanEMIModel loanEMI, Guid id)
        {
            lc.UpdateLoanEMIUsingId(loanEMI, id);
        }

       
    }
}
