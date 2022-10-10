using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanEMIApplicationWCFService.WCFServices.LoanEMIEMIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoanEMIEMIService" in both code and config file together.
    [ServiceContract]
    public interface ILoanEMIService
    {
        [OperationContract]
        void AddLoanEMI(LoanEMIModel LoanEMI);

        [OperationContract]
        void UpdateLoanEMI(LoanEMIModel LoanEMI, Guid id);

        [OperationContract]
        void DeleteLoanEMI(Guid id);

        [OperationContract]
        List<LoanEMIModel> GetAllLoanEMIs();

        [OperationContract]
        LoanEMIModel GetLoanEMIById(Guid Id);
    }
}
