using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LoanApplicationWCFService.Models
{
    [DataContract]
    public class LoanEMIModel
    {
        [DataMember]
        public Guid EMIId { get; set; }

        [DataMember]
        public Guid LoanId { get; set; }

        [DataMember]
        public decimal EMIAmout { get; set; }

        [DataMember]
        public string EMIPaymentDate { get; set; }

        [DataMember]
        public int EMINo { get; set; }
    }
}