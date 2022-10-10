using LoanApplicationWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoanApplicationWCFService.WCFServices.BankDetailsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankDetailsService" in both code and config file together.
    [ServiceContract]
    public interface IBankDetailsService
    {
        [OperationContract]
        void AddBankDetails(BankDetailsModel BankDetails);

        [OperationContract]
        void UpdateBankDetails(BankDetailsModel BankDetails, Guid id);

        [OperationContract]
        void DeleteBankDetails(Guid id);

        [OperationContract]
        List<BankDetailsModel> GetAllBankDetails();

        [OperationContract]
        BankDetailsModel GetBankDetailsById(Guid Id);
    }
}
