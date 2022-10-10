using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LoanApplicationWCFService.Models
{
    [DataContract]
    public class BankDetailsModel
    {
        [DataMember]
        public Guid BankId { get; set; }

        [DataMember]
        public Guid CustomerId { get; set; }

        [DataMember]
        public string BankAccountNumber { get; set; }

        [DataMember]
        public string BankName { get; set; }

        [DataMember]
        public string IFSCCode { get; set; }
    }
}