using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanApplicationWCFService.WCFServices.LoanService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoanService" in both code and config file together.
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]
        void AddLoan(LoanModel loan);

        [OperationContract]
        void UpdateLoan(LoanModel loan, Guid id);

        [OperationContract]
        void DeleteLoan(Guid id);

        [OperationContract]
        List<LoanModel> GetAllLoans();

        [OperationContract]
        LoanModel GetLoanById(Guid Id);

    }
}
